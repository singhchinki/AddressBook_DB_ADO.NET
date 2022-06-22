AddressBookUsingAdoNet.AddressBookRepo contact = new AddressBookUsingAdoNet.AddressBookRepo();
Console.WriteLine("SQL Operations\n0.Exit\n1.Show Data\n2.Update Data\n3.Delete Record\nEnter Your choice:");
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
        default:
            Console.WriteLine("Enter valid choice.");
            break;
    }
    Console.WriteLine("SQL Operations\n0.Exit\n1.Show Data\n2.Update Data\n3.Delete Record\nEnter Your choice:");
    choice = Convert.ToInt32(Console.ReadLine());
}