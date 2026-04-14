using Microsoft.Extensions.Configuration;
using NeoGenesisPark.Data;

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
        Program.TitlesText("Delete a Dinosaur", $"Fill the fields to continue");
        

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
        Program.ShowWarning("You are sure to delete this (yes/no)» ");
        var confirmacion = Console.ReadLine()?.Trim().ToLower();

        if (confirmacion != "yes")
        {
            Program.ShowSuccess("Operation cancelled");
            return;
        }

        _context.Dinosaurios.Remove(dino);
        _context.SaveChanges();

        Console.WriteLine();
        Program.ShowSuccess($"Dinosaur '{dino.FirstName} {dino.LastName}' deleted successfully.");
    }
}