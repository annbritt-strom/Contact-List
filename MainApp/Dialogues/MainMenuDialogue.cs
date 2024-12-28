namespace MainApp.Dialogues;

public class MainMenuDialogue
{
    public void OpenMainMenu()
    {
        var isRunning = true;

        do
        {
            Console.Clear();
            Console.WriteLine("--------- CONTACTS LIST ---------");
            Console.WriteLine();
            Console.WriteLine("1. Show all contacts");
            Console.WriteLine("2. Add new contact");
            Console.WriteLine("Q. Exit application");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.Write("Please select an option: ");
            string option = Console.ReadLine()!;

            switch (option.ToLower())
            {
                case "1":

                break;

                case "2":

                break;

                case "3":

                break;

                default:
                    
                break;
            }
        } while (isRunning);
    }
}
