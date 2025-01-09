using Business.Models;
namespace MainApp.Dialogues;

public class CreateContactDialogue
{
    ContactModel contact = new ContactModel()!;
    public void ShowCreateContactDialogue()
    {
        Console.Clear();
        Console.WriteLine($"{"",-3} ---------  CREATE A NEW CONTACT:  ---------");
        Console.WriteLine();

        Console.Write($"{"",-6} Enter first name: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write($"{"",-6} Enter last name: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write($"{"",-6} Enter email address: ");
        contact.Email = Console.ReadLine()!;

        Console.Write($"{"",-6} Enter phone number: ");
        contact.PhoneNumber = Console.ReadLine()!;

        Console.Write($"{"",-6} Enter address: ");
        contact.Address = Console.ReadLine()!;

        Console.WriteLine();
        Console.WriteLine($"{"",-3} -------------------------------------------");
        Console.WriteLine();
        Console.WriteLine($"{"",-6} Contact Created!");

    }

}
