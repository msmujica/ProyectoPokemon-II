using System;

namespace Library;

public class EfectoParalizar
{
  
    public static void IniciarEfecto(Pokemon pokemon)
    {
        Console.WriteLine($"{pokemon.Nombre} ha sido paralizado");
    }

    public static bool ProcesarEfecto(Pokemon pokemon)
    {
        if (PuedeAtacar())
        {
            Console.WriteLine($"{pokemon.Nombre} supera la paralisis en este turno");
            return true;
        }
        else
        {
            Console.WriteLine($"{pokemon.Nombre} esta paralizado por este turno");
            return true;
        }
        
    }

    public bool PuedeAtacar()
    {
        // Genera un número aleatorio para determinar si puede atacar (70% de probabilidad de atacar)
        return new Random().NextDouble() > 0.3;
    }
}