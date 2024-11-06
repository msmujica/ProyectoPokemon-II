using System;

namespace Library;

public class EfectoQuemar : Efecto
{
    private static double porcentajeDaño = 0.10; // 10%

    public override void IniciarEfecto(Pokemon pokemon)
    {
        Console.WriteLine($"{pokemon.Nombre} ha sido quemado.");
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