

partial class Program
{
    static bool _exit = false;
    static string? _userName;

    static void Main(string[] args)
    {
        ClearConsole();
        GetUserName();
        do
        {
            MainMenuShow();
        } while (!_exit);
    }
}