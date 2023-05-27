using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.netDemo
{
    public class AddressBook
    {
        // ADo.Net -It is established conection between application and database.
        //DataSource: It includes data servers,sql servers.
        //ADO.net is used to CRUD(creating retriving,upadating,deleting)
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
    }
}
