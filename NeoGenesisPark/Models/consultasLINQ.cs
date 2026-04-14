using NeoGenesisPark.Models;

namespace NeoGenesisPark.Models;

public class ConsultasLinq
{
    private readonly List<Dinosaurio> _dinosaurios;

    public ConsultasLinq(IEnumerable<Dinosaurio> dinosaurios)
    {
        _dinosaurios = dinosaurios.ToList();
    }

    public List<Dinosaurio> ListarTodos()
    {
        return _dinosaurios.ToList();
    }

    public List<Dinosaurio> FiltrarPorZona(string zona)
    {
        return _dinosaurios
            .Where(d => d.City.Equals(zona, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Dinosaurio> FiltrarPorSector(string sector)
    {
        return _dinosaurios
            .Where(d => d.Country.Equals(sector, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Dinosaurio> FiltrarPorEdad(int edadMinima)
    {
        return _dinosaurios
            .Where(d => d.Age >= edadMinima)
            .ToList();
    }

    public List<Dinosaurio> FiltrarPorTipo(string tipo)
    {
        return _dinosaurios
            .Where(d => d.Type.Equals(tipo, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<(string Codigo, string NombreCompleto)> ProyeccionNombreCodigo()
    {
        return _dinosaurios
            .Select(d => (d.Email, $"{d.FirstName} - {d.LastName}"))
            .ToList();
    }

    public List<(string Codigo, string NombreCompleto, string? Zona, string? Sector)> ProyeccionMultiple()
    {
        return _dinosaurios
            .Select(d => (d.Email, $"{d.FirstName} - {d.LastName}", d.City, d.Country))
            .ToList();
    }

    public List<(string? Zona, int Total)> ContarPorZona()
    {
        return _dinosaurios
            .GroupBy(d => d.City)
            .Select(g => (g.Key, g.Count()))
            .ToList();
    }

    public List<(string? Sector, int Total)> ContarPorSector()
    {
        return _dinosaurios
            .GroupBy(d => d.Country)
            .Select(g => (g.Key, g.Count()))
            .ToList();
    }

    public List<Dinosaurio> SinRastreador()
    {
        return _dinosaurios
            .Where(d => string.IsNullOrWhiteSpace(d.Phone))
            .ToList();
    }

    public List<Dinosaurio> SinUbicacion()
    {
        return _dinosaurios
            .Where(d => string.IsNullOrWhiteSpace(d.Address))
            .ToList();
    }

    public List<Dinosaurio> SinRastreadorNiUbicacion()
    {
        return _dinosaurios
            .Where(d => string.IsNullOrWhiteSpace(d.Phone) && string.IsNullOrWhiteSpace(d.Address))
            .ToList();
    }

    public List<Dinosaurio> OrdenarPorFecha()
    {
        return _dinosaurios
            .OrderByDescending(d => d.CreatedAt)
            .ToList();
    }

    public List<Dinosaurio> OrdenAlfabetico()
    {
        return _dinosaurios
            .OrderBy(d => d.LastName)
            .ThenBy(d => d.FirstName)
            .ToList();
    }

    public List<(string Email, string FirstName, string Country)> Combinada(string country, string tipo)
    {
        return _dinosaurios
            .Where(d =>
                d.City.Equals(country, StringComparison.OrdinalIgnoreCase) &&
                d.Type.Equals(tipo, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(d.Phone))
            .OrderBy(d => d.FirstName)
            .Select(d => (d.Email, $"{d.FirstName} - {d.LastName}", d.Country))
            .ToList();
    }
}
