using System;

namespace Library;

public class EfectoParalizar : Efecto
{
  
    public override void IniciarEfecto(Pokemon pokemon)
    {
    }

    public override bool ProcesarEfecto(Pokemon pokemon)
    {
        return true;
    }

    public bool PuedeAtacar()
    {
        // Genera un número aleatorio para determinar si puede atacar (70% de probabilidad de atacar)
        return new Random().NextDouble() > 0.3;
    }
}