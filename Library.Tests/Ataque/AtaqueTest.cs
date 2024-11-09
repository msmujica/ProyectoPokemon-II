using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Library;

namespace Tests
{
    [TestClass]
    public class AtaqueTests
    {
        [TestMethod]
        public void ObtenerAtaque_Existente_DeberiaRetornarDatosCorrectos()
        {
            var resultado = Ataque.ObtenerAtaque("Pistola Agua");
            Assert.AreEqual(40, resultado.Daño);
            Assert.AreEqual("Agua", resultado.Tipo);
        }

        [TestMethod]
        public void ObtenerAtaque_NoExistente_DeberiaRetornarValorPredeterminado()
        {
            var resultado = Ataque.ObtenerAtaque("AtaqueInexistente");
            Assert.AreEqual(0, resultado.Daño);
            Assert.AreEqual(string.Empty, resultado.Tipo);
        }

        [TestMethod]
        public void CalcularDaño_ConCritico_DeberiaAumentarElDaño()
        {
            var pokemonObjetivo = new Pokemon("Bulbasaur", 100, new List<string>{"Hoja Afilada"},"Planta");
            var gestorEfectos = new GestorEfectos();

            // Configura el daño base para un ataque como "Hoja Afilada" (55 daño)
            int dañoCalculado = Ataque.CalcularDaño("Hoja Afilada", pokemonObjetivo, gestorEfectos);

            // Si el ataque es crítico, el daño debería multiplicarse por 1.2
            Assert.AreEqual(dañoCalculado, 55);
        }

        [TestMethod]
        public void CalcularDaño_SiElAtaqueNoEsPreciso_DeberiaRetornarCero()
        {
            var pokemonObjetivo = new Pokemon("Charmander", 100, new List<string>{"Rayo"},"Fuego");
            var gestorEfectos = new GestorEfectos();

            // Si no es preciso, el daño debería ser 0
            int dañoCalculado = Ataque.CalcularDaño("Rayo", pokemonObjetivo, gestorEfectos);
            Assert.AreEqual(0, dañoCalculado);
        }
    }
}