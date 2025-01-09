namespace MainApp.Dialogues;

public class MainMenuDialogue
{
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
        Console.WriteLine($"{"",-3} Here are all your contacts");
        Console.ReadKey();
    }

    private void CreateNewContactOption()
    {
        Console.Clear();
        CreateContactDialogue createContact = new();
        createContact.ShowCreateContactDialogue();
        Console.ReadKey();
    }

    private void InvalidOption()
    {
        Console.WriteLine();
        Console.Write($"{"",-3} Please enter a valid option. Press any key to go back.");
        Console.ReadKey();
    }
}
