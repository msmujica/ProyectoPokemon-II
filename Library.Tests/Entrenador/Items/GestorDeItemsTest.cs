using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using Library.Items;

namespace Library.Tests
{
    [TestClass]
    public class GestorDeItemsTests
    {
        [TestMethod]
        public void TestUsarSuperPocion()
        {
            // Arrange
            var pokemon = new Pokemon("Pikachu", 50, new List<string> { "Impactrueno", "Rayo", "Trueno" }, "Eléctrico");
            var gestor = new GestorDeItems();
            int contadorSuperPocion = 3;

            // Act
            var result = gestor.UsarSuperPocion(pokemon, contadorSuperPocion);

            // Assert
            Assert.AreEqual("Usaste una Super Pocion. Usos restantes: 2", result);
            Assert.AreEqual(100, pokemon.Vida); // La vida debe ser 100 después de usar la poción
        }

        [TestMethod]
        public void TestUsarSuperPocion_MaxVida()
        {
            // Arrange
            var pokemon = new Pokemon("Pikachu", 100, new List<string> { "Impactrueno", "Rayo", "Trueno" }, "Eléctrico");
            var gestor = new GestorDeItems();
            int contadorSuperPocion = 3;

            // Act
            var result = gestor.UsarSuperPocion(pokemon, contadorSuperPocion);

            // Assert
            Assert.AreEqual("El Pokémon ya está a máxima vida.", result);
            Assert.AreEqual(100, pokemon.Vida); // La vida no debe cambiar si ya está a máximo
        }


        [TestMethod]
        public void TestUsarRevivir_NoEstaDerrotado()
        {
            // Arrange
            var pokemon = new Pokemon("Bulbasaur", 50, new List<string> { "Hoja Afilada", "Látigo Cepa", "Rayo Solar" }, "Planta");
            var gestor = new GestorDeItems();
            int contadorRevivir = 1;

            // Act
            var result = gestor.UsarRevivir(pokemon, contadorRevivir);

            // Assert
            Assert.AreEqual("El Pokémon no está derrotado.", result);
        }

        [TestMethod]
        public void TestUsarCuraTotal()
        {
            // Arrange
            var pokemon = new Pokemon("Charmander", 30, new List<string>{"Llamarada", "Lanzallamas", "Ascuas"}, "Fuego");
            var gestor = new GestorDeItems();
            int contadorCuraTotal = 1;
            var gestorEfectos = new GestorEfectos();

            // Act
            var result = gestor.UsarCuraTotal(pokemon, contadorCuraTotal, gestorEfectos);

            // Assert
            Assert.AreEqual("Usaste una Cura Total. Usos restantes: 0", result);
            Assert.AreEqual(100, pokemon.Vida); // La vida debe ser restaurada al máximo
        }
    }
}
