
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
            if (int.TryParse(Console.ReadLine(), out int option))
            {
                _ = option switch // switch expression lambda
                {
                    1 => (int)RegisterDinosaur(), //(int) si el metodo retorna un int se vera asi, si no, dara error el cast.
                    2 => (int)UpdateDinosaur(),
                    3 => DeleteDinosaur(),
                    4 => SearchDinosaur(),
                    5 => LinqMenuShow(),
                    6 => Exit(),
                    _ => InvalidOption()
                };
            }
            else
            {
                InvalidOption();
            }
        } while (!_exit);
    }
}