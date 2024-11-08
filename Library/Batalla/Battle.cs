using System;
using Library;
using Library.Items;

namespace Ucu.Poo.DiscordBot.Domain;

/// <summary>
/// Esta clase representa una batalla entre dos jugadores.
/// </summary>
public class Battle
{
    /// <summary>
    /// Obtiene un valor que representa el primer jugador.
    /// </summary>
    public Entrenador Player1 { get; }

    /// <summary>
    /// Obtiene un valor que representa al oponente.
    /// </summary>
    public Entrenador Player2 { get; }

    private Entrenador turnoActual;
    private Entrenador turnoPasado;

    public Entrenador TurnoActual
    {
        get { return turnoActual; }
        set { turnoActual = value; }
    }
    public Entrenador TurnoPasado
    {
        get { return turnoPasado; }
        set { turnoPasado = value; }
    }

    public bool Actuo { get; set; }


    /// <summary>
    /// Inicializa una instancia de la clase <see cref="Battle"/> con los
    /// valores recibidos como argumento.
    /// </summary>
    /// <param name="player1">El primer jugador.</param>
    /// <param name="player2">El oponente.</param>
    public Battle(Entrenador player1, Entrenador player2)
    {
        this.Player1 = player1;
        this.Player2 = player2;
        this.TurnoActual = player1;
        this.TurnoPasado = player2;
        player1.SeteodeItems();
        player2.SeteodeItems();
        this.Actuo = false;
    }

    public bool validacionPokemon()
    {
        if (this.Player1.Equipo.Count < 6)
        {
            return true;
        }

        if (this.Player2.Equipo.Count < 6)
        {
            return true;
        }

        return false;
    }


    public string IntermediarioAtacar(string opcionAtaque)
    {
        if (validacionPokemon())
        {
            return "No tenes los pokemones suficientes para empezar la batalla";
        }
        
        if (this.Actuo)
        {
            return "Ya realizaste una acción este turno.";
        }
        try
        {
            // Cambiar el Pokémon activo
            this.TurnoActual.elegirAtaque(opcionAtaque, this.TurnoPasado.Activo);

            // Marcar que se realizó una acción en este turno
            this.Actuo = true;
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada inválida. Asegúrate de ingresar el nombre correcto.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error: {ex.Message}");
        }

        return "El ataque se a realizado con exito";
    }

    public string IntermediarioCambiarPokemonActivo(int opcionPokemon)
    {
        if (validacionPokemon())
        {
            return "No tenes los pokemones suficientes para empezar la batalla";
        }
        
        if (this.Actuo)
        {
            return "Ya realizaste una acción este turno.";
        }

        try
        {
            // Verificar si el índice del Pokémon está en el rango
            if (opcionPokemon < 0 || opcionPokemon >= this.TurnoActual.Equipo.Count)
            {
                return "Selección de Pokémon inválida. Por favor, intenta de nuevo.";
            }

            // Cambiar el Pokémon activo
            this.TurnoActual.cambiarActivo(opcionPokemon);
            Console.WriteLine(
                $"Has cambiado a {this.TurnoActual.Equipo[opcionPokemon].Nombre} como el Pokémon activo.");

            // Marcar que se realizó una acción en este turno
            this.Actuo = true;
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada inválida. Asegúrate de ingresar un número.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error: {ex.Message}");
        }

        return "Hecho";
    }


    public string IntermediarioUsarItem(int opcionPokemon, string opcionItem)
    {
        if (validacionPokemon())
        {
            return "No tenes los pokemones suficientes para empezar la batalla";
        }
        
        if (this.Actuo)
        {
            return "Ya realizaste una acción este turno.";
        }

        try
        {
            // Verificar si el índice del Pokémon está en el rango
            if (opcionPokemon < 0 || opcionPokemon >= this.TurnoActual.Equipo.Count)
            {
                return "Selección de Pokémon inválida.";
            }

            Pokemon pokemonSeleccionado = this.TurnoActual.Equipo[opcionPokemon];

            // Aplicar el ítem seleccionado al Pokémon
            
                    this.TurnoActual.UsarItem(opcionItem, pokemonSeleccionado);
                    this.Actuo = true;

        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada inválida. Asegúrate de ingresar un número.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error: {ex.Message}");
        }

        return "Hecho";
    }


    public void CambiarTurno()
    {
        // Resetear el estado de acción al cambiar de turno
        this.Actuo = false;

        // Cambiar al otro jugador
        this.TurnoActual = (this.TurnoActual == Player1) ? Player2 : Player1;
        this.TurnoPasado = (this.TurnoPasado == Player2) ? Player1 : Player2;

        Console.WriteLine($"Es el turno de {this.TurnoActual.Nombre}");
    }
}

