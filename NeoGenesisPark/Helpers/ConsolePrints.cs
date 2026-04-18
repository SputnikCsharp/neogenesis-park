
using Spectre.Console;

using NeoGenesisPark.Modules;

partial class Program
{
    static void MainMenuShow()
    {
        ClearConsole();

        
        AnsiConsole.Write(
            new Rule("[green]«« NeoGenesis Park — Management System »»[/]")
            {
                Justification = Justify.Center
            });

        AnsiConsole.MarkupLine($"\n    Welcome [cyan]{_userName?.ToUpper()}[/]!\n");

        
        var selectedOption = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select an [green]option[/] using the arrow keys:")
                .PageSize(10)
                .AddChoiceGroup("[yellow]--- Dinosaur Management ---[/]",
                    "1. Register dinosaur",
                    "2. Update dinosaur",
                    "3. Delete dinosaur")
                .AddChoiceGroup("[blue]--- Queries ---[/]",
                    "4. Search dinosaur",
                    "5. LINQ Queries")
                .AddChoices("[red]6. Exit[/]")
        );

        // 3. Switch Expression (ahora todo retorna void, sin errores de int)
        Action mainAction = selectedOption switch
        {
            "1. Register dinosaur" => () => RegisterDinosaur(),
            "2. Update dinosaur"   => () => UpdateDinosaur(),
            "3. Delete dinosaur"   => () => DeleteDinosaur(),
            "4. Search dinosaur"   => () => SearchDinosaur(),
            "5. LINQ Queries"      => () => LinqMenuShow(),
            "[red]6. Exit[/]"      => () => Exit(),
            _ => () => InvalidOption()
        };

        mainAction();
    }

    static void LinqMenuShow()
    {
        ClearConsole();

        AnsiConsole.Write(
            new Rule("[blue]«« Advanced LINQ Queries »»[/]")
            {
                Justification = Justify.Center
            });

        // Instanciamos las consultas con los datos actualizados de la BD
        var consultas = GetUpdateConsults();

        var linqOption = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("\nSelect a [blue]query[/]:")
                .PageSize(18)
                .AddChoices(new[]
                {
                    "1.  List all",
                    "2.  Filter by zone",
                    "3.  Filter by sector",
                    "4.  Filter by age",
                    "5.  Filter by type",
                    "6.  Projection name + code",
                    "7.  Multiple projection",
                    "8.  Count by zone",
                    "9.  Count by sector",
                    "10. Without tracker",
                    "11. Without location",
                    "12. Without tracker or location",
                    "13. Sort by date",
                    "14. Alphabetical order",
                    "15. Combined query",
                    "[red]16. Return to main menu[/]"
                })
        );

        Action linqAction = linqOption switch
        {
            "1.  List all" => () => 
            {
                var result = consultas.ListarTodos();
                AnsiConsole.MarkupLine($"[green]Total:[/] {result.Count}");
                foreach(var d in result) Console.WriteLine($"[{d.Email}] {d.FirstName} - {d.LastName} | Zone: {d.City} | Sector: {d.Country}");
                PressEnterToContinue();
            },
            "2.  Filter by zone" => () => 
            {
                var zone = AnsiConsole.Ask<string>("Enter [green]zone[/]:");
                var result = consultas.FiltrarPorZona(zone);
                foreach(var d in result) Console.WriteLine($"[{d.Email}] {d.FirstName} - {d.LastName} | Zone: {d.City} | Sector: {d.Country}");
                PressEnterToContinue();
            },
            "3.  Filter by sector" => () => 
            {
                var sector = AnsiConsole.Ask<string>("Enter [green]sector[/]:");
                var result = consultas.FiltrarPorSector(sector);
                foreach(var d in result) Console.WriteLine($"[{d.Email}] {d.FirstName} - {d.LastName} | Zone: {d.City} | Sector: {d.Country}");
                PressEnterToContinue();
            },
            "4.  Filter by age" => () => 
            {
                var age = AnsiConsole.Ask<int>("Enter minimum [green]age[/]:");
                var result = consultas.FiltrarPorEdad(age);
                foreach(var d in result) Console.WriteLine($"[{d.Email}] {d.FirstName} - {d.LastName} | Age: {d.Age}");
                PressEnterToContinue();
            },
            "5.  Filter by type" => () => 
            {
                var type = AnsiConsole.Ask<string>("Enter [green]type[/] (Carnívoro/Herbívoro):");
                var result = consultas.FiltrarPorTipo(type);
                foreach(var d in result) Console.WriteLine($"[{d.Email}] {d.FirstName} - {d.Type}");
                PressEnterToContinue();
            },
            "6.  Projection name + code" => () => 
            {
                var result = consultas.ProyeccionNombreCodigo();
                foreach(var r in result) Console.WriteLine($"{r.Codigo} -> {r.NombreCompleto}");
                PressEnterToContinue();
            },
            "7.  Multiple projection" => () => 
            {
                var result = consultas.ProyeccionMultiple();
                foreach(var r in result) Console.WriteLine($"{r.Codigo} | {r.NombreCompleto} | Zone: {r.Zona} | Sector: {r.Sector}");
                PressEnterToContinue();
            },
            "8.  Count by zone" => () => 
            {
                var result = consultas.ContarPorZona();
                foreach(var r in result) Console.WriteLine($"Zone {r.Zona}: {r.Total}");
                PressEnterToContinue();
            },
            "9.  Count by sector" => () => 
            {
                var result = consultas.ContarPorSector();
                foreach(var r in result) Console.WriteLine($"Sector {r.Sector}: {r.Total}");
                PressEnterToContinue();
            },
            "10. Without tracker" => () => 
            {
                var result = consultas.SinRastreador();
                foreach(var d in result) Console.WriteLine($"[{d.Email}] {d.FirstName}");
                PressEnterToContinue();
            },
            "11. Without location" => () => 
            {
                var result = consultas.SinUbicacion();
                foreach(var d in result) Console.WriteLine($"[{d.Email}] {d.FirstName}");
                PressEnterToContinue();
            },
            "12. Without tracker or location" => () => 
            {
                var result = consultas.SinRastreadorNiUbicacion();
                foreach(var d in result) Console.WriteLine($"[{d.Email}] {d.FirstName}");
                PressEnterToContinue();
            },
            "13. Sort by date" => () => 
            {
                var result = consultas.OrdenarPorFecha();
                foreach(var d in result) Console.WriteLine($"[{d.CreatedAt:yyyy-MM-dd}] {d.FirstName}");
                PressEnterToContinue();
            },
            "14. Alphabetical order" => () => 
            {
                var result = consultas.OrdenAlfabetico();
                foreach(var d in result) Console.WriteLine($"{d.LastName}, {d.FirstName}");
                PressEnterToContinue();
            },
            "15. Combined query" => () => 
            {
                var country = AnsiConsole.Ask<string>("Enter [green]country (sector)[/]:");
                var type = AnsiConsole.Ask<string>("Enter [green]type[/]:");
                var result = consultas.Combinada(country, type);
                foreach(var r in result) Console.WriteLine($"{r.Email} | {r.FirstName} | Sector: {r.Country}");
                PressEnterToContinue();
            },
            "[red]16. Return to main menu[/]" => () => { /* Vuelve automáticamente por el do-while del Main */ },
            _ => () => { }
        };

        linqAction();
    }

   
}