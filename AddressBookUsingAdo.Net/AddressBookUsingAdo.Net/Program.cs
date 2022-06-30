AddressBookUsingAdoNet.AddressBookRepo contact = new AddressBookUsingAdoNet.AddressBookRepo();
Console.WriteLine("SQL Operations\n1.Show Data\n2.Update Data\n3.Delete Record\n4. MultiThread\nEnter Your choice:");
int choice = Convert.ToInt32(Console.ReadLine());
while (choice != 0)
{
    switch (choice)
    {
        case 1:
            contact.getData();
            break;
        case 2:
            contact.UpdateRecord();
            break;
        case 3:
            contact.DeleteRecord();
            break;
        case 4:
            List<AddressBookUsingAdoNet.Book> bookList = new List<AddressBookUsingAdoNet.Book>();
            Console.WriteLine("Enter number of contacts to Add");
            int number = Convert.ToInt32(Console.ReadLine());
            while (number != 0)
            {
                AddressBookUsingAdoNet.Book model = new AddressBookUsingAdoNet.Book();
                Console.WriteLine("Enter First Name");
                model.FName = Console.ReadLine();
                Console.WriteLine("Enter Last Name");
                model.LName = Console.ReadLine();
                Console.WriteLine("Enter Address ");
                model.Address = Console.ReadLine();
                Console.WriteLine("Enter City ");
                model.City = Console.ReadLine();
                Console.WriteLine("Enter State ");
                model.State = Console.ReadLine();
                Console.WriteLine("Enter Zip Code ");
                model.Zip = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Phone ");
                model.Phone = Console.ReadLine();
                Console.WriteLine("Enter Email ");
                model.Email = Console.ReadLine();
                bookList.Add(model);
                number--;
            }
            contact.AddMultipleContacts(bookList);
            break;
        default:
            Console.WriteLine("Enter valid choice.");
            break;
    }
   
}