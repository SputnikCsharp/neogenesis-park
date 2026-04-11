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
            .Where(d => d.Zona.Equals(zona, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Dinosaurio> FiltrarPorSector(string sector)
    {
        return _dinosaurios
            .Where(d => d.Sector.Equals(sector, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Dinosaurio> FiltrarPorEdad(int edadMinima)
    {
        return _dinosaurios
            .Where(d => d.Edad >= edadMinima)
            .ToList();
    }

    public List<Dinosaurio> FiltrarPorTipo(string tipo)
    {
        return _dinosaurios
            .Where(d => d.Tipo.Equals(tipo, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<(string Codigo, string NombreCompleto)> ProyeccionNombreCodigo()
    {
        return _dinosaurios
            .Select(d => (d.Codigo, $"{d.Nombre} - {d.Especie}"))
            .ToList();
    }

    public List<(string Codigo, string NombreCompleto, string Zona, string Sector)> ProyeccionMultiple()
    {
        return _dinosaurios
            .Select(d => (d.Codigo, $"{d.Nombre} - {d.Especie}", d.Zona, d.Sector))
            .ToList();
    }

    public List<(string Zona, int Total)> ContarPorZona()
    {
        return _dinosaurios
            .GroupBy(d => d.Zona)
            .Select(g => (g.Key, g.Count()))
            .ToList();
    }

    public List<(string Sector, int Total)> ContarPorSector()
    {
        return _dinosaurios
            .GroupBy(d => d.Sector)
            .Select(g => (g.Key, g.Count()))
            .ToList();
    }

    public List<Dinosaurio> SinRastreador()
    {
        return _dinosaurios
            .Where(d => string.IsNullOrWhiteSpace(d.Rastreador))
            .ToList();
    }

    public List<Dinosaurio> SinUbicacion()
    {
        return _dinosaurios
            .Where(d => string.IsNullOrWhiteSpace(d.Ubicacion))
            .ToList();
    }

    public List<Dinosaurio> SinRastreadorNiUbicacion()
    {
        return _dinosaurios
            .Where(d => string.IsNullOrWhiteSpace(d.Rastreador) && string.IsNullOrWhiteSpace(d.Ubicacion))
            .ToList();
    }

    public List<Dinosaurio> OrdenarPorFecha()
    {
        return _dinosaurios
            .OrderByDescending(d => d.FechaRegistro)
            .ToList();
    }

    public List<Dinosaurio> OrdenAlfabetico()
    {
        return _dinosaurios
            .OrderBy(d => d.Especie)
            .ThenBy(d => d.Nombre)
            .ToList();
    }

    public List<(string Codigo, string NombreCompleto, string Sector)> Combinada(string zona, string tipo)
    {
        return _dinosaurios
            .Where(d =>
                d.Zona.Equals(zona, StringComparison.OrdinalIgnoreCase) &&
                d.Tipo.Equals(tipo, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(d.Rastreador))
            .OrderBy(d => d.Nombre)
            .Select(d => (d.Codigo, $"{d.Nombre} - {d.Especie}", d.Sector))
            .ToList();
    }
}
