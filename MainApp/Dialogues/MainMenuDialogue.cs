using Business.Factories;
using Business.Interfaces;
using Business.Services;

namespace MainApp.Dialogues;

public class MainMenuDialogue(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;

    static bool isRunning = true;
    public void ShowMainMenu()
    { 
        while(isRunning)
        {
            MainMenu();
        }
    }

    private void MainMenu()
    {

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"{"",-3} ---------  CONTACTS LIST  ---------");
            Console.WriteLine();
            Console.WriteLine($"{"", -6}{"1.",-5} Show all contacts");
            Console.WriteLine($"{"",-6}{"2.", -5} Create new contact");
            Console.WriteLine($"{"",-6}{"Q.",-5} Exit application");
            Console.WriteLine();
            Console.WriteLine($"{"",-3} -----------------------------------");

            Console.WriteLine();
            Console.Write($"{"",-6} Select an option: ");
            string option = Console.ReadLine()!;

            switch (option.ToLower())
            {
                case "1":
                    ShowAllContactsOption();

                    break;

                case "2":
                    CreateNewContactOption();

                    break;

                case "q":
                    QuitApplicationOption();

                    break;

                default:
                    InvalidOption();

                    break;
            }

    }

    private void QuitApplicationOption()
    {

        bool validInput = false;

        while (!validInput) 
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"{"",-3} Are you sure you want to exit the application? (y/n)");
            Console.WriteLine();
            Console.Write($"{"",-4}");
            var option = Console.ReadLine()!;

            switch (option.ToLower())
            {
                case "y":
                    Console.Clear();
                    Console.WriteLine();
                    Console.Write($"{"",-3} You are now leaving the application. Goodbye!");
                    Console.ReadKey();

                    Console.WriteLine();
                    Console.WriteLine();
                    validInput = true;
                    isRunning = false;

                    break;

                case "n":
                    Console.Clear();
                    Console.WriteLine();
                    Console.Write($"{"",-3} Returning to the contact list menu.");
                    validInput = true;
                    Console.ReadKey();

                    break;

                default:
                    InvalidOption();

                    break;

            }
        }
    }

    private void ShowAllContactsOption()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine($"{"",-3} Here are all your contacts");
        Console.WriteLine();
        var contacts = _contactService.GetAll();
        foreach (var contact in contacts) 
        {
            Console.WriteLine($"{"",-6} {contact.FirstName} {contact.LastName} <{contact.Email}> {contact.Address}");
        }
        Console.ReadKey();
    }

    private void CreateNewContactOption()
    {
        Console.Clear();

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

        Console.ReadKey();
    }

    private void InvalidOption()
    {
        Console.WriteLine();
        Console.Write($"{"",-3} Please enter a valid option. Press any key to go back.");
        Console.ReadKey();
    }
}
