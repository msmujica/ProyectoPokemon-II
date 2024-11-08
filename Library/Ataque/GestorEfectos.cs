using System;
using System.Collections.Generic;
using Ucu.Poo.DiscordBot.Domain;

namespace Library
{
    public class GestorEfectos
    {
        private Dictionary<Pokemon, List<Efecto>> efectosActivos;

        public GestorEfectos()
        {
            this.efectosActivos = new Dictionary<Pokemon, List<Efecto>>();
        }

        public void AplicarEfecto(Efecto efecto, Pokemon pokemon)
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

        public bool ProcesarControlMasa(Pokemon pokem)
        {
            // Verifica si el Pokémon tiene efectos activos
            if (!efectosActivos.ContainsKey(pokem))
            {
                Console.WriteLine($"{pokem.Nombre} no tiene efectos activos.");
                return false;
            }

            List<Efecto> efectos = efectosActivos[pokem];
            foreach (var v in efectos)
            {
                if (v is EfectoDormir || v is EfectoParalizar)
                {
                    return v.ProcesarEfecto(pokem);
                }
            }

            return false;
        }

        public void ProcesarEfectosDaño()
        {
            foreach (var entry in efectosActivos)
            {
                Pokemon pokemon = entry.Key;
                List<Efecto> efectos = entry.Value;

                for (int i = efectos.Count - 1; i >= 0; i--)
                {
                    Efecto efecto = efectos[i];
                    if (efecto is EfectoEnvenenar || efecto is EfectoQuemar)
                    {
                        efecto.ProcesarEfecto(pokemon);
                    }
                }
            }
        }
        
        public void LimpiarEfectos(Pokemon pokemon)
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

        public bool PokemonConEfecto(Pokemon pokemon)
        {
            if (efectosActivos.ContainsKey(pokemon))
            {
                return true;
            }

            return false;
        }
    }
}