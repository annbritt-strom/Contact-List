namespace MainApp.Services;
public class OutputDialogueService
{
    public void Show(string message)
    {
        Console.WriteLine(message);
        Console.ReadKey();
    }
}
