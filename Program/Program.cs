using System;
using System.Collections.Generic;
using Library;
using Library.Items;

// Se crean Tipos
Tipos Agua = new Tipos("Agua");
Tipos Bicho = new Tipos("Bicho");
Tipos Dragón = new Tipos("Dragón");
Tipos Electrico = new Tipos("Electrico");
Tipos Fantasma = new Tipos("Fantasma");
Tipos Fuego = new Tipos("Fuego");
Tipos Hielo = new Tipos("Hielo");
Tipos Lucha = new Tipos("Lucha");
Tipos Normal = new Tipos("Normal");
Tipos Planta = new Tipos("Planta");
Tipos Psíquico = new Tipos("Psíquico");
Tipos Roca = new Tipos("Roca");
Tipos Tierra = new Tipos("Tierra");
Tipos Veneno = new Tipos("Veneno");
Tipos Volador = new Tipos("Volador");

// Agregar debilidades
Agua.AgregarDebilidades(new List<Tipos> { Electrico, Planta });
Bicho.AgregarDebilidades(new List<Tipos> { Fuego, Roca, Volador, Veneno });
Dragón.AgregarDebilidades(new List<Tipos> { Dragón, Hielo });
Electrico.AgregarDebilidades(new List<Tipos> { Tierra });
Fantasma.AgregarDebilidades(new List<Tipos> { Fantasma });
Fuego.AgregarDebilidades(new List<Tipos> { Agua, Roca, Tierra });
Hielo.AgregarDebilidades(new List<Tipos> { Fuego, Lucha, Roca });
Lucha.AgregarDebilidades(new List<Tipos> { Psíquico, Volador, Bicho, Roca });
Normal.AgregarDebilidades(new List<Tipos> { Lucha });
Planta.AgregarDebilidades(new List<Tipos> { Bicho, Fuego, Hielo, Veneno, Volador });
Psíquico.AgregarDebilidades(new List<Tipos> { Bicho, Lucha, Fantasma });
Roca.AgregarDebilidades(new List<Tipos> { Agua, Lucha, Planta, Tierra });
Tierra.AgregarDebilidades(new List<Tipos> { Agua, Hielo, Planta, Roca, Veneno });
Veneno.AgregarDebilidades(new List<Tipos> { Bicho, Psíquico, Tierra, Lucha, Planta });
Volador.AgregarDebilidades(new List<Tipos> { Electrico, Hielo, Roca });

// Agregar resistencias
Agua.AgregarResistencia(new List<Tipos> { Agua, Fuego, Hielo });
Bicho.AgregarResistencia(new List<Tipos> { Lucha, Planta, Tierra });
Dragón.AgregarResistencia(new List<Tipos> { Agua, Electrico, Fuego, Planta });
Electrico.AgregarResistencia(new List<Tipos> { Volador });
Fantasma.AgregarResistencia(new List<Tipos> { Veneno, Lucha, Normal });
Fuego.AgregarResistencia(new List<Tipos> { Bicho, Fuego, Planta });
Hielo.AgregarResistencia(new List<Tipos> { Hielo });
Lucha.AgregarResistencia(new List<Tipos> { });
Normal.AgregarResistencia(new List<Tipos> { });
Planta.AgregarResistencia(new List<Tipos> { Agua, Electrico, Planta, Tierra });
Psíquico.AgregarResistencia(new List<Tipos> { });
Roca.AgregarResistencia(new List<Tipos> { Fuego, Normal, Veneno, Volador });
Tierra.AgregarResistencia(new List<Tipos> { Electrico });
Veneno.AgregarResistencia(new List<Tipos> { Planta, Veneno });
Volador.AgregarResistencia(new List<Tipos> { Bicho, Lucha, Planta, Tierra });

// Agregar inmunidades
Agua.AgregarInmune(new List<Tipos> { });
Bicho.AgregarInmune(new List<Tipos> { });
Dragón.AgregarInmune(new List<Tipos> { });
Electrico.AgregarInmune(new List<Tipos> { Electrico });
Fantasma.AgregarInmune(new List<Tipos> { });
Fuego.AgregarInmune(new List<Tipos> { });
Hielo.AgregarInmune(new List<Tipos> { });
Lucha.AgregarInmune(new List<Tipos> { });
Normal.AgregarInmune(new List<Tipos> { Fantasma });
Planta.AgregarInmune(new List<Tipos> { });
Psíquico.AgregarInmune(new List<Tipos> { });
Roca.AgregarInmune(new List<Tipos> { });
Tierra.AgregarInmune(new List<Tipos> { });
Veneno.AgregarInmune(new List<Tipos> { });
Volador.AgregarInmune(new List<Tipos> { });

List<Ataque> ataquesPikachu = new List<Ataque>
{
    new Ataque("Impactrueno", 40, Electrico),
    new Ataque("Cola Férrea", 30, Normal)
};

List<Ataque> ataquesCharmander = new List<Ataque>
{
    new Ataque("Llamarada", 50, Fuego),
    new Ataque("Arañazo", 20, Normal)
};

GestorEfectos gestorEfectos = new GestorEfectos();

Pokemon pikachu = new Pokemon("Pikachu", 100, ataquesPikachu, Electrico);
Pokemon charmander = new Pokemon("Charmander", 100, ataquesCharmander, Fuego);

// Set up trainers
Entrenador entrenador1 = new Entrenador("Ash");
Entrenador entrenador2 = new Entrenador("Misty");

entrenador1.elegirEquipo(0);
entrenador2.elegirEquipo(1);

// Ash's turn
Console.WriteLine($"{entrenador1.Nombre} elige a {entrenador1.Activo.Nombre} para atacar.");
entrenador1.elegirAtaque(0, entrenador2.Activo); // Pikachu usa Impactrueno

// Process effects at the end of the turn
GestorEfectos.ProcesarEfectosTurno();

// Misty's turn
Console.WriteLine($"{entrenador2.Nombre} elige a {entrenador2.Activo.Nombre} para atacar.");
entrenador2.elegirAtaque(0, entrenador1.Activo); // Charmander usa Llamarada

// Process effects at the end of the turn
GestorEfectos.ProcesarEfectosTurno();

// Use an item
Console.WriteLine($"{entrenador1.Nombre} usa un item en {entrenador1.Activo.Nombre}.");
ItemSuperPocion itemSuperPocion = new ItemSuperPocion();
entrenador1.UsarItem(itemSuperPocion, entrenador1.Activo);
Console.WriteLine(itemSuperPocion);

// Check the state of Pokémon after the turn
Console.WriteLine($"{pikachu.Nombre} tiene {pikachu.Vida} vida restante.");
Console.WriteLine($"{charmander.Nombre} tiene {charmander.Vida} vida restante.");

// Check if either Pokémon is defeated
if (pikachu.EstaDerrotado)
{
    Console.WriteLine($"{pikachu.Nombre} ha sido derrotado.");
}
if (charmander.EstaDerrotado)
{
    Console.WriteLine($"{charmander.Nombre} ha sido derrotado.");
}

Console.WriteLine("Fin de la batalla.");
