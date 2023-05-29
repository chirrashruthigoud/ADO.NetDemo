using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.netDemo
{
    public class AddressBook
    {
        // ADo.Net -It is established conection between application and database.
        //DataSource: It includes data servers,sql servers.
        //ADO.net is used to CRUD(creating retrieving,upadating,deleting)
        public static string connectionString = @"Data Source=.;Initial Catalog=Address_Book_Service";
        public void AddDataInDatabase(Contact contact)
        {
            SqlConnection sqlconnection=new SqlConnection(connectionString);
            try
            {
                sqlconnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SPAddingData", sqlconnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FirstName",contact.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", contact.LastName);
                sqlCommand.Parameters.AddWithValue("@Address", contact.Address);
                sqlCommand.Parameters.AddWithValue("@City", contact.City);
                sqlCommand.Parameters.AddWithValue("@State", contact.State);
                sqlCommand.Parameters.AddWithValue("@PostalCode", contact.PostalCode);
                sqlCommand.Parameters.AddWithValue("@PhoneNum", contact.PhoneNum);
                sqlCommand.Parameters.AddWithValue("@Email", contact.Email);
                int result=sqlCommand.ExecuteNonQuery();
                sqlconnection.Close();
                if(result >=1)
                {
                    Console.WriteLine("New Contact Added.");
                }
                else
                {
                    Console.WriteLine("error while adding data.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetAllData()
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                List<Contact> list = new List<Contact>();
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SPAllData");
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = sqlCommand.ExecuteReader();  
                    if(reader.Read())
                    {
                        while(reader.Read())
                        {
                            Contact contact = new Contact();
                            contact.FirstName = reader.GetString(0);
                            contact.LastName = reader.GetString(1);
                            contact.Address = reader.GetString(2);
                            contact.City = reader.GetString(3);
                            contact.State = reader.GetString(4);
                            contact.PhoneNum = reader.GetInt32(5);
                            contact.PostalCode = reader.GetInt32(6);
                            contact.Email = reader.GetString(7);
                            list.Add(contact);
                        }
                        foreach(Contact contact in list)
                        {
                            Console.WriteLine(contact.FirstName+ " " +contact.LastName+ " " +contact.Address
                                + " " +contact.City+ "" +contact.State+ ""
                                +contact.PhoneNum+ "" +contact.PostalCode+ "" +contact.Email);
                        }

                       
                    }
                    else
                    {
                        Console.WriteLine("Database have no data.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
