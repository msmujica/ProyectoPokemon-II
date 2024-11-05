using System;

namespace Library;

public class EfectoParalizar
{
  
    public static void IniciarEfecto(Pokemon pokemon)
    {
    }

    public static bool ProcesarEfecto(Pokemon pokemon)
    {
        return true;
    }

    public bool PuedeAtacar()
    {
        // Genera un número aleatorio para determinar si puede atacar (70% de probabilidad de atacar)
        return new Random().NextDouble() > 0.3;
    }
}