using System;
using System.Collections.Generic;
using Library.Items;

namespace Library;

public class Entrenador
{
    private string nombre;
    private List<Pokemon> equipo;
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
    public int ContadorSuperPocion { get; set; }
    public int ContadorRevivir { get; set; }
    public int ContadorCuraTotal { get; set; }
    private GestorDeItems gestorDeItems;


    public Entrenador(string nombre)
    {
        this.Nombre = nombre;
        this.Equipo = new List<Pokemon>();
        this.Activo = null;
        gestorDeItems = new GestorDeItems(); // Inicialización del gestor de ítems
    }

    public void elegirEquipo(int numero)
    {
            Pokemon seleccion = Pokedex.obtenerPokemonPorIndice(numero);

            this.Equipo.Add(seleccion);
            this.Activo = seleccion;
    }

    public void MostrarmiPokedex()
    {
        int numero = 0;
        Console.WriteLine("Lista de Pokemones en tu Pokedex");
        foreach (var lista in this.Equipo)
        {
            Console.WriteLine($"{numero} - {lista.Nombre}");
            numero += 1;
        }
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

    public void elegirAtaque(int indexAtaque, Pokemon oponente)
    {
        Ataque ataqueElegido;
        ataqueElegido = this.activo.Ataques[indexAtaque];
        this.activo.atacar(oponente, ataqueElegido);
    }
    public void UsarSuperPocion(Pokemon pokemon)
    {
        gestorDeItems.UsarSuperPocion(pokemon, this.ContadorSuperPocion);
    }

    public void UsarRevivir(Pokemon pokemon)
    {
        gestorDeItems.UsarRevivir(pokemon, this.ContadorRevivir);
    }

    public void UsarCuraTotal(Pokemon pokemon)
    {
        gestorDeItems.UsarCuraTotal(pokemon, this.ContadorCuraTotal);
    }

    public void SeteodeItems()
    {
        this.ContadorSuperPocion = 4;
        this.ContadorCuraTotal = 2;
        this.ContadorRevivir = 1;
    }
}