using System.Collections.Generic;

namespace Library;

public static class LogicaTipos
{
    private static readonly Dictionary<string, List<string>> Debilidades = new Dictionary<string, List<string>>()
    {
        { "Agua", new List<string> { "Eléctrico", "Planta" } },
        { "Bicho", new List<string> { "Fuego", "Roca", "Volador", "Veneno" } },
        { "Dragón", new List<string> { "Dragón", "Hielo" } },
        { "Eléctrico", new List<string> { "Tierra" } },
        { "Fantasma", new List<string> { "Fantasma" } },
        { "Fuego", new List<string> { "Agua", "Roca", "Tierra" } },
        { "Hielo", new List<string> { "Fuego", "Lucha", "Roca" } },
        { "Lucha", new List<string> { "Psíquico", "Volador" } },
        { "Normal", new List<string> { "Lucha" } },
        { "Planta", new List<string> { "Bicho", "Fuego", "Hielo", "Veneno", "Volador" } },
        { "Psíquico", new List<string> { "Bicho", "Fantasma" } },
        { "Roca", new List<string> { "Agua", "Lucha", "Planta", "Tierra" } },
        { "Tierra", new List<string> { "Agua", "Hielo", "Planta" } },
        { "Veneno", new List<string> { "Psíquico", "Tierra" } },
        { "Volador", new List<string> { "Eléctrico", "Hielo", "Roca" } },
    };

    private static readonly Dictionary<string, List<string>> Resistencias = new Dictionary<string, List<string>>()
    {
        { "Agua", new List<string> { "Agua", "Fuego", "Hielo" } },
        { "Bicho", new List<string> { "Lucha", "Planta", "Tierra" } },
        { "Dragón", new List<string> { "Agua", "Eléctrico", "Fuego", "Planta" } },
        { "Eléctrico", new List<string> { "Volador" } },
        { "Fantasma", new List<string> { "Veneno", "Lucha" } },
        { "Fuego", new List<string> { "Bicho", "Fuego", "Planta" } },
        { "Hielo", new List<string> { "Hielo" } },
        { "Roca", new List<string> { "Fuego", "Normal", "Volador" } },
        { "Tierra", new List<string> { "Eléctrico" } },
        { "Veneno", new List<string> { "Planta", "Veneno" } },
        { "Volador", new List<string> { "Bicho", "Lucha", "Planta" } },
    };

    private static readonly Dictionary<string, List<string>> Inmunidades = new Dictionary<string, List<string>>()
    {
        { "Eléctrico", new List<string> { "Eléctrico" } },
        { "Fantasma", new List<string> { "Normal" } },
        { "Normal", new List<string> { "Fantasma" } }
    };

    public static double CalcularMultiplicador(string tipoAtaque, string tipoDefensor)
    {
        if (Inmunidades.ContainsKey(tipoDefensor) && Inmunidades[tipoDefensor].Contains(tipoAtaque))
            return 0;
            
        if (Debilidades.ContainsKey(tipoDefensor) && Debilidades[tipoDefensor].Contains(tipoAtaque))
            return 2;
            
        if (Resistencias.ContainsKey(tipoDefensor) && Resistencias[tipoDefensor].Contains(tipoAtaque))
            return 0.5;
            
        return 1;
    }
}