using System;
using Library;
using Ucu.Poo.DiscordBot.Domain;

// Crea dos entrenadores
Entrenador Ash = new Entrenador("Ash");
Entrenador Misty = new Entrenador("Misty");

// Elige un Pokémon para cada uno
Ash.elegirEquipo(0);  // Squirtle (tipo Agua)
Misty.elegirEquipo(5); // Charmander (tipo Fuego)
Ash.SeteodeItems();
Misty.SeteodeItems();

// Muestra la vida inicial del Pokémon de Misty
Console.WriteLine($"Vida inicial de {Misty.Activo.Nombre}: {Misty.Activo.Vida}");

// Mostrar la vida de ambos Pokémon antes del combate
Console.WriteLine($"Vida de {Ash.Activo.Nombre}: {Ash.Activo.Vida}");
Console.WriteLine($"Vida de {Misty.Activo.Nombre}: {Misty.Activo.Vida}");
Console.WriteLine("----------------------------------------");

// Turno 1 - Ash ataca a Misty
Ash.elegirAtaque("Pistola Agua", Misty.Activo);  // Squirtle usa Pistola Agua
GestorEfectos.ProcesarEfectosTurno();
Console.WriteLine($"Vida de {Misty.Activo.Nombre} después del ataque de Ash: {Misty.Activo.Vida}");
Console.WriteLine("----------------------------------------");

// Turno 2 - Misty usa un objeto (Superpocion)
Misty.UsarItem("Superpocion", Misty.Activo);
Console.WriteLine($"Vida de {Misty.Activo.Nombre} después de usar Superpoción: {Misty.Activo.Vida}");
Console.WriteLine("----------------------------------------");


// Turno 1 - Ash ataca a Misty
Ash.elegirAtaque("Pistola Agua", Misty.Activo);  // Squirtle usa Pistola Agua
GestorEfectos.ProcesarEfectosTurno();
Console.WriteLine($"Vida de {Misty.Activo.Nombre} después del ataque de Ash: {Misty.Activo.Vida}");
Console.WriteLine("----------------------------------------");


// Mostrar la vida final después de varios turnos
Console.WriteLine($"Vida final de {Ash.Activo.Nombre}: {Ash.Activo.Vida}");
Console.WriteLine($"Vida final de {Misty.Activo.Nombre}: {Misty.Activo.Vida}");


Console.WriteLine(Facade.Instance.ShowPokémonAvailable());