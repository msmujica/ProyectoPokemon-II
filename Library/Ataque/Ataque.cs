using System;
using System.Collections.Generic;

namespace Library;

public class Ataque
{
    private string nombre;
    private int daño;
    private Tipos tipo;
    
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public int Daño
    {
        get { return daño; }
        set { daño = value; }
    }

    public Tipos Tipos
    {
        get { return tipo; }
        set { tipo = value; }
    }

    public Ataque(string nombre, int daño, Tipos tipo)
    {
        this.Nombre = nombre;
        this.Daño = daño;
        this.Tipos = tipo;
    }
    
    public int CalcularDaño(Pokemon objetivo)
    {
        if (EsPreciso())
        {
            int dañoTotal = this.Daño;
            if (EsCritico())
                dañoTotal = (int)(Daño * 1.2); // Aumenta el daño en un 20% si es crítico;

            double multiplicador;
            multiplicador = objetivo.Tipos.multiplicadorDaño(this.Tipos); // Usar el tipo del ataque contra el tipo del objetivo

            // Aplica el daño total considerando el multiplicador
            dañoTotal = (int)(dañoTotal * multiplicador);
            
            // Intenta aplicar un efecto especial con una probabilidad fija del 10%
            if (AplicaEfectoEspecial())
            {
                Efecto efectoEspecial = SeleccionarEfectoEspecial();
                GestorEfectos.AplicarEfecto(efectoEspecial, objetivo);
            }

            return dañoTotal;
        }

        return 0;
    }

    public bool EsPreciso()
    {
        return new Random().NextDouble() <= 0.7; // Probabilidad fija de 70% para precisión
    }

    public bool EsCritico()
    {
        return new Random().NextDouble() <= 0.1; // 10% de probabilidad de crítico
    }

    public bool AplicaEfectoEspecial()
    {
        return new Random().NextDouble() <= 0.1; // Probabilidad fija del 10%
    }

    public Efecto SeleccionarEfectoEspecial()
    {
        // Selecciona un efecto especial aleatorio
        int efecto = new Random().Next(1, 5);

        switch (efecto)
        {
            case 1:
                return new EfectoDormir();
            case 2:
                return new EfectoParalizar();
            case 3:
                return new EfectoEnvenenar();
            case 4:
                return new EfectoQuemar();
        }

        return null;
    }
}