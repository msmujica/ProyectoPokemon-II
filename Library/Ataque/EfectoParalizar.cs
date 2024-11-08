using System;

namespace Library
{
    public class EfectoParalizar : Efecto
    {
        public void IniciarEfecto(Pokemon pokemon)
        {
            Console.WriteLine($"{pokemon.Nombre} ha sido paralizado.");
        }

        public bool ProcesarEfecto(Pokemon pokemon)
        {
            if (PuedeAtacar())
            {
                Console.WriteLine($"{pokemon.Nombre} supera la parálisis en este turno.");
                return false; // El efecto continúa
            }
            else
            {
                Console.WriteLine($"{pokemon.Nombre} está paralizado y no puede atacar este turno.");
                return true; // El efecto continúa
            }
        }

        private bool PuedeAtacar()
        {
            // Genera un número aleatorio para determinar si puede atacar (70% de probabilidad de atacar)
            return new Random().NextDouble() > 0.3;
        }
    }
}