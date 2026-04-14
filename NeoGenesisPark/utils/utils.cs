using Microsoft.Extensions.Configuration;
using Spectre.Console;
using NeoGenesisPark.Models;

using NeoGenesisPark.Data;
//utils
partial class Program{
    static void PressEnterToContinue()
    {
        AnsiConsole.MarkupLine("\n[grey]Press Enter to continue...[/]");
        Console.ReadKey(true); // 'true' oculta la tecla presionada
        ClearConsole();
    }

    static void ClearConsole()
    {
        AnsiConsole.Clear();
    }

    static string? GetUserName()
    {
        _userName = AnsiConsole.Ask<string>("Insert your name» ");
        return _userName;
    }
        
    // Generamos las consultas frescas cada vez que entramos al menú LINQ
    // para asegurar que los datos estén actualizados si agregaste/borraste dinos.
    static ConsultasLinq GetUpdateConsults()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var connectionString = config.GetConnectionString("DefaultConnection")!;
        var context = new AppDbContext(connectionString);

        var dinosaurios = context.Dinosaurios.ToList();
        return new ConsultasLinq(dinosaurios);
    }
}