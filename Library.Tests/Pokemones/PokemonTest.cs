using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Library;

namespace Library.Tests
{
    [TestClass]
    public class PokemonTests
    {
        private Pokemon pokemon;
        private Pokemon oponente;
        private GestorEfectos gestorEfectos;

        [TestInitialize]
        public void SetUp()
        {
            gestorEfectos = new GestorEfectos();
            pokemon = new Pokemon("Pikachu", 100, new List<string> { "Impactrueno", "Rayo" }, "Eléctrico");
            oponente = new Pokemon("Squirtle", 100, new List<string> { "Pistola Agua" }, "Agua");
        }

        [TestMethod]
        public void RecibirDaño()
        {
            pokemon.recibirDaño(30);
            Assert.AreEqual(70, pokemon.Vida, "La vida del Pokémon debería reducirse a 70 después de recibir 30 de daño.");
        }

        [TestMethod]
        public void EstaDerrotado()
        {
            pokemon.recibirDaño(120);
            Assert.IsTrue(pokemon.EstaDerrotado, "El Pokémon debería estar derrotado cuando su vida es 0 o menos.");
            Assert.AreEqual(0, pokemon.Vida, "La vida del Pokémon no debería ser menor que 0.");
        }

        [TestMethod]
        public void DerrotadoNoRecibeMasDaño()
        {
            pokemon.recibirDaño(120);
            int vidaAntesDeNuevoDaño = pokemon.Vida;
            pokemon.recibirDaño(50);
            Assert.AreEqual(vidaAntesDeNuevoDaño, pokemon.Vida, "Un Pokémon derrotado no debería recibir más daño.");
        }

        [TestMethod]
        public void AtaqueValido()
        {
            int vidaInicialOponente = oponente.Vida;
            string resultado = pokemon.atacar(oponente, "Impactrueno", gestorEfectos);

            Assert.AreNotEqual(vidaInicialOponente, oponente.Vida, "El oponente debería recibir daño al ser atacado con un ataque válido.");
            Assert.AreEqual(resultado, (vidaInicialOponente - oponente.Vida).ToString(), "El daño infligido debería coincidir con el cambio en la vida del oponente.");
        }

        [TestMethod]
        public void AtaqueInvalido()
        {
            int vidaInicialOponente = oponente.Vida;
            string resultado = pokemon.atacar(oponente, "AtaqueInexistente", gestorEfectos);

            Assert.AreEqual("Flaco este no es tu ataque", resultado, "Un ataque inválido debería devolver un mensaje de error.");
            Assert.AreEqual(vidaInicialOponente, oponente.Vida, "El oponente no debería recibir daño de un ataque inválido.");
        }
    }
}
