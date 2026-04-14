using Spectre.Console;
partial class Program
{
    public static void TitlesText(string? titleTextModule, string? descriptionModule)
    {
        // Tu lógica de asignación, agregando un valor por defecto por si llega a ser null
        string titleText = titleTextModule ?? "NeoGenesis Park";
        string description = descriptionModule ?? "No description available.";

        // Creamos el panel estilizado con la descripción adentro y el título en el borde // esto es un metodo de spectre
        var panel = new Panel(new Markup($"[italic grey]{description}[/]"))
        {
            Header = new PanelHeader($"[bold cyan] {titleText} [/]"),
            Padding = new Padding(2, 1, 2, 1), // Espaciado interno (izq, sup, der, inf)
            Expand = true,                     // Se expande a lo ancho de la terminal
            Border = BoxBorder.Rounded         // Bordes redondeados para un toque moderno
        };

        // Imprimimos el panel
        AnsiConsole.Write(panel);
        Console.WriteLine(); // Un salto de línea para separar el panel del próximo contenido
        
    }
    public static void ShowSuccess(string message)
    {
        AnsiConsole.MarkupLine($"\n[bold green]✓ SUCCESS:[/] {message}");
    }
    public static void ShowError(string message)
    {
        AnsiConsole.MarkupLine($"\n[bold red]✗ ERROR:[/] {message}");
    }
    public static void ShowWarning(string message)
    {
        AnsiConsole.MarkupLine($"\n[bold yellow]⚠ WARNING:[/] {message}");
    }
}