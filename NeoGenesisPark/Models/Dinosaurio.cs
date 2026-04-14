namespace NeoGenesisPark.Models;

public class Dinosaurio
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;   // nombre asignado
    public string LastName { get; set; } = null!;    // especie
    public string Username { get; set; } = null!;    // identificador único
    public string Email { get; set; } = null!;       // código de registro
    public string? Phone { get; set; }               // dispositivo rastreo
    public string? Address { get; set; }             // ubicación
    public string? City { get; set; }                // zona del parque
    public string? Country { get; set; }             // sector del parque
    public int? Age { get; set; }                    // edad
    public string? Type { get; set; }                // carnívoro / herbívoro
    public string? Password { get; set; }            // código de seguridad
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}