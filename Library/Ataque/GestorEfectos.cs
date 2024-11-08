using System;
using System.Collections.Generic;
using Ucu.Poo.DiscordBot.Domain;

namespace Library
{
    /// <summary>
    /// Gestor que maneja los efectos activos de un Pokémon en combate.
    /// Puede aplicar efectos, procesarlos (como daño continuo o estados) y limpiar los efectos.
    /// </summary>
    public class GestorEfectos
    {
        // Diccionario que almacena los efectos activos para cada Pokémon
        private Dictionary<Pokemon, List<Efecto>> efectosActivos;

        // Constructor que inicializa el diccionario de efectos
        public GestorEfectos()
        {
            this.efectosActivos = new Dictionary<Pokemon, List<Efecto>>();
        }

        /// <summary>
        /// Aplica un efecto específico a un Pokémon.
        /// </summary>
        /// <param name="efecto">El efecto a aplicar.</param>
        /// <param name="pokemon">El Pokémon que recibirá el efecto.</param>
        public void AplicarEfecto(Efecto efecto, Pokemon pokemon)
        {
            if (efecto == null || pokemon == null)
            {
                Console.WriteLine("El efecto o el Pokémon son nulos y no se puede aplicar el efecto.");
                return;
            }

            // Asegura que haya una lista de efectos para el Pokémon en el diccionario
            if (!efectosActivos.ContainsKey(pokemon))
            {
                efectosActivos[pokemon] = new List<Efecto>();
            }

            // Añade el efecto a la lista de efectos del Pokémon
            efectosActivos[pokemon].Add(efecto);

            // Inicia el efecto, lo que podría implicar acciones como mostrar un mensaje
            efecto.IniciarEfecto(pokemon);
        }

        /// <summary>
        /// Procesa los efectos que alteran el comportamiento del Pokémon (como dormir o paralizar).
        /// </summary>
        /// <param name="pokem">El Pokémon cuyo estado de efectos se va a procesar.</param>
        /// <returns>
        /// <c>true</c> si el efecto sigue activo (por ejemplo, sigue dormido o paralizado).
        /// <c>false</c> si el efecto ha terminado o no aplica.
        /// </returns>
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
                // Procesa efectos como dormir o paralizar
                if (v is EfectoDormir || v is EfectoParalizar)
                {
                    return v.ProcesarEfecto(pokem); // Devuelve si el efecto sigue activo
                }
            }

            return false; // Si no es un efecto de control como dormir o paralizar, retorna false
        }

        /// <summary>
        /// Procesa efectos de daño continuo (como veneno o quemadura) que afectan a la vida del Pokémon.
        /// </summary>
        public void ProcesarEfectosDaño()
        {
            // Recorre todos los efectos activos
            foreach (var entry in efectosActivos)
            {
                Pokemon pokemon = entry.Key;
                List<Efecto> efectos = entry.Value;

                // Recorre cada efecto y aplica los que son de daño continuo
                for (int i = efectos.Count - 1; i >= 0; i--)
                {
                    Efecto efecto = efectos[i];
                    if (efecto is EfectoEnvenenar || efecto is EfectoQuemar)
                    {
                        // Procesa el daño del efecto
                        efecto.ProcesarEfecto(pokemon);
                    }
                }
            }
        }

        /// <summary>
        /// Limpia todos los efectos activos de un Pokémon.
        /// </summary>
        /// <param name="pokemon">El Pokémon cuyo efecto se eliminará.</param>
        public void LimpiarEfectos(Pokemon pokemon)
        {
            // Elimina los efectos activos del Pokémon si existen
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

        /// <summary>
        /// Verifica si un Pokémon tiene efectos activos.
        /// </summary>
        /// <param name="pokemon">El Pokémon a verificar.</param>
        /// <returns><c>true</c> si el Pokémon tiene efectos activos, <c>false</c> si no.</returns>
        public bool PokemonConEfecto(Pokemon pokemon)
        {
            return efectosActivos.ContainsKey(pokemon);
        }
    }
}