using System;
using Ucu.Poo.DiscordBot.Domain;

class Program
{
    static void Main()
    {

        var facade = Facade.Instance;


        string player1 = "Ash";
        string player2 = "Misty";

        Console.WriteLine(facade.AddTrainerToWaitingList(player1));
        Console.WriteLine(facade.AddTrainerToWaitingList(player2));
        
        Console.WriteLine(facade.StartBattle(player1, player2));
        
        Console.WriteLine(facade.ChooseTeam(player1, 1));
        Console.WriteLine(facade.ChooseTeam(player1, 2));
        Console.WriteLine(facade.ChooseTeam(player1, 3));
        Console.WriteLine(facade.ChooseTeam(player1, 4));
        Console.WriteLine(facade.ChooseTeam(player1, 5));
        Console.WriteLine(facade.ChooseTeam(player1, 6));
        
        Console.WriteLine(facade.ChooseTeam(player2, 1));
        Console.WriteLine(facade.ChooseTeam(player2, 2));
        Console.WriteLine(facade.ChooseTeam(player2, 3));
        Console.WriteLine(facade.ChooseTeam(player2, 4));
        Console.WriteLine(facade.ChooseTeam(player2, 5));
        Console.WriteLine(facade.ChooseTeam(player2, 6));
        
        Console.WriteLine(facade.AttackPokemon(player1, "Picadura"));
        Console.WriteLine(facade.AttackPokemon(player2, "Pistola Agua"));
        
        Console.WriteLine(facade.ShowEnemiesPokemon(player2));
        
        Console.WriteLine(facade.UseItem(player1, 0, "Revivir"));
        
       Console.WriteLine(facade.GetPokemonAtacks(player2));
       
       Console.WriteLine(facade.ChangePokemon(player1, 3));
       
       
    }
}
