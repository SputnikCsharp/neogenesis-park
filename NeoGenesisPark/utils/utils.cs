partial class Program
    {
        static void PressEnterToContinue()
        {
            Console.WriteLine("\nPress Enter to continue");
            Console.ReadKey();
            Console.Clear();
        }

        static void ClearConsole()
        {
            Console.Clear();
        }
    
        static string? GetUserName()
        {
            Console.Write("Insert your name» ");
            _userName = Console.ReadLine() ?? "Guest";
            return _userName;
        }
        static string? FirstNameDino()
        {
            Console.Write("Assigned Dino Name» ");
            string? name = Console.ReadLine();
            return name;
        }
        static string? LastNameDino()
        {
            Console.Write("Assigned Specie Name» ");
            string? lastName = Console.ReadLine();
            return lastName;
        }
        static string? UserNameDino()
        {
            Console.Write("Assigned Username» ");
            string? lastName = Console.ReadLine();
            return lastName;
        }
    }