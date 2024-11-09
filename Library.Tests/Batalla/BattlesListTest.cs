using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ucu.Poo.DiscordBot.Domain;

namespace Library.Tests.Batalla;

[TestClass]
[TestSubject(typeof(BattlesList))]
public class BattlesListTest
{
    private BattlesList battlesList;
    private Entrenador player1;
    private Entrenador player2;
    
    [TestMethod]
    public void AgregarLista()
    {
        
        player1 = new Entrenador("Player1");
        player2 = new Entrenador("Player2");
        battlesList = new BattlesList();
        Battle battle = battlesList.AddBattle(player1, player2);

        // Assert
        Assert.IsNotNull(battle);
        Assert.AreEqual("Player1", battle.Player1.Nombre);
        Assert.AreEqual("Player2", battle.Player2.Nombre);
    }
    
    [TestMethod]
    public void BuscarEntrenadorPorDisplayName()
    {
        player1 = new Entrenador("Player1");
        player2 = new Entrenador("Player2");
        battlesList = new BattlesList();
        Battle battle = battlesList.AddBattle(player1, player2);

        // Act
        var result = battlesList.FindTrainerByDisplayName("Player1");

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(player1, result);
    }
}