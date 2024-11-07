using System;
using System.Collections.Generic;

namespace Library;

public class Pokemon
{
    private string nombre;
    private int vida;
    private List<string> ataques;
    private string tipo;
    private bool estaDerrotado;

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public int Vida
    {
        get { return vida; }
        set { vida = value; }
    }

    public List<string> Ataques
    {
        get { return ataques; }
        set { ataques = value; }
    }

    public string Tipos
    {
        get { return tipo; }
        set { tipo = value; }
    }

    public bool EstaDerrotado
    {
        get { return estaDerrotado; }
        set { estaDerrotado = value; }
    }

    public Pokemon(string nombre, int vida, List<string> ataques, string tipo)
    {
        this.Nombre = nombre;
        this.Vida = vida;
        this.Ataques = ataques;
        this.Tipos = tipo;
        this.EstaDerrotado = false;
    }

    public void recibirDaño(int daño)
    {
        if (!this.EstaDerrotado)
        {
            this.Vida -= daño;
            if (this.Vida <= 0)
            {
                this.EstaDerrotado = true;
                this.Vida = 0;
                Console.WriteLine($"{this.Nombre} a sido derrotado");
            }
        }
        else
        {
            Console.WriteLine($"{this.Nombre} no puede recibir daño por que ya a sido derrotado");
        }
    }

    public void atacar(Pokemon oponente, string ataque)
    {
        int valor = Ataque.CalcularDaño(ataque, oponente);
        oponente.recibirDaño(valor);
    }
}