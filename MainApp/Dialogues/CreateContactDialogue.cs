using Business.Models;
namespace MainApp.Dialogues;

public class CreateContactDialogue
{
    ContactModel contact = new ContactModel()!;
    public void ShowCreateContactDialogue()
    {
        Console.Clear();
        Console.WriteLine("---------  CREATE A NEW CONTACT:  ---------");
        Console.WriteLine();

        Console.WriteLine("Enter first name:");
        contact.FirstName = Console.ReadLine()!;

        Console.WriteLine("Enter last name:");
        contact.LastName = Console.ReadLine()!;

        Console.WriteLine("Enter email address:");
        contact.Email = Console.ReadLine()!;

        Console.WriteLine("Enter phone number:");
        contact.PhoneNumber = Console.ReadLine()!;

        Console.WriteLine("Enter address:");
        contact.Address = Console.ReadLine()!;

        Console.WriteLine("-------------------------------------------");
        Console.WriteLine();

    }

}
