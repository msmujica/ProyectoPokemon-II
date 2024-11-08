using System;
using System.Collections.Generic;
using Ucu.Poo.DiscordBot.Domain;

namespace Library
{
    public static class GestorEfectos
    { 
        private static Dictionary<Pokemon, List<Efecto>> efectosActivos = new Dictionary<Pokemon, List<Efecto>>();

        public static void AplicarEfecto(Efecto efecto, Pokemon pokemon)
        {
            if (efecto == null || pokemon == null)
            {
                Console.WriteLine("El efecto o el Pokémon son nulos y no se puede aplicar el efecto.");
                return;
            }

            // Asegura que haya una lista de efectos para el Pokémon
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

        public static bool PokemonConEfecto(Pokemon pokemon)
        {
            if (efectosActivos.ContainsKey(pokemon))
            {
                return true;
            }

            return false;
        }
    }
}