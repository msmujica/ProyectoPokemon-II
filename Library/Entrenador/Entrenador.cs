using System;
using System.Collections.Generic;
using Library.Items;

namespace Library;

public class Entrenador
{
    private string nombre;
    private List<Pokemon> equipo;
    private List<IItem> items;
    private Pokemon activo;

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public List<Pokemon> Equipo
    {
        get { return equipo; }
        set { equipo = value; }
    }

    public Pokemon Activo
    {
        get { return activo; }
        set { activo = value; }
    }

    public Entrenador(string nombre)
    {
        this.Nombre = nombre;
        this.Equipo = new List<Pokemon>();
        this.Activo = null;
    }

    public void elegirEquipo(int numero)
    {
            Pokemon seleccion = Pokedex.obtenerPokemonPorIndice(numero);

            this.Equipo.Add(seleccion);
            this.Activo = seleccion;

    }

    public void cambiarActivo(int indexPokemonList)
    {
        if (indexPokemonList >= 0 && indexPokemonList < this.Equipo.Count)
        {
            this.Activo = this.Equipo[indexPokemonList];
        }
        else
        {
            Console.WriteLine("Indice no valido. No se pudo cambiar el pokemon");
        }
    }

    public void UsarItem(IItem item, Pokemon pokemon)
    {if (item.Contador > 0)
        {
            if ((item is ItemRevivir && pokemon.EstaDerrotado) || (!(item is ItemRevivir) && !pokemon.EstaDerrotado))
            {
                item.Usar(pokemon);
            }
        }
    }

    public void elegirAtaque(int indexAtaque, Pokemon oponente)
    {
        Ataque ataqueElegido;
        ataqueElegido = this.activo.Ataques[indexAtaque];
        this.activo.atacar(oponente, ataqueElegido);
    }
}