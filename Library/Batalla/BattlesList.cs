using System.Collections.Generic;
using Library;

namespace Ucu.Poo.DiscordBot.Domain;

/// <summary>
/// Esta clase representa la lista de batallas en curso.
/// </summary>
public class BattlesList
{
    private List<Battle> battles = new List<Battle>();

    /// <summary>
    /// Crea una nueva batalla entre dos jugadores.
    /// </summary>
    /// <param name="player1">El primer jugador.</param>
    /// <param name="player2">El oponente.</param>
    /// <returns>La batalla creada.</returns>
    public Battle AddBattle(Entrenador player1, Entrenador player2)
    {
        var battle = new Battle(player1, player2);
        this.battles.Add(battle);
        return battle;
    }
    
    public Entrenador? FindTrainerByDisplayName(string displayName)
    {
        foreach (Battle batlle in this.battles)
        {
            if (batlle.Player1.Nombre == displayName)
            {
                return batlle.Player1;
            }

            if (batlle.Player2.Nombre == displayName)
            {
                return batlle.Player2;
            }
        }

        return null;
    }
    
    public Battle? FindBattleByDisplayName(string displayName)
    {
        foreach (Battle batlle in this.battles)
        {
            if (batlle.Player1.Nombre == displayName)
            {
                return batlle;
            }

            if (batlle.Player2.Nombre == displayName)
            {
                return batlle;
            }
        }

        return null;
    }
}
