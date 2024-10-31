using System;
using System.Collections.Generic;

namespace Library;

public class GestorEfectos
{ 
    private static Dictionary<Pokemon, List<Efecto>> efectosActivos;

    public GestorEfectos()
    {
        efectosActivos = new Dictionary<Pokemon, List<Efecto>>();
    }

    public static void AplicarEfecto(Efecto efecto, Pokemon pokemon)
    {
        if (!efectosActivos.ContainsKey(pokemon))
        {
            efectosActivos[pokemon] = new List<Efecto>();
        }

        efectosActivos[pokemon].Add(efecto);
        efecto.IniciarEfecto(pokemon);
    }

    public static void ProcesarEfectosTurno()
    {
        foreach (var entry in efectosActivos)
        {
            Pokemon pokemon = entry.Key;
            List<Efecto> efectos = entry.Value;

            for (int i = efectos.Count - 1; i >= 0; i--)
            {
                Efecto efecto = efectos[i];
                if (!efecto.ProcesarEfecto(pokemon)) // Si el efecto ha terminado
                {
                    efectos.RemoveAt(i); // Lo eliminamos de la lista
                }
            }
        }
    }
    
    public static void LimpiarEfectos(Pokemon pokemon)
    {
        if (efectosActivos.ContainsKey(pokemon))
        {
            efectosActivos.Remove(pokemon);
            Console.WriteLine($"Todos los efectos han sido eliminados de {pokemon.Nombre}.");
        }
        else
        {
            Console.WriteLine($"{pokemon.Nombre} no tiene efectos activos.");
        }
    }
}
