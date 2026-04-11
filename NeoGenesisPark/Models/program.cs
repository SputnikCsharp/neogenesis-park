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
        var dinosaurios = DinosaurioData.ObtenerDinosaurios();
        var consultas = new ConsultasLinq(dinosaurios);
        return new MenuLinq(consultas);
    }

    public void Ejecutar()
    {
        var corriendo = true;

        while (corriendo)
        {
            LimpiarConsola();
            Console.WriteLine("Seleccione una consulta:");
            Console.WriteLine("1.  Listar todos");
            Console.WriteLine("2.  Filtrar por zona");
            Console.WriteLine("3.  Filtrar por sector");
            Console.WriteLine("4.  Filtrar por edad");
            Console.WriteLine("5.  Filtrar por tipo");
            Console.WriteLine("6.  Proyeccion nombre + codigo");
            Console.WriteLine("7.  Proyeccion multiple");
            Console.WriteLine("8.  Contar por zona");
            Console.WriteLine("9.  Contar por sector");
            Console.WriteLine("10. Sin rastreador");
            Console.WriteLine("11. Sin ubicacion");
            Console.WriteLine("12. Sin rastreador ni ubicacion");
            Console.WriteLine("13. Ordenar por fecha");
            Console.WriteLine("14. Orden alfabetico");
            Console.WriteLine("15. Consulta combinada");
            Console.WriteLine("16. Salir");

            var opcion = Console.ReadLine();
            LimpiarConsola();

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
                        Console.WriteLine($"{item.Codigo} | {item.NombreCompleto} | Sector: {item.Sector}");
                    }
                    break;
                case "16":
                    corriendo = false;
                    continue;
                default:
                    Console.WriteLine("Opcion invalida.");
                    break;
            }

            PresioneParaContinuar();
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
            Console.WriteLine($"[{d.Codigo}] {d.Nombre} - {d.Especie} | Zona: {d.Zona} | Sector: {d.Sector}");
        }
    }

    private static void PresioneParaContinuar()
    {
        Console.WriteLine();
        Console.WriteLine("Presione una tecla para continuar...");
        if (Console.IsInputRedirected)
        {
            Console.ReadLine();
            return;
        }

        Console.ReadKey();
    }

    private static void LimpiarConsola()
    {
        if (Console.IsOutputRedirected)
        {
            Console.WriteLine();
            return;
        }

        Console.Clear();
    }
}
