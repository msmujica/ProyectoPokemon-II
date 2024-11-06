using System;
using System.Collections.Generic;

namespace Library;

public class Pokemon
{
    private string nombre;
    private int vida;
    private List<Ataque> ataques;
    private Tipos tipos;
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

    public List<Ataque> Ataques
    {
        get { return ataques; }
        set { ataques = value; }
    }

    public Tipos Tipos
    {
        get { return tipos; }
        set { tipos = value; }
    }

    public bool EstaDerrotado { get; set; }
    public bool EstaVivo
    {
        get { return !estaDerrotado; }
        
    }

    public Pokemon(string nombre, int vida, List<Ataque> ataques, Tipos tipos)
    {
        this.Nombre = nombre;
        this.Vida = vida;
        this.Ataques = ataques;
        this.Tipos = tipos;
        this.EstaDerrotado = false;
        
        Pokedex.agregarPokemon(this);
    }

    public void recibirDaño(int daño)
    {
        if (EstaVivo)
        {
            Vida -= daño;
            if (Vida <= 0)
            {
                Console.WriteLine($"{this.Nombre} a sido derrotado");
            }
        }
        else
        {
            Console.WriteLine($"{this.Nombre} no puede recibir daño por que ya a sido derrotado");
        }
    }

    public void atacar(Pokemon oponente, Ataque ataque)
    {
        if (EstaVivo)
        { 
            int dañoSubdito = ataque.CalcularDaño(oponente);
        
            oponente.recibirDaño(dañoSubdito);
            
        }
        else
        {
            Console.WriteLine($"{this.nombre} no puede ataquar porqur a sido derrotado");
        }
    }
}