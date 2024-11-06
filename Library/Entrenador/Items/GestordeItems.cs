using System;

namespace Library.Items
{
    public class GestorDeItems
    {
        // Método para usar una SuperPocion
        public void UsarSuperPocion(Pokemon pokemon, int contadorSuperPocion)
        {
            if (contadorSuperPocion > 0)
            {
                if (pokemon.Vida < 100)
                {
                    pokemon.Vida += 70;
                    if (pokemon.Vida > 100)
                        pokemon.Vida = 100; // No superar el 100%
                    contadorSuperPocion--;
                    Console.WriteLine("Usaste una Super Pocion. Usos restantes: " + contadorSuperPocion);
                }
                else
                {
                    Console.WriteLine("El Pokémon ya está a máxima vida.");
                }
            }
            else
            {
                Console.WriteLine("No tienes Super Pociones disponibles.");
            }
        }

        // Método para usar un Revivir
        public void UsarRevivir(Pokemon pokemon, int contadorRevivir)
        {
            if (contadorRevivir > 0)
            {
                if (pokemon.EstaDerrotado)
                {
                    pokemon.EstaDerrotado = false;
                    pokemon.Vida = 50; // Revive con 50% de vida
                    contadorRevivir--;
                    Console.WriteLine("Usaste un Revivir. Usos restantes: " + contadorRevivir);
                }
                else
                {
                    Console.WriteLine("El Pokémon no está derrotado.");
                }
            }
            else
            {
                Console.WriteLine("No tienes Revivir disponible.");
            }
        }

        // Método para usar una CuraTotal
        public void UsarCuraTotal(Pokemon pokemon, int contadorCuraTotal)
        {
            if (contadorCuraTotal > 0)
            {
                pokemon.Vida = 100; // Cura completamente al Pokémon
                contadorCuraTotal--;
                Console.WriteLine("Usaste una Cura Total. Usos restantes: " + contadorCuraTotal);
            }
            else
            {
                Console.WriteLine("No tienes Curaciones Totales disponibles.");
            }
        }
    }
}
