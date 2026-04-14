using Microsoft.Extensions.Configuration;
using NeoGenesisPark.Data;
using NeoGenesisPark.Models;

namespace NeoGenesisPark.Modules;

public class DeleteDino
{
    private readonly AppDbContext _context;

    public DeleteDino(AppDbContext context)
    {
        _context = context;
    }

    public static DeleteDino CrearPorDefecto()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var connectionString = config.GetConnectionString("DefaultConnection")!;
        var context = new AppDbContext(connectionString);
        return new DeleteDino(context);
    }

    public void Ejecutar()
    {
        Console.WriteLine("=== Delete Dinosaur ===");
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
        Console.WriteLine($"Found: [{dino.Email}] {dino.FirstName} {dino.LastName} | Zone: {dino.City} | Type: {dino.Type}");
        Console.WriteLine();
        Console.Write("Are you sure you want to delete this record? (yes/no)» ");
        var confirmacion = Console.ReadLine()?.Trim().ToLower();

        if (confirmacion != "yes")
        {
            Console.WriteLine("Operation cancelled.");
            return;
        }

        _context.Dinosaurios.Remove(dino);
        _context.SaveChanges();

        Console.WriteLine();
        Console.WriteLine($"Dinosaur '{dino.FirstName} {dino.LastName}' deleted successfully.");
    }
}