partial class Program
{
    static bool _exit = false;
    static string _userName;
    static void Main(string[] args)
    {
        ClearConsole();
        GetUserName();
        do
        {
            ClearConsole();
            Console.WriteLine("««Register System Of Dinosaurs»»");
            Console.Write(@$"Welcome {_userName?.ToUpper()}!
1. Register Dinosaur
2.
3.
4.
5.
6: Salir
Select an option» 
» ");
            if (int.TryParse(Console.ReadLine(), out int option))
            {
                switch (option)
                {
                    case 1:
                        ClearConsole();
                        break;
                    case 2:
                        ClearConsole();
                        break;
                    case 3:
                        ClearConsole();
                        break;
                    case 4:
                        ClearConsole();
                        break;
                    case 5:
                        break;
                    case 6:
                        _exit = true;
                        Console.WriteLine("Closing App...");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        PressEnterToContinue();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Insert a valid option.");
                PressEnterToContinue();
            }
        } while (!_exit);
    }
}