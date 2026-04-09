using NeoGenesisPark.Models;
using // aqui la db
using NeoGenesisPark.Models;

//   TALLER DE LINQ — SISTEMA DE DINOSAURIOS
//   20 dinosaurios | 15 consultas funcionales


List<Dinosaurio> dinosaurios = DinosaurioData.ObtenerDinosaurios();

// Helper para imprimir encabezados
void Titulo(string texto)
{
    Console.WriteLine();
    Console.WriteLine($"=== {texto} ===");
    Console.ResetColor();
}

void Separador() => Console.WriteLine(new string('─', 60));

static void PressEnterToContinue()
{
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();
}
///  Menu para selecionde consultas


        bool corriendo = true;
        while (corriendo)
        {
            Console.WriteLine("select one level");
            Console.WriteLine("1.  CONSULTA 1 — Listar todos");
            Console.WriteLine("2.  CONSULTA 2 — Filtrar por zona");
            Console.WriteLine("3.  CONSULTA 3 — Filtrar por sector");
            Console.WriteLine("4.  CONSULTA 4 — Filtrar por edad");
            Console.WriteLine("5.  CONSULTA 5 — Filtrar por tipo");
            Console.WriteLine("6.  CONSULTA 6 — Proyección nombre completo + código");
            Console.WriteLine("7.  CONSULTA 7 — Proyección múltiple");
            Console.WriteLine("8.  CONSULTA 8 — Contar por zona");
            Console.WriteLine("9.  CONSULTA 9 — Contar por sector");
            Console.WriteLine("10. CONSULTA 10 — Sin rastreador");
            Console.WriteLine("11. CONSULTA 11 — Sin ubicación");
            Console.WriteLine("12. CONSULTA 12 — Sin rastreador NI ubicación");
            Console.WriteLine("13. CONSULTA 13 — Ordenar por fecha");
            Console.WriteLine("14. CONSULTA 14 — Orden alfabético");
            Console.WriteLine("15. CONSULTA 15 — Combinada: Zona Norte + Carnívoro + con rastreador");
            Console.WriteLine("16. EXIT");

            string option =  Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    
                    Titulo("CONSULTA 1 — Todos los dinosaurios");
                    var todos = ConsultasLINQ.ConsultaUno_ListarTodos(dinosaurios);
                    Console.WriteLine($"Total: {todos.Count} dinosaurios registrados");
                    foreach (var d in todos) 
                        Console.WriteLine($"  [{d.Codigo}] {d.Nombre} - {d.Especie} | Zona: {d.Zona} | Tipo: {d.Tipo}");
                    
                    PressEnterToContinue();
                    break;

                case "2":
                    Console.Clear();
                    
                    Titulo("CONSULTA 2 — Filtrar por Zona: Norte");
                    var porZona = ConsultasLINQ.ConsultaDos_FiltrarPorZona(dinosaurios, "Norte");
                    Console.WriteLine($"Dinosaurios en zona Norte: {porZona.Count}");
                    foreach (var d in porZona)
                        Console.WriteLine($"  [{d.Codigo}] {d.Nombre} ({d.Especie})");
                    
                    PressEnterToContinue();
                    break;
                
                case "3":
                    Console.Clear();
                    
                    Titulo("CONSULTA 3 — Filtrar por Sector: Selva");
                    var porSector = ConsultasLINQ.ConsultaTres_FiltrarPorSector(dinosaurios, "Selva");
                    Console.WriteLine($"Dinosaurios en sector Selva: {porSector.Count}");
                    foreach (var d in porSector)
                        Console.WriteLine($"  [{d.Codigo}] {d.Nombre} | Zona: {d.Zona}");
                    
                    PressEnterToContinue();
                    break;
                
                case "4":
                    Console.Clear();
                    
                    Titulo("CONSULTA 4 — Dinosaurios con Edad >= 150 millones de años");
                    var porEdad = ConsultasLINQ.ConsultaCuatro_FiltrarPorEdad(dinosaurios, 150);
                    Console.WriteLine($"Dinosaurios con 150+ Ma: {porEdad.Count}");
                    foreach (var d in porEdad)
                        Console.WriteLine($"  [{d.Codigo}] {d.Nombre} — {d.Edad} Ma");
                   
                    PressEnterToContinue();
                    break;
                
                case "5":
                    Console.Clear();
                    
                    Titulo("CONSULTA 5 — Filtrar por Tipo: Carnívoro");
                    var porTipo = ConsultasLINQ.ConsultaCinco_FiltrarPorTipo(dinosaurios, "Carnívoro");
                    Console.WriteLine($"Carnívoros registrados: {porTipo.Count}");
                    foreach (var d in porTipo)
                        Console.WriteLine($"  [{d.Codigo}] {d.Nombre} ({d.Especie}) — {d.PesoToneladas} t");
                    
                    PressEnterToContinue();
                    break;

                case "6":
                    Console.Clear();
                    
                    Titulo("CONSULTA 6 — Proyección: Nombre completo + Código");
                    var proyeccion = ConsultasLINQ.ConsultaSeis_ProyeccionNombreCodigo(dinosaurios);
                    foreach (var item in proyeccion)
                        Console.WriteLine($"  {item.Codigo}  →  {item.NombreCompleto}"); 
                    
                    PressEnterToContinue();
                    break;
                
                 case "7":
                    Console.Clear();
                    
                    Titulo("CONSULTA 7 — Proyección múltiple: Nombre + Código + Zona + Sector");
                    var proyeccionMulti = ConsultasLINQ.ConsultaSiete_ProyeccionMultiple(dinosaurios);
                    foreach (var item in proyeccionMulti)
                        Console.WriteLine($"  {item.Codigo} | {item.NombreCompleto,-35} | Zona: {item.Zona,-6} | Sector: {item.Sector}"); 
                    
                    PressEnterToContinue();
                    break;
                
                 case "8":
                     Console.Clear();
                     
                     Titulo("CONSULTA 8 — Agrupación: Conteo por Zona");
                     var conteoZona = ConsultasLINQ.ConsultaOcho_ContarPorZona(dinosaurios);
                     foreach (var item in conteoZona)
                         Console.WriteLine($"  Zona {item.Zona,-10}: {item.Total} dinosaurio(s)");
                     
                    PressEnterToContinue();
                    break;
                
                 case  "9":
                     Console.Clear();
                     
                     Titulo("CONSULTA 9 — Agrupación: Conteo por Sector");
                     var conteoSector = ConsultasLINQ.ConsultaNueve_ContarPorSector(dinosaurios);
                     foreach (var item in conteoSector)
                         Console.WriteLine($"  Sector {item.Sector,-12}: {item.Total} dinosaurio(s)"); 
                     
                    PressEnterToContinue();
                    break;
                case "10":
                    Console.Clear();
                    
                    Titulo("CONSULTA 10 — Filtro avanzado: Sin rastreador");
                    var sinRastreador = ConsultasLINQ.ConsultaDiez_SinRastreador(dinosaurios);
                    Console.WriteLine($"Dinosaurios SIN rastreador: {sinRastreador.Count}");
                    foreach (var d in sinRastreador)
                        Console.WriteLine($"  [{d.Codigo}] {d.Nombre} | Zona: {d.Zona} | Sector: {d.Sector}"); 
                    
                    PressEnterToContinue();
                    break;

                case "11":
                    Console.Clear();
                    
                    Titulo("CONSULTA 11 — Filtro avanzado: Sin ubicación");
                    var sinUbicacion = ConsultasLINQ.ConsultaOnce_SinUbicacion(dinosaurios);
                    Console.WriteLine($"Dinosaurios SIN ubicación: {sinUbicacion.Count}");
                    foreach (var d in sinUbicacion)
                        Console.WriteLine($"  [{d.Codigo}] {d.Nombre} | Zona: {d.Zona} | Tipo: {d.Tipo}"); 
                    
                    PressEnterToContinue();
                    break;
                
                case "12":
                    Console.Clear();
                    
                    Titulo("CONSULTA 12 — Sin rastreador Y sin ubicación (peligro máximo)");
                    var sinAmbos = ConsultasLINQ.ConsultaDoce_SinRastreadorNiUbicacion(dinosaurios);
                    Console.WriteLine($"Dinosaurios completamente desaparecidos del radar: {sinAmbos.Count}");
                    foreach (var d in sinAmbos)
                        Console.WriteLine($"  [{d.Codigo}] {d.Nombre} ({d.Especie}) — ¡ALERTA!");
                    
                    PressEnterToContinue();
                    break;
                
                case "13":
                    Console.Clear();
                    
                    Titulo("CONSULTA 13 — Orden por Fecha de Registro (más reciente primero)");
                    var porFecha = ConsultasLINQ.ConsultaTrece_OrdenarPorFecha(dinosaurios);
                    foreach (var d in porFecha)
                        Console.WriteLine($"  {d.FechaRegistro:yyyy-MM-dd}  [{d.Codigo}]  {d.Nombre}");
                    
                    PressEnterToContinue();
                    break;
                
                case "14":
                    Console.Clear();
                    
                    Titulo("CONSULTA 14 — Orden alfabético por Especie, luego Nombre");
                    var alfabetico = ConsultasLINQ.ConsultaCatorce_OrdenAlfabetico(dinosaurios);
                    foreach (var d in alfabetico)
                        Console.WriteLine($"  {d.Especie,-35} → {d.Nombre}"); 
                    
                    PressEnterToContinue();
                    break;

                case "15":
                    Console.Clear();
                    
                    Titulo("CONSULTA 15 — Combinada: Carnívoros en Zona Norte con rastreador");
                    var combinada = ConsultasLINQ.ConsultaQuince_Combinada(dinosaurios, "Norte", "Carnívoro");
                    if (combinada.Count == 0)
                    {
                        Console.WriteLine("  No se encontraron resultados para esa combinación.");
                        Console.WriteLine("  (Probando con Zona Norte + Herbívoro...)");
                        combinada = ConsultasLINQ.ConsultaQuince_Combinada(dinosaurios, "Norte", "Herbívoro");
                    }
                    Console.WriteLine($"  Resultados: {combinada.Count}");
                    foreach (var item in combinada)
                        Console.WriteLine($"  {item.Codigo}  |  {item.NombreCompleto,-35}  |  Sector: {item.Sector}"); 
                    
                    PressEnterToContinue();
                    break;
                
                case "16":
                    Console.Clear();
                    corriendo = false;
                    PressEnterToContinue();
                    break;
            }
           
        }
        