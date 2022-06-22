using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace AddressBookUsingAdoNet
{
    internal class AddressBookRepo
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Address_Book_Service_DB;";
      
        public void getData()
        {
            SqlConnection connect = new SqlConnection(connectionString);
            AddressBookUsingAdoNet.Book book = new AddressBookUsingAdoNet.Book();
            using (connect)
            {
                connect.Open();
                string query = "Select * from AddressBook";
                SqlCommand command = new SqlCommand(query, connect);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        book.FName = reader.GetString(0);
                        book.LName = reader.GetString(1);
                        book.Address = reader.GetString(2);
                        book.City = reader.GetString(3);
                        book.State = reader.GetString(4);
                        book.Zip = reader.GetInt32(5);
                        book.Phone = reader.GetString(6);
                        book.Email = reader.GetString(7);
                        book.BookName = reader.GetString(8);
                        book.BookType = reader.GetString(9);
                        book.PersonID = reader.GetInt32(10);
                        Console.WriteLine(book.PersonID + "-->" + book.FName + "-->" + book.LName + "-->" + book.Address + "-->" + book.City + "-->" + book.State + "-->" + book.Zip + "-->" + book.Phone + "-->" + book.Email);
                    }
                }
                else
                {
                    Console.WriteLine("Records not found in Database.");
                }
                reader.Close();
                connect.Close();
            }
        }
        //UC2 Update record in database
        public void UpdateRecord()
        {
            SqlConnection connect = new SqlConnection(connectionString);
            try
            {
                using (connect)
                {
                    Console.WriteLine("Enter name of Person:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter contact to update:");
                    string phone = Console.ReadLine();
                    connect.Open();
                    string query = "update AddressBook set Phone_Number =" + phone + "where First_Name='" + name + "'";
                    SqlCommand command = new SqlCommand(query, connect);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Records updated successfully.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("---------------------------\nError:Records are not updated.\n------------------------------");
            }
        }
    }
}
