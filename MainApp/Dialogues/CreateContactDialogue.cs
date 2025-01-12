using Business.Factories;
using Business.Interfaces;
using Business.Services;
namespace MainApp.Dialogues;

public class CreateContactDialogue(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;
    public void ShowCreateContactDialogue()
    {
        var form = ContactFactory.Create();

        Console.Clear();
        Console.WriteLine($"{"",-3} ---------  CREATE A NEW CONTACT:  ---------");
        Console.WriteLine();

        Console.Write($"{"",-6} Enter first name: ");
        form.FirstName = Console.ReadLine()!;

        Console.Write($"{"",-6} Enter last name: ");
        form.LastName = Console.ReadLine()!;

        Console.Write($"{"",-6} Enter email address: ");
        form.Email = Console.ReadLine()!;

        Console.Write($"{"",-6} Enter phone number: ");
        form.PhoneNumber = Console.ReadLine()!;

        Console.Write($"{"",-6} Enter address: ");
        form.Address = Console.ReadLine()!;

        Console.WriteLine();
        Console.WriteLine($"{"",-3} -------------------------------------------");
        Console.WriteLine();

        var result = _contactService.SaveContact(form);

        if (result)
            Console.Write($"{"",-6} Contact was created!");
        else
            Console.Write($"{"",-6} Contact was not created.");
    }

}
