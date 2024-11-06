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
    }

    public void Atacar()
    {
        
    }

    public void UsarItem()
    {
        int opcionItem = 0;
        bool esValidaItem = false;
        
        Console.WriteLine($"Elige que tipo de item quieres usar:" +
                          $"Elejir 1 para Super Pocion: {this.TurnoActual.ContadorSuperPocion} usos restantes" +
                          $"Elejir 2 para Revivir: {this.TurnoActual.ContadorRevivir} usos restantes" +
                          $"Elejir 3 para Cura Total: {this.TurnoActual.ContadorCuraTotal} usos restantes");
        esValidaItem = int.TryParse(Console.ReadLine(), out opcionItem);
        
        switch (opcionItem)
        {
            case 1:
                Console.WriteLine("Has elegido la opción 1.");
                // Agrega lo que quieras hacer si elige 1
                break;
            case 2:
                Console.WriteLine("Has elegido la opción 2.");
                // Agrega lo que quieras hacer si elige 2
                break;
            case 3:
                Console.WriteLine("Has elegido la opción 3.");
                // Agrega lo que quieras hacer si elige 3
                break;
        }
        
    }

    public void CambiarTurno()
    {
        if (this.TurnoActual == Player1)
        {
            this.TurnoActual = Player2;
        }
        else
        {
            this.TurnoActual = Player1;
        }
    }
}
