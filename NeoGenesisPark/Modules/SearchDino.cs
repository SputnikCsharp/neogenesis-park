using Microsoft.Extensions.Configuration;
using NeoGenesisPark.Data;
using NeoGenesisPark.Models;

namespace NeoGenesisPark.Modules;

public class SearchDino
{
    private readonly AppDbContext _context;

    public SearchDino(AppDbContext context)
    {
        _context = context;
    }

    public static SearchDino CrearPorDefecto()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var connectionString = config.GetConnectionString("DefaultConnection")!;
        var context = new AppDbContext(connectionString);
        return new SearchDino(context);
    }

    public void Ejecutar()
    {
        Program.TitlesText("Search Dinosaur |", "Search a Dino by username or Email for more information");
        Console.WriteLine();

        Console.Write("Enter Username or Email» ");
        var busqueda = Console.ReadLine()?.Trim();

        var dino = _context.Dinosaurios
            .FirstOrDefault(d => d.Username == busqueda || d.Email == busqueda);

        if (dino == null)
        {
            Program.ShowError($"No dinosaur found with '{busqueda}'.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine(new string('─', 50));
        Console.WriteLine($"  ID          : {dino.Id}");
        Console.WriteLine($"  First Name  : {dino.FirstName}");
        Console.WriteLine($"  Last Name   : {dino.LastName}");
        Console.WriteLine($"  Username    : {dino.Username}");
        Console.WriteLine($"  Email       : {dino.Email}");
        Console.WriteLine($"  Phone       : {dino.Phone    ?? "N/A"}");
        Console.WriteLine($"  Address     : {dino.Address  ?? "N/A"}");
        Console.WriteLine($"  City        : {dino.City     ?? "N/A"}");
        Console.WriteLine($"  Country     : {dino.Country  ?? "N/A"}");
        Console.WriteLine($"  Age (Ma)    : {dino.Age?.ToString() ?? "N/A"}");
        Console.WriteLine($"  Type        : {dino.Type     ?? "N/A"}");
        Console.WriteLine($"  Registered  : {dino.CreatedAt:yyyy-MM-dd}");
        Console.WriteLine(new string('─', 50));
    }
}