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
        public void DeleteRecord()
        {
            SqlConnection connect = new SqlConnection(connectionString);
            using (connect)
            {
                connect.Open();
                Console.WriteLine("Enter name of person to  delete from records:");
                string name = Console.ReadLine();
                string query = "delete from AddressBook where First_Name='" + name + "'";
                SqlCommand command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();
                connect.Close();
            }
        }
            public void AddData(Book model)
            {
                SqlConnection connection = new SqlConnection(connectionString);
                lock (this)
                {
                    using (connection)
                    {
                        try
                        {
                            SqlCommand command = new SqlCommand("spAddress_Book", connection);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@FIRST_NAME", model.FName);
                            command.Parameters.AddWithValue("@LAST_NAME", model.LName);
                            command.Parameters.AddWithValue("@ADDRESS", model.Address);
                            command.Parameters.AddWithValue("@CITY", model.City);
                            command.Parameters.AddWithValue("@STATE", model.State);
                            command.Parameters.AddWithValue("@ZIP_CODE", model.Zip);
                            command.Parameters.AddWithValue("@PHONE_NUMBER", model.Phone);
                            command.Parameters.AddWithValue("@EMAIL", model.Email);
                            connection.Open();
                            var result = command.ExecuteNonQuery();
                            connection.Close();
                            Console.WriteLine("Data Added Successfully");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }

            public void AddMultipleContacts(List<Book> bookList)
            {
                bookList.ForEach(details =>
                {
                    Thread thread = new Thread(() =>
                    {
                        Console.WriteLine("Thread Start Time: " + DateTime.Now);
                        this.AddData(details);
                        Console.WriteLine("Contact Added: " + details.FName);
                        Console.WriteLine("Thread End Time: " + DateTime.Now);
                    });
                    thread.Start();
                });
            }
    }

}
    

