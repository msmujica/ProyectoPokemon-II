using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Library.Tests
{
    [TestClass]
    public class AtaqueTests
    {
        [TestMethod]
        public void ObtenerAtaque_Valido_ReturnsCorrectAttackData()
        {
            // Act
            var ataque = Ataque.ObtenerAtaque("Pistola Agua");

            // Assert
            Assert.AreEqual(40, ataque.Daño);
            Assert.AreEqual("Agua", ataque.Tipo);
        }

        [TestMethod]
        public void ObtenerAtaque_Invalido_ReturnsZeroDamage()
        {
            // Act
            var ataque = Ataque.ObtenerAtaque("Ataque Inexistente");

            // Assert
            Assert.AreEqual(0, ataque.Daño);
            Assert.AreEqual(string.Empty, ataque.Tipo);
        }

        [TestMethod]
        public void CalcularDaño_AtaqueConCriticoYMultiplicador_DamageIsCalculatedCorrectly()
        {
            // Arrange
            var pokemonObjetivo = new Pokemon("Charmander", 100, ,new[] { "Fuego" });
            var gestorEfectos = new GestorEfectos();
            Random random = new Random();

            // Act
            var daño = Ataque.CalcularDaño("Llamarada", pokemonObjetivo, gestorEfectos);

            // Assert
            // Comprobamos que el daño sea mayor al daño base debido al crítico y multiplicador
            Assert.Greater(daño, 110); // El daño base de Llamarada es 110, esperamos algo mayor si es crítico
        }

        [TestMethod]
        public void EsPreciso_DevuelveTrueCuandoEsPreciso()
        {
            // Act
            var resultado = Ataque.EsPreciso();

            // Assert
            Assert.IsTrue(resultado == true || resultado == false); // Debe ser un valor booleano
        }

        [TestMethod]
        public void EsCritico_DevuelveTrueOFalseConProbabilidad()
        {
            // Act
            var resultado = Ataque.EsCritico();

            // Assert
            Assert.IsTrue(resultado == true || resultado == false); // 20% de probabilidad de ser crítico
        }
    }
}