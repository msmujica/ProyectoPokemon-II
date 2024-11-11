using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System.Collections.Generic;

namespace Library.Tests
{
    [TestClass]
    public class PokedexTests
    {
        [TestMethod]
        public void TestMostrarPokemonPorIndice_Valido()
        {
            // Act: se obtiene pokemon con indice 0
            var pokemon = Pokedex.MostrarPokemonPorIndice(0);

            // Assert: Se verifica que el pokemón devuelto sea Squirtle
            Assert.AreEqual("Squirtle", pokemon);
        }

        [TestMethod]
        //Prueba para que Mostrar Pokédex devuelve la lista completa
        public void TestMostrarPokedex()
        {
            // Act: Se obtiene la lista de Pokemón de la Pokédex
            var pokedex = Pokedex.MostrarPokedex();

            // Assert: Se verifica que la liosta contenga exactamente 15 Pokemons y que el primero sea Squirtle
            Assert.AreEqual(15, pokedex.Count); // Hay 15 Pokémon
            Assert.IsTrue(pokedex[0].Contains("Squirtle"));
            Assert.IsTrue(pokedex[0].Contains("Agua"));
        }
        
        [TestMethod]
        public void TestCrearPokemonPorIndice()
        {
            // Arrange: Se crea un entrenador 
            var entrenador = new Entrenador("Ash");

            // Act: Se crea un Pokemón de inidice 0 para el entrenador 
            var pokemon = Pokedex.CrearPokemonPorIndice(0, entrenador);

            //Assert
            Assert.IsNotNull(pokemon);  //El pokemon existe
            Assert.AreEqual("Squirtle", pokemon.Nombre);    //El nombre del Pokemón debe ser Squirtle
            Assert.AreEqual(100, pokemon.Vida);     //La vida del Pokemón debe ser 100 
        }

        [TestMethod]
        // Se prueba el comportamiento cuando se intenta crear un Pokemón con un índice inválido
        public void TestCrearPokemonPorIndice_Invalid()
        {
            // Arrange: Se crea un entrenador
            var entrenador = new Entrenador("Ash");

            // Act: Se crea un Pokemón con índice inválido (100) para el entrenador
            var pokemon = Pokedex.CrearPokemonPorIndice(100, entrenador);

            // Assert: 
            Assert.IsNull(pokemon); // No debe existir un Pokemón con ese índice
        }
    }
}