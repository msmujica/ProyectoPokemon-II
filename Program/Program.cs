using System;
using Ucu.Poo.DiscordBot.Domain;  // Asegúrate de incluir la referencia correcta a tu dominio

class Program
{
    static void Main()
    {
        // 1. Obtenemos la instancia única de Facade
        var facade = Facade.Instance;

        // 2. Creamos dos jugadores (entrenadores)
        string player1 = "Ash";
        string player2 = "Misty";

        // 3. Agregamos a ambos jugadores a la lista de espera
        Console.WriteLine(facade.AddTrainerToWaitingList(player1));  // Ash agregado a la lista de espera
        Console.WriteLine(facade.AddTrainerToWaitingList(player2));  // Misty agregado a la lista de espera

        // 5. Comenzamos una batalla entre los dos jugadores
        Console.WriteLine(facade.StartBattle(player1, player2));  // Comienza Ash vs Misty

      //  Console.WriteLine(facade.ShowPokémonAvailable());
        
        // 6. Elegimos el equipo de Ash (Por ejemplo, el Pokémon en el índice 1)
        Console.WriteLine(facade.ChooseTeam(player1, 1));  // El pokemon <nombre_pokemon> seleccionado para Ash.
        Console.WriteLine(facade.ChooseTeam(player1, 2));
        Console.WriteLine(facade.ChooseTeam(player1, 3));
        Console.WriteLine(facade.ChooseTeam(player1, 4));
        Console.WriteLine(facade.ChooseTeam(player1, 5));
        Console.WriteLine(facade.ChooseTeam(player1, 6));
        
        Console.WriteLine(facade.ChooseTeam(player2, 1));  // El pokemon <nombre_pokemon> seleccionado para Ash.
        Console.WriteLine(facade.ChooseTeam(player2, 2));
        Console.WriteLine(facade.ChooseTeam(player2, 3));
        Console.WriteLine(facade.ChooseTeam(player2, 4));
        Console.WriteLine(facade.ChooseTeam(player2, 5));
        Console.WriteLine(facade.ChooseTeam(player2, 6));
        
        Console.WriteLine(facade.AttackPokemon(player1, "Picadura"));
       // Console.WriteLine(facade.AttackPokemon(player2, "Pistola Agua"));
       // Console.WriteLine(facade.ShowEnemiesPokemon(player2));
       Console.WriteLine(facade.UseItem(player2, 0, "Revivir"));
        
       Console.WriteLine(facade.GetPokemonAtacks(player2));
       Console.WriteLine(facade.ChangePokemon(player1, 3));
       //Console.WriteLine(facade.ShowPokémonAvailable());
       
    }
}
