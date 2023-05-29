using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ado.netDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Contact contact = new Contact()
            {
                FirstName = "sara",
                LastName = "siri",
                Address = "abc",
                City = "HYD",
                State = "AP",
                PostalCode = 23563,
                PhoneNum = 25746322,
                Email = "abcdgmail.com"
            };
            AddressBook book = new AddressBook();
            book.AddDataInDatabase(contact);
            book.GetAllData();
            Console.ReadLine();

        }
    }
}
