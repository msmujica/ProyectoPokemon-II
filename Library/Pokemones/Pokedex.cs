using System;
using System.Collections.Generic;

namespace Library;

public static class Pokedex
{
    private static List<string> nombresPokemon = new List<string>
    {
        "Squirtle", // Agua
        "Caterpie", // Bicho
        "Dratini", // Dragón
        "Pikachu", // Eléctrico
        "Gastly", // Fantasma
        "Charmander", // Fuego
        "Jynx", // Hielo
        "Machop", // Lucha
        "Eevee", // Normal
        "Bulbasaur", // Planta
        "Abra", // Psíquico
        "Geodude", // Roca
        "Diglett", // Tierra
        "Ekans", // Veneno
        "Pidgey" // Volador
    };

    private static List<string> tiposPokemon = new List<string>
    {
        "Agua",
        "Bicho",
        "Dragón",
        "Eléctrico",
        "Fantasma",
        "Fuego",
        "Hielo",
        "Lucha",
        "Normal",
        "Planta",
        "Psíquico",
        "Roca",
        "Tierra",
        "Veneno",
        "Volador"
    };

    public static string MostrarPokemonPorIndice(int indice)
    {
        return nombresPokemon[indice];
    }

    public static List<string> MostrarPokedex()
    {
        List<string> pokedexList = new List<string>();
        for (int i = 0; i < nombresPokemon.Count; i++)
        {
            pokedexList.Add($"{i} - {nombresPokemon[i]} ({tiposPokemon[i]})");
        }

        return pokedexList;
    }

    public static Pokemon CrearPokemonPorIndice(int indice, Entrenador entrenador)
    {
        int vidaInicial = 100;
        Pokemon nuevoPokemon = null;

        switch (indice)
        {
            case 0:
                nuevoPokemon = new Pokemon("Squirtle", vidaInicial, new List<string> { "Pistola Agua", "Hidrobomba", "Burbuja" }, "Agua");
                break;
            case 1:
                nuevoPokemon = new Pokemon("Caterpie", vidaInicial, new List<string> { "Picadura", "Pulso Bicho", "Tijera X" }, "Bicho");
                break;
            case 2:
                nuevoPokemon = new Pokemon("Dratini", vidaInicial, new List<string> { "Garra Dragón", "Cometa Draco", "Aliento Dragón" }, "Dragón");
                break;
            case 3:
                nuevoPokemon = new Pokemon("Pikachu", vidaInicial, new List<string> { "Impactrueno", "Rayo", "Trueno" }, "Eléctrico");
                break;
            case 4:
                nuevoPokemon = new Pokemon("Gastly", vidaInicial, new List<string> { "Bola Sombra", "Puño Spectral", "Puño Sombrío" }, "Fantasma");
                break;
            case 5:
                nuevoPokemon = new Pokemon("Charmander", vidaInicial, new List<string> { "Llamarada", "Lanzallamas", "Ascuas" }, "Fuego");
                break;
            case 6:
                nuevoPokemon = new Pokemon("Jynx", vidaInicial, new List<string> { "Rayo Hielo", "Ventisca", "Nieve Polvo" }, "Hielo");
                break;
            case 7:
                nuevoPokemon = new Pokemon("Machop", vidaInicial, new List<string> { "Golpe Karate", "A Bocajarro", "Puño Dinámico" }, "Lucha");
                break;
            case 8:
                nuevoPokemon = new Pokemon("Eevee", vidaInicial, new List<string> { "Tackle", "Puño Sombra", "Desenlace" }, "Normal");
                break;
            case 9:
                nuevoPokemon = new Pokemon("Bulbasaur", vidaInicial, new List<string> { "Hoja Afilada", "Látigo Cepa", "Rayo Solar" }, "Planta");
                break;
            case 10:
                nuevoPokemon = new Pokemon("Abra", vidaInicial, new List<string> { "Confusión", "Psíquico", "Premonición" }, "Psíquico");
                break;
            case 11:
                nuevoPokemon = new Pokemon("Geodude", vidaInicial, new List<string> { "Avalancha", "Lanzarrocas", "Roca Afilada" }, "Roca");
                break;
            case 12:
                nuevoPokemon = new Pokemon("Diglett", vidaInicial, new List<string> { "Terremoto", "Excavar", "Bofetón Lodo" }, "Tierra");
                break;
            case 13:
                nuevoPokemon = new Pokemon("Ekans", vidaInicial, new List<string> { "Ácido", "Bomba Lodo", "Cola Veneno" }, "Veneno");
                break;
            case 14:
                nuevoPokemon = new Pokemon("Pidgey", vidaInicial, new List<string> { "Tornado", "Ala de Acero", "Ataque Aéreo" }, "Volador");
                break;
            default:
                Console.WriteLine("Índice inválido.");
                return null;
        }

        if (nuevoPokemon != null)
        {
            entrenador.Equipo.Add(nuevoPokemon);
            if (entrenador.Activo == null)
            {
                entrenador.Activo = nuevoPokemon;
            }
        }

        return nuevoPokemon;
    }

}