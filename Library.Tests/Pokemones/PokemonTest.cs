using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Library;

namespace Library.Tests
{
    [TestClass]
    public class PokemonTests
    {
        private Pokemon pokemon;  // Pokémon que será probado
        private Pokemon oponente;   // Oponente del Pokémon en las pruebas
        private GestorEfectos gestorEfectos;    // Objeto para gestionar efectos durante las pruebas
        
        // Configuración inicial de las pruebas
        [TestInitialize]
        public void SetUp()
        {   
            // Inicializa el gestor de efectos y crea dos Pokémon para la prueba
            gestorEfectos = new GestorEfectos();
            pokemon = new Pokemon("Pikachu", 100, new List<string> { "Impactrueno", "Rayo" }, "Eléctrico");
            oponente = new Pokemon("Squirtle", 100, new List<string> { "Pistola Agua" }, "Agua");
        }
        // Prueba que verifica si el método para recibir daño reduce la vida del Pokémon correctamente
        [TestMethod]
        public void RecibirDaño()
        {   // Act: Pikachu recibe 30 puntos de daño
            pokemon.recibirDaño(30);
            // Assert: La vida de Pikachu debería ser 70 después de recibir el daño 
            Assert.AreEqual(70, pokemon.Vida, "La vida del Pokémon debería reducirse a 70 después de recibir 30 de daño.");
        }

        // Prueba que verifica si el Pokémon es considerado derrotado cuando su vida es 0 o menor
        [TestMethod]
        public void EstaDerrotado()
        {
            // Act: Pikachu recibe 120 puntos de daño
            pokemon.recibirDaño(120);
            // Assert: Pikachu debería estar derrotado y su vida debería ser 0
            Assert.IsTrue(pokemon.EstaDerrotado, "El Pokémon debería estar derrotado cuando su vida es 0 o menos.");
            Assert.AreEqual(0, pokemon.Vida, "La vida del Pokémon no debería ser menor que 0.");
        }

        // Prueba que verifica que un Pokémon derrotado no recibe más daño
        [TestMethod]
        public void DerrotadoNoRecibeMasDaño()
        {   
            // Act: Pikachu recibe daño suficiente para quedar derrotado
            pokemon.recibirDaño(120);
            int vidaAntesDeNuevoDaño = pokemon.Vida;
            // Act: Se intenta hacer que Pikachu reciba más daño
            pokemon.recibirDaño(50);
            // Assert: La vida de Pikachu no debería cambiar ya que está derrotado
            Assert.AreEqual(vidaAntesDeNuevoDaño, pokemon.Vida, "Un Pokémon derrotado no debería recibir más daño.");
        }
        // Prueba que verifica que un ataque válido reduce la vida del oponente
        [TestMethod]
        public void AtaqueValido()
        {   
            // Arrange: Se guarda la vida inicial del oponente
            int vidaInicialOponente = oponente.Vida;
            // Act: Pikachu ataca a Squirtle con el ataque "Impactrueno"
            string resultado = pokemon.atacar(oponente, "Impactrueno", gestorEfectos);
            // Assert: La vida de Squirtle debería reducirse y el daño infligido debería coincidir con el cambio en su vida
            Assert.AreNotEqual(vidaInicialOponente, oponente.Vida, "El oponente debería recibir daño al ser atacado con un ataque válido.");
            Assert.AreEqual(resultado, (vidaInicialOponente - oponente.Vida).ToString(), "El daño infligido debería coincidir con el cambio en la vida del oponente.");
        }
        // Prueba que verifica que un ataque inválido no afecta la vida del oponente
        [TestMethod]
        public void AtaqueInvalido()
        {   
            // Arrange: Se guarda la vida inicial del oponente
            int vidaInicialOponente = oponente.Vida;
            // Act: Pikachu intenta usar un ataque no existente ("AtaqueInexistente")
            string resultado = pokemon.atacar(oponente, "AtaqueInexistente", gestorEfectos);
            // Assert: Se espera un mensaje de error y la vida del oponente no debería cambiar
            Assert.AreEqual("Flaco este no es tu ataque", resultado, "Un ataque inválido debería devolver un mensaje de error.");
            Assert.AreEqual(vidaInicialOponente, oponente.Vida, "El oponente no debería recibir daño de un ataque inválido.");
        }
    }
}
