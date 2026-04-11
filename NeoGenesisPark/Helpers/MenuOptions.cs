
using NeoGenesisPark.Modules;
partial class Program
{
    // options main menu
    static int RegisterDinosaur()
    {
        ClearConsole();
        RegisterDino.CrearPorDefecto().Ejecutar();
        PressEnterToContinue();
        return 0;
    }
    static int UpdateDinosaur()
    {
        ClearConsole();
        UpdateDino.CrearPorDefecto().Ejecutar();
        PressEnterToContinue();
        return 0;
    }
    static int DeleteDinosaur()
    {
        DeleteDino.CrearPorDefecto().Ejecutar();
        PressEnterToContinue();
        return 0;
    }
    static int SearchDinosaur()
    {  
        ClearConsole();
        SearchDino.CrearPorDefecto().Ejecutar();
        PressEnterToContinue();
        return 0;
    }
    static int Exit()
    {
        _exit = true;
        Console.WriteLine("Closing App...");
        PressEnterToContinue();
        return 0;
    }
    
    static int InvalidOption()
    {
        Console.WriteLine("Invalid option.");
        PressEnterToContinue();
        return 0;
    }
}