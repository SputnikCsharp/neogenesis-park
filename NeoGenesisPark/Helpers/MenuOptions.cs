using Spectre.Console;
using NeoGenesisPark.Modules;
partial class Program
{
    // options main menu
    static void RegisterDinosaur()
    {
        ClearConsole();
        RegisterDino.CrearPorDefecto().Ejecutar();
        PressEnterToContinue();
    }

    static void UpdateDinosaur()
    {
        ClearConsole();
        UpdateDino.CrearPorDefecto().Ejecutar();
        PressEnterToContinue();
    }

    static void DeleteDinosaur()
    {
        ClearConsole();
        DeleteDino.CrearPorDefecto().Ejecutar();
        PressEnterToContinue();
    }

    static void SearchDinosaur()
    {  
        ClearConsole();
        SearchDino.CrearPorDefecto().Ejecutar();
        PressEnterToContinue();
    }

    static void Exit()
    {
        AnsiConsole.MarkupLine("[red]Closing App...[/]");
        _exit = true; 
        PressEnterToContinue();
    }
    
    static void InvalidOption()
    {
        AnsiConsole.MarkupLine("[red]Invalid option.[/]");
        PressEnterToContinue();
    }
}
