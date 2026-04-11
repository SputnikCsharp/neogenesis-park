using Microsoft.Extensions.Configuration;
using NeoGenesisPark.Data;
using NeoGenesisPark.Models;

namespace NeoGenesisPark.Modules;

public class UpdateDino
{
    private readonly AppDbContext _context;

    public UpdateDino(AppDbContext context)
    {
        _context = context;
    }

    public static UpdateDino CrearPorDefecto()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var connectionString = config.GetConnectionString("DefaultConnection")!;
        var context = new AppDbContext(connectionString);
        return new UpdateDino(context);
    }

    public void Ejecutar()
    {
        Console.WriteLine("=== Update Dinosaur ===");
        Console.WriteLine();

        Console.Write("Enter Username or Email to find the dinosaur» ");
        var busqueda = Console.ReadLine()?.Trim();

        var dino = _context.Dinosaurios
            .FirstOrDefault(d => d.Username == busqueda || d.Email == busqueda);

        if (dino == null)
        {
            Console.WriteLine($"Error: No dinosaur found with '{busqueda}'.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine($"Found: [{dino.Email}] {dino.FirstName} {dino.LastName}");
        Console.WriteLine("Leave blank to keep current value.");
        Console.WriteLine();

        Console.Write($"First Name [{dino.FirstName}]» ");
        var firstName = Console.ReadLine()?.Trim();

        Console.Write($"Last Name [{dino.LastName}]» ");
        var lastName = Console.ReadLine()?.Trim();

        Console.Write($"Phone [{dino.Phone ?? "none"}]» ");
        var phone = Console.ReadLine()?.Trim();

        Console.Write($"Address [{dino.Address ?? "none"}]» ");
        var address = Console.ReadLine()?.Trim();

        Console.Write($"City [{dino.City ?? "none"}]» ");
        var city = Console.ReadLine()?.Trim();

        Console.Write($"Country [{dino.Country ?? "none"}]» ");
        var country = Console.ReadLine()?.Trim();

        Console.Write($"Age [{dino.Age?.ToString() ?? "none"}]» ");
        var ageInput = Console.ReadLine()?.Trim();

        Console.Write($"Type [{dino.Type ?? "none"}]» ");
        var type = Console.ReadLine()?.Trim();

        // solo actualiza si el usuario ingresó algo
        if (!string.IsNullOrWhiteSpace(firstName)) dino.FirstName = firstName;
        if (!string.IsNullOrWhiteSpace(lastName))  dino.LastName  = lastName;
        if (!string.IsNullOrWhiteSpace(phone))     dino.Phone     = phone;
        if (!string.IsNullOrWhiteSpace(address))   dino.Address   = address;
        if (!string.IsNullOrWhiteSpace(city))      dino.City      = city;
        if (!string.IsNullOrWhiteSpace(country))   dino.Country   = country;
        if (!string.IsNullOrWhiteSpace(type))      dino.Type      = type;
        if (int.TryParse(ageInput, out var parsedAge)) dino.Age   = parsedAge;

        _context.SaveChanges();

        Console.WriteLine();
        Console.WriteLine($"Dinosaur '{dino.FirstName} {dino.LastName}' updated successfully.");
    }
}