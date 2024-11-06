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

    public Entrenador TurnoActual
    {
        get { return turnoActual; }
        set { turnoActual = value; }
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
        player1.SeteodeItems();
        player2.SeteodeItems();
        this.Actuo = false;
    }

    public void Atacar()
    {

    }

    public void CambiarPokemonActivo()
    {
        if (this.Actuo)
        {
            Console.WriteLine("Ya realizaste una acción este turno.");
            return;
        }

        try
        {
            // Mostrar el equipo del entrenador actual
            Console.WriteLine("Elige el Pokémon en tu equipo para cambiar como el Pokémon activo:");
            this.TurnoActual.MostrarmiPokedex();

            int opcionPokemon = int.Parse(Console.ReadLine());

            // Verificar si el índice del Pokémon está en el rango
            if (opcionPokemon < 0 || opcionPokemon >= this.TurnoActual.Equipo.Count)
            {
                Console.WriteLine("Selección de Pokémon inválida. Por favor, intenta de nuevo.");
                return;
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
    }


    public void UsarItem()
    {
        int opcionItem;
        int opcionPokemon;

        if (this.Actuo)
        {
            Console.WriteLine("Ya realizaste una acción este turno.");
            return;
        }

        try
        {
            // Mostrar opciones de ítems, incluyendo la opción de salir
            Console.WriteLine("Elige qué tipo de ítem quieres usar o ingresa 0 para salir:");
            Console.WriteLine($"1 - Super Poción ({this.TurnoActual.ContadorSuperPocion} usos restantes)");
            Console.WriteLine($"2 - Revivir ({this.TurnoActual.ContadorRevivir} usos restantes)");
            Console.WriteLine($"3 - Cura Total ({this.TurnoActual.ContadorCuraTotal} usos restantes)");
            Console.WriteLine("0 - Salir");

            // Leer elección del usuario para el ítem
            opcionItem = int.Parse(Console.ReadLine());

            // Comprobar si el usuario eligió salir
            if (opcionItem == 0)
            {
                Console.WriteLine("Has decidido no usar un ítem.");
                return;
            }

            // Mostrar el equipo del entrenador actual
            Console.WriteLine("Elige el Pokémon en tu equipo al que quieres aplicar el ítem:");
            this.TurnoActual.MostrarmiPokedex();
            opcionPokemon = int.Parse(Console.ReadLine());

            // Verificar si el índice del Pokémon está en el rango
            if (opcionPokemon < 0 || opcionPokemon >= this.TurnoActual.Equipo.Count)
            {
                Console.WriteLine("Selección de Pokémon inválida.");
                return;
            }

            Pokemon pokemonSeleccionado = this.TurnoActual.Equipo[opcionPokemon];

            // Aplicar el ítem seleccionado al Pokémon
            switch (opcionItem)
            {
                case 1:
                    Console.WriteLine("Usando Super Poción...");
                    this.TurnoActual.UsarSuperPocion(pokemonSeleccionado);
                    this.Actuo = true; // Marcamos que ha usado un ítem
                    break;
                case 2:
                    Console.WriteLine("Usando Revivir...");
                    this.TurnoActual.UsarRevivir(pokemonSeleccionado);
                    this.Actuo = true;
                    break;
                case 3:
                    Console.WriteLine("Usando Cura Total...");
                    this.TurnoActual.UsarCuraTotal(pokemonSeleccionado);
                    this.Actuo = true;
                    break;
                default:
                    Console.WriteLine("Opción de ítem no válida.");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada inválida. Asegúrate de ingresar un número.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error: {ex.Message}");
        }
    }


    public void CambiarTurno()
    {
        // Resetear el estado de acción al cambiar de turno
        this.Actuo = false;

        // Cambiar al otro jugador
        this.TurnoActual = (this.TurnoActual == Player1) ? Player2 : Player1;

        Console.WriteLine($"Es el turno de {this.TurnoActual.Nombre}");
    }
}

