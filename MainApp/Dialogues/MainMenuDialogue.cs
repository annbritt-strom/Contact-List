using MainApp.Services;

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
        OutputDialogueService dialogue = new();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("---------  CONTACTS LIST  ---------");
            Console.WriteLine();
            Console.WriteLine($"{"1.",-5} Show all contacts");
            Console.WriteLine($"{"2.", -5} Create new contact");
            Console.WriteLine($"{"Q.",-5} Exit application");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");

            Console.WriteLine();
            Console.Write("Select an option: ");
            string option = Console.ReadLine()!;

            switch (option.ToLower())
            {
                case "1":
                    dialogue.Show("Here are all your contacts");

                    break;

                case "2":
                    CreateContactDialogue createContact = new();
                    createContact.ShowCreateContactDialogue();

                    break;

                case "q":
                    Console.Clear();
                    dialogue.Show("You are now leaving the application. Goodbye!");
                    isRunning = false;
                    break;

                default:
                    dialogue.Show("Please enter a valid option. Press any key to go back.");

                    break;
            }

    }
}
