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
        Console.WriteLine($"{"",-3} -------------------------  HERE ARE ALL YOUR CONTACTS:  -------------------------");
        Console.WriteLine();
        var contacts = _contactService.GetAll();
        foreach (var contact in contacts) 
        {
            Console.WriteLine($"{"",-5} * {contact.FirstName} {contact.LastName} <{contact.Email}> {contact.Address}");
        }
        Console.WriteLine();
        Console.WriteLine($"{"",-3} ---------------------------------------------------------------------------------");
        Console.ReadKey();
    }

    private void CreateNewContactOption()
    {
        Console.Clear();


        /* This code was generated with the help of Chat GPT */
        string CheckInput(string prompt)
        {
            string input;
            do
            {
                Console.Write($"{"",-5} {prompt}");
                input = Console.ReadLine()!; //does the same thing as form.item = Console.ReadLine()
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine($"{"",-5} This field is required. Please enter a value.");
                    Console.ReadKey();
                }
            } while (string.IsNullOrWhiteSpace(input)); // Do while loop makes it so as long as there is no input or if there is only white space in the feild, you cannot keep on going with creating the contact
            return input; // returns what the user has typed in to the console, to be able to save the data
        }
        /* End of AI generated code */

        var form = ContactFactory.Create();

        Console.Clear();
        Console.WriteLine($"{"",-3} ---------  CREATE A NEW CONTACT:  ---------");
        Console.WriteLine();

        form.FirstName = CheckInput("Enter first name: ");
        form.LastName = CheckInput("Enter last name: ");
        form.Email = CheckInput("Enter e-mail: ");
        form.PhoneNumber = CheckInput("Enter phone number: ");
        form.Address = CheckInput("Enter address: ");

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
