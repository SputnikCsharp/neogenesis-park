using NeoGenesisPark.Models;
namespace NeoGenesisPark.models
{
    public static class ConsultasLINQ
    {
        // CONSULTA 1 — Listar TODOS los dinosaurios
    
        public static List<Dinosaurio> ConsultaUno_ListarTodos(List<Dinosaurio> dinos)
        {
            return dinos.ToList();
        }

        
        // CONSULTA 2 — Filtrar por Zona
        
        public static List<Dinosaurio> ConsultaDos_FiltrarPorZona(List<Dinosaurio> dinos, string zona)
        {
            return dinos
                .Where(d => d.Zona == zona)
                .ToList();
        }

        
        // CONSULTA 3 — Filtrar por Sector
        
        public static List<Dinosaurio> ConsultaTres_FiltrarPorSector(List<Dinosaurio> dinos, string sector)
        {
            return dinos
                .Where(d => d.Sector == sector)
                .ToList();
        }

        
        // CONSULTA 4 — Filtrar por Edad mínima (en millones de años)
        
        public static List<Dinosaurio> ConsultaCuatro_FiltrarPorEdad(List<Dinosaurio> dinos, int edadMinima)
        {
            return dinos
                .Where(d => d.Edad >= edadMinima)
                .ToList();
        }

        
        // CONSULTA 5 — Filtrar por Tipo (Carnívoro / Herbívoro / Omnívoro)
        
        public static List<Dinosaurio> ConsultaCinco_FiltrarPorTipo(List<Dinosaurio> dinos, string tipo)
        {
            return dinos
                .Where(d => d.Tipo == tipo)
                .ToList();
        }

        
        // CONSULTA 6 — Proyección: Nombre completo + Código
        
        public static List<(string NombreCompleto, string Codigo)> ConsultaSeis_ProyeccionNombreCodigo(List<Dinosaurio> dinos)
        {
            return dinos
                .Select(d => (
                    NombreCompleto: $"{d.Nombre} ({d.Especie})",
                    d.Codigo
                ))
                .ToList();
        }

        
        // CONSULTA 7 — Proyección múltiple: nombre + código + zona + sector
        
        public static List<(string NombreCompleto, string Codigo, string Zona, string Sector)>
            ConsultaSiete_ProyeccionMultiple(List<Dinosaurio> dinos)
        {
            return dinos
                .Select(d => (
                    NombreCompleto: $"{d.Nombre} ({d.Especie})",
                    d.Codigo,
                    d.Zona,
                    d.Sector
                ))
                .ToList();
        }

        
        // CONSULTA 8 — Agrupar y contar por Zona
        
        public static List<(string Zona, int Total)> ConsultaOcho_ContarPorZona(List<Dinosaurio> dinos)
        {
            return dinos
                .GroupBy(d => d.Zona)
                .Select(g => (
                    Zona: g.Key,
                    Total: g.Count()
                ))
                .OrderByDescending(x => x.Total)
                .ToList();
        }

        
        // CONSULTA 9 — Agrupar y contar por Sector
        
        public static List<(string Sector, int Total)> ConsultaNueve_ContarPorSector(List<Dinosaurio> dinos)
        {
            return dinos
                .GroupBy(d => d.Sector)
                .Select(g => (
                    Sector: g.Key,
                    Total: g.Count()
                ))
                .OrderByDescending(x => x.Total)
                .ToList();
        }

        
        // CONSULTA 10 — Filtro avanzado: dinosaurios SIN rastreador
        
        public static List<Dinosaurio> ConsultaDiez_SinRastreador(List<Dinosaurio> dinos)
        {
            return dinos
                .Where(d => !d.TieneRastreador)
                .ToList();
        }

        
        // CONSULTA 11 — Filtro avanzado: dinosaurios SIN ubicación
        
        public static List<Dinosaurio> ConsultaOnce_SinUbicacion(List<Dinosaurio> dinos)
        {
            return dinos
                .Where(d => !d.TieneUbicacion)
                .ToList();
        }

        
        // CONSULTA 12 — Filtro avanzado: SIN rastreador Y SIN ubicación
        
        public static List<Dinosaurio> ConsultaDoce_SinRastreadorNiUbicacion(List<Dinosaurio> dinos)
        {
            return dinos
                .Where(d => !d.TieneRastreador && !d.TieneUbicacion)
                .ToList();
        }

        
        // CONSULTA 13 — Ordenar por Fecha de Registro (más reciente primero)
        
        public static List<Dinosaurio> ConsultaTrece_OrdenarPorFecha(List<Dinosaurio> dinos)
        {
            return dinos
                .OrderByDescending(d => d.FechaRegistro)
                .ToList();
        }

        
        // CONSULTA 14 — Ordenar alfabéticamente por Especie, luego Nombre
        
        public static List<Dinosaurio> ConsultaCatorce_OrdenAlfabetico(List<Dinosaurio> dinos)
        {
            return dinos
                .OrderBy(d => d.Especie)
                .ThenBy(d => d.Nombre)
                .ToList();
        }

        
        // CONSULTA 15 — Combinada: filtro + proyección + orden
        //               Carnívoros de zona Norte con rastreador
        
        public static List<(string NombreCompleto, string Codigo, string Sector)>
            ConsultaQuince_Combinada(List<Dinosaurio> dinos, string zona, string tipo)
        {
            return dinos
                .Where(d => d.Zona == zona && d.Tipo == tipo && d.TieneRastreador)
                .OrderBy(d => d.Especie)
                .Select(d => (
                    NombreCompleto: $"{d.Nombre} ({d.Especie})",
                    d.Codigo,
                    d.Sector
                ))
                .ToList();
        }
    }
}
