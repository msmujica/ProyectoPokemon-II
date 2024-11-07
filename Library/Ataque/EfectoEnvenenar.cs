using System;

namespace Library;

public class EfectoEnvenenar : Efecto
{
    private double porcentajeDaño = 0.05; // 5%

    public override void IniciarEfecto(Pokemon pokemon)
    {
        Console.WriteLine($"{pokemon.Nombre} ha sido envenenado.");
    }

    public override bool ProcesarEfecto(Pokemon pokemon)
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