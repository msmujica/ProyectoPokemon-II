using System;

namespace Library;

public class EfectoDormir : Efecto
{
    private int turnosDormidos;

    public void IniciarEfecto(Pokemon pokemon)
    {
        turnosDormidos = new Random().Next(1, 5); // Determina cuántos turnos dormirá
        Console.WriteLine($"{pokemon.Nombre} ha sido dormido por {turnosDormidos} turnos.");
    }

    public bool ProcesarEfecto(Pokemon pokemon)
    {
        if (turnosDormidos > 0)
        {
            turnosDormidos--;
            if (turnosDormidos == 0)
            {
                Console.WriteLine($"{pokemon.Nombre} ha despertado.");
                return false; // El efecto ha terminado
            }
            return true; // El efecto continúa
        }
        return false; // El efecto ha terminado
    }
}