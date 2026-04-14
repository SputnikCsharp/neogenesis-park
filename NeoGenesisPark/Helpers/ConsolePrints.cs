using NeoGenesisPark.Models;

partial class Program
{
    static void MainMenuShow()
    {
        ClearConsole();
        Console.WriteLine("««Register System Of Dinosaurs»»");
        Console.Write($@"
««  NeoGenesis Park — Sistema de Gestión  »»
    Welcome {_userName?.ToUpper()}!

    --- Gestión de Dinosaurios ---
    1. Registrar dinosaurio
    2. Actualizar dinosaurio
    3. Eliminar dinosaurio

    --- Consultas ---
    4. Buscar dinosaurio
    5. Consultas LINQ

    6. Salir

Select an option» ");
    }

    static int LinqMenuShow()
    {
        ClearConsole();
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
        var asd = MenuLinq.CrearPorDefecto();
        asd.Ejecutar();
        return 0;
    }
}