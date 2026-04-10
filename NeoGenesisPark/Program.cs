using Microsoft.Extensions.Configuration;
using NeoGenesisPark.Data;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile("appsettings.Development.json", optional: true)
    .Build();

var connectionString = config.GetConnectionString("DefaultConnection")!;
var db = new AppDbContext(connectionString);

Console.WriteLine("Conexión configurada correctamente.");