
using Microsoft.Extensions.Configuration;
using NeoGenesisPark.Data;

namespace NeoGenesisPark.Models;

public class MenuLinq
{
    private readonly ConsultasLinq _consultas;

    public MenuLinq(ConsultasLinq consultas)
    {
        _consultas = consultas;
    }

    public static MenuLinq CrearPorDefecto()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var connectionString = config.GetConnectionString("DefaultConnection")!;
        var context = new AppDbContext(connectionString);

        var dinosaurios = context.Dinosaurios.ToList();
        var consultas = new ConsultasLinq(dinosaurios);
        return new MenuLinq(consultas);
    }

    public void Ejecutar()
    {
        var corriendo = true;

        while (corriendo)
        {
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "0":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("           __\n          / _)\n   .-^^^-/ /\n__/       /\n<__.|_|-|_|\n\n  ");
                    Console.WriteLine("Rawwwwww ");
                    Console.WriteLine("esto fue echo por AMON");
                    break;
                
                case "1":
                    Titulo("Todos los dinosaurios");
                    var todos = _consultas.ListarTodos();
                    Console.WriteLine($"Total: {todos.Count}");
                    ImprimirLista(todos);
                    break;
                case "2":
                    Titulo("Filtrar por zona");
                    ImprimirLista(_consultas.FiltrarPorZona("Norte"));
                    break;
                case "3":
                    Titulo("Filtrar por sector");
                    ImprimirLista(_consultas.FiltrarPorSector("Selva"));
                    break;
                case "4":
                    Titulo("Filtrar por edad");
                    ImprimirLista(_consultas.FiltrarPorEdad(150));
                    break;
                case "5":
                    Titulo("Filtrar por tipo");
                    ImprimirLista(_consultas.FiltrarPorTipo("Carnívoro"));
                    break;
                case "6":
                    Titulo("Proyeccion nombre + codigo");
                    foreach (var item in _consultas.ProyeccionNombreCodigo())
                    {
                        Console.WriteLine($"{item.Codigo} -> {item.NombreCompleto}");
                    }
                    break;
                case "7":
                    Titulo("Proyeccion multiple");
                    foreach (var item in _consultas.ProyeccionMultiple())
                    {
                        Console.WriteLine($"{item.Codigo} | {item.NombreCompleto} | Zona: {item.Zona} | Sector: {item.Sector}");
                    }
                    break;
                case "8":
                    Titulo("Conteo por zona");
                    foreach (var item in _consultas.ContarPorZona())
                    {
                        Console.WriteLine($"Zona {item.Zona}: {item.Total}");
                    }
                    break;
                case "9":
                    Titulo("Conteo por sector");
                    foreach (var item in _consultas.ContarPorSector())
                    {
                        Console.WriteLine($"Sector {item.Sector}: {item.Total}");
                    }
                    break;
                case "10":
                    Titulo("Sin rastreador");
                    ImprimirLista(_consultas.SinRastreador());
                    break;
                case "11":
                    Titulo("Sin ubicacion");
                    ImprimirLista(_consultas.SinUbicacion());
                    break;
                case "12":
                    Titulo("Sin rastreador ni ubicacion");
                    ImprimirLista(_consultas.SinRastreadorNiUbicacion());
                    break;
                case "13":
                    Titulo("Orden por fecha");
                    ImprimirLista(_consultas.OrdenarPorFecha());
                    break;
                case "14":
                    Titulo("Orden alfabetico");
                    ImprimirLista(_consultas.OrdenAlfabetico());
                    break;
                case "15":
                    Titulo("Consulta combinada");
                    foreach (var item in _consultas.Combinada("Norte", "Carnívoro"))
                    {
                        Console.WriteLine($"{item.Email} | {item.FirstName} | Sector: {item.Country}");
                    }
                    break;
                case "16":
                    corriendo = false;
                    break;
                default:
                    Console.WriteLine("Opcion invalida.");
                    break;
            }
        }
    }

    private static void Titulo(string texto)
    {
        Console.WriteLine($"=== {texto} ===");
    }

    private static void ImprimirLista(IEnumerable<Dinosaurio> dinosaurios)
    {
        foreach (var d in dinosaurios)
        {
            Console.WriteLine($"[{d.Email}] {d.FirstName} - {d.LastName} | Zona: {d.City} | Sector: {d.Country}");
        }
    }
}
