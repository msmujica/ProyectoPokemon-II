using System;
using System.Collections.Generic;

namespace Library;

public class Pokedex
{
    private static List<Pokemon> listaPokemones = new List<Pokemon>();
    
    public static List<Pokemon> ListaPokemons
    {
        get { return listaPokemones; }
    }

    public static void agregarPokemon(Pokemon pokemon)
    {
        listaPokemones.Add(pokemon);
    }

    public static void mostrarPokedex()
    {
        int numero = 0;
        Console.WriteLine("Lista de Pokemones en la Pokedex");
        foreach (var lista in listaPokemones)
        {
            Console.WriteLine($"{numero} - {lista.Nombre}");
            numero += 1;
        }
    }

    public static Pokemon obtenerPokemonPorIndice(int indice)
    {
        if (indice >= 0 && indice < listaPokemones.Count)
        {
            return listaPokemones[indice];
        }
        else
        {
            Console.WriteLine("Indice Invalido");
            return null;
        }
    }

    public static void eliminarPokemon(Pokemon pokemon)
    {
        listaPokemones.Remove(pokemon);
    }
}