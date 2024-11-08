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
        gestorDeItems = new GestorDeItems(); 
    }

    public string elegirEquipo(int numero)
    {
        if (this.Equipo.Count >= 6)
        {
            return "Ya tienes la cantidad maxima de Pokemones en tu Equipo";
        }
        Pokedex.CrearPokemonPorIndice(numero, this);
        return "Vuelve a ejecutar el mismo comando para poder empezar la batalla";
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

    public void elegirAtaque(string nombre, Pokemon oponente)
    {
        this.activo.atacar(oponente, nombre);
    }

    public void UsarItem(string nombreItem, Pokemon pokemon)
    {
        switch (nombreItem)
        {
            case "Superpocion":
                gestorDeItems.UsarSuperPocion(pokemon, ContadorSuperPocion);
                break;
            case "Revivir":
                gestorDeItems.UsarRevivir(pokemon, ContadorRevivir);
                break;
            case "CuraTotal":
                gestorDeItems.UsarCuraTotal(pokemon, ContadorCuraTotal);
                break;
            default:
                Console.WriteLine("Ítem no válido.");
                break;
        }
    }

    public void CambioPokemonMuerto()
    {
        int count = 0;
        foreach (var pok in this.Equipo)
        {
            if (pok.Vida > 0)
            {
                this.Activo = pok;
            }
        }

    }

    public void SeteodeItems()
    {
        this.ContadorSuperPocion = 4;
        this.ContadorCuraTotal = 2;
        this.ContadorRevivir = 1;
    }
}