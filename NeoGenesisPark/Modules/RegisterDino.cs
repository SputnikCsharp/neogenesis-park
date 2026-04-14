using Microsoft.Extensions.Configuration;
using NeoGenesisPark.Data;
using NeoGenesisPark.Models;

namespace NeoGenesisPark.Modules;

public class RegisterDino
{
    private readonly AppDbContext _context;

    public RegisterDino(AppDbContext context)
    {
        _context = context;
    }

    public static RegisterDino CrearPorDefecto()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var connectionString = config.GetConnectionString("DefaultConnection")!;
        var context = new AppDbContext(connectionString);
        return new RegisterDino(context);
    }

    public void Ejecutar()
    {
        Console.WriteLine("=== Register Dinosaur ===");
        Console.WriteLine("(required fields marked with *)");
        Console.WriteLine();

        Console.Write("First Name *» ");
        var firstName = Console.ReadLine()?.Trim();

        Console.Write("Last Name *» ");
        var lastName = Console.ReadLine()?.Trim();

        Console.Write("Username *» ");
        var username = Console.ReadLine()?.Trim();

        Console.Write("Email *» ");
        var email = Console.ReadLine()?.Trim();

        // opcionales
        Console.Write("Phone (tracker device, optional)» ");
        var phone = Console.ReadLine()?.Trim();

        Console.Write("Address (current location, optional)» ");
        var address = Console.ReadLine()?.Trim();

        Console.Write("City (park zone, optional)» ");
        var city = Console.ReadLine()?.Trim();

        Console.Write("Country (park sector, optional)» ");
        var country = Console.ReadLine()?.Trim();

        Console.Write("Age in millions of years (optional)» ");
        var ageInput = Console.ReadLine()?.Trim();
        int? age = int.TryParse(ageInput, out var parsedAge) ? parsedAge : null;

        Console.Write("Type (Carnívoro / Herbívoro, optional)» ");
        var type = Console.ReadLine()?.Trim();

        Console.Write("Security code (optional)» ");
        var password = Console.ReadLine()?.Trim();

        // validación de campos requeridos
        if (string.IsNullOrWhiteSpace(firstName) ||
            string.IsNullOrWhiteSpace(lastName)  ||
            string.IsNullOrWhiteSpace(username)  ||
            string.IsNullOrWhiteSpace(email))
        {
            Console.WriteLine();
            Console.WriteLine("Error: First Name, Last Name, Username and Email are required.");
            return;
        }

        // verificar duplicados
        var usernameExiste = _context.Dinosaurios.Any(d => d.Username == username);
        var emailExiste    = _context.Dinosaurios.Any(d => d.Email == email);

        if (usernameExiste)
        {
            Console.WriteLine($"Error: Username '{username}' is already registered.");
            return;
        }
        if (emailExiste)
        {
            Console.WriteLine($"Error: Email '{email}' is already registered.");
            return;
        }

        var nuevoDino = new Dinosaurio
        {
            FirstName = firstName,
            LastName  = lastName,
            Username  = username,
            Email     = email,
            Phone     = string.IsNullOrWhiteSpace(phone)   ? null : phone,
            Address   = string.IsNullOrWhiteSpace(address) ? null : address,
            City      = string.IsNullOrWhiteSpace(city)    ? null : city,
            Country   = string.IsNullOrWhiteSpace(country) ? null : country,
            Age       = age,
            Type      = string.IsNullOrWhiteSpace(type)    ? null : type,
            Password  = string.IsNullOrWhiteSpace(password)? null : password,
            CreatedAt = DateTime.UtcNow
        };

        _context.Dinosaurios.Add(nuevoDino);
        _context.SaveChanges();

        Console.WriteLine();
        Console.WriteLine($"Dinosaur '{firstName} {lastName}' registered successfully with ID {nuevoDino.Id}.");
    }
}