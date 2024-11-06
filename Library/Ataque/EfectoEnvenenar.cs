using System;

namespace Library;

public static class EfectoEnvenenar
{
    private static double porcentajeDaño = 0.05; // 5%

    public static void IniciarEfecto(Pokemon pokemon)
    {
        Console.WriteLine($"{pokemon.Nombre} ha sido envenenado.");
    }

    public static bool ProcesarEfecto(Pokemon pokemon)
    {
        int daño = (int)(pokemon.Vida * porcentajeDaño);
        pokemon.Vida -= daño;
            
        if (pokemon.Vida <= 0)
        { 
            return false; // El efecto ha terminado
        }
        return true; // El efecto continúa
    }
}