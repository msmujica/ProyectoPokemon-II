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
            // Act
            var pokemon = Pokedex.MostrarPokemonPorIndice(0);

            // Assert
            Assert.AreEqual("Squirtle", pokemon);
        }

        [TestMethod]
        public void TestMostrarPokemonPorIndice_Invalido()
        {
            // Act
            var pokemon = Pokedex.MostrarPokemonPorIndice(100);

            // Assert
            Assert.IsNull(pokemon);
        }

        [TestMethod]
        public void TestMostrarPokedex()
        {
            // Act
            var pokedex = Pokedex.MostrarPokedex();

            // Assert
            Assert.AreEqual(15, pokedex.Count); // Hay 15 Pokémon
            Assert.IsTrue(pokedex[0].Contains("Squirtle"));
            Assert.IsTrue(pokedex[0].Contains("Agua"));
        }

        [TestMethod]
        public void TestCrearPokemonPorIndice()
        {
            // Arrange
            var entrenador = new Entrenador("Ash");

            // Act
            var pokemon = Pokedex.CrearPokemonPorIndice(0, entrenador);

            // Assert
            Assert.IsNotNull(pokemon);
            Assert.AreEqual("Squirtle", pokemon.Nombre);
            Assert.AreEqual(100, pokemon.Vida);
        }

        [TestMethod]
        public void TestCrearPokemonPorIndice_Invalid()
        {
            // Arrange
            var entrenador = new Entrenador("Ash");

            // Act
            var pokemon = Pokedex.CrearPokemonPorIndice(100, entrenador);

            // Assert
            Assert.IsNull(pokemon);
        }
    }
}