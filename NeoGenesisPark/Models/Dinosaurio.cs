namespace NeoGenesisPark.Models;

public class Dinosaurio
{
    public int Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Especie { get; set; } = string.Empty;
    public string Zona { get; set; } = string.Empty;
    public string Sector { get; set; } = string.Empty;
    public int Edad { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public decimal PesoToneladas { get; set; }
    public string? Rastreador { get; set; }
    public string? Ubicacion { get; set; }
    public DateTime FechaRegistro { get; set; }
}
