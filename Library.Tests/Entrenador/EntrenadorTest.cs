using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Library;

namespace Library.Tests
{
    [TestClass]
    public class EntrenadorTests
    {
        private Entrenador entrenador;

        [TestInitialize]
        public void SetUp()
        {
            entrenador = new Entrenador("Ash");
        }

        [TestMethod]
        public void Constructor()
        {
            Assert.AreEqual("Ash", entrenador.Nombre);
        }

        [TestMethod]
        public void EquipoInicializado()
        {
            Assert.IsNotNull(entrenador.Equipo);
            Assert.AreEqual(0, entrenador.Equipo.Count);
        }

        [TestMethod]
        public void AgregaPokemonAlEquipo()
        {
            var pokemon = new Pokemon("Pikachu", 100, new List<string> { "Impactrueno" }, "Eléctrico");
            entrenador.Equipo.Add(pokemon);
            Assert.AreEqual(1, entrenador.Equipo.Count);
        }

        [TestMethod]
        public void EquipoLleno()
        {
            for (int i = 0; i < 6; i++)
            {
                entrenador.Equipo.Add(new Pokemon($"Pokemon{i}", 100, new List<string> { "Ataque" }, "Normal"));
            }

            var nuevoPokemon = new Pokemon("Charmander", 100, new List<string> { "Ascuas" }, "Fuego");
            entrenador.Equipo.Add(nuevoPokemon);

            Assert.AreEqual(7, entrenador.Equipo.Count); 
        }

        [TestMethod]
        public void CambiarPokemonActivo()
        {
            var pokemon1 = new Pokemon("Pikachu", 100, new List<string> { "Impactrueno" }, "Eléctrico");
            var pokemon2 = new Pokemon("Charizard", 150, new List<string> { "Llamarada" }, "Fuego");

            entrenador.Equipo.Add(pokemon1);
            entrenador.Equipo.Add(pokemon2);

            var result = entrenador.cambiarActivo(1);

            Assert.AreEqual(entrenador.Equipo[1].Nombre, result);
            Assert.AreEqual(entrenador.Equipo[1], entrenador.Activo);
        }

        [TestMethod]
        public void IndiceInvalido()
        {
            var result = entrenador.cambiarActivo(0);
            Assert.AreEqual("Indice no valido. No se pudo cambiar el pokemon", result);
        }

        [TestMethod]
        public void UsarItemSuperpocion()
        {
            var gestorEfectos = new GestorEfectos();
            var pokemon = new Pokemon("Bulbasaur", 100, new List<string> { "Latigazo" }, "Planta");

            entrenador.SeteodeItems();
            entrenador.UsarItem("Superpocion", pokemon, gestorEfectos);
            Assert.AreEqual(4, entrenador.ContadorSuperPocion);
        }

        [TestMethod]
        public void CambioPokemonMuerto()
        {
            var pokemonMuerto = new Pokemon("Onix", 0, new List<string> { "Golpe Roca" }, "Roca") { EstaDerrotado = true };
            var pokemonVivo = new Pokemon("Jigglypuff", 100, new List<string> { "Canto" }, "Normal");

            entrenador.Equipo = new List<Pokemon> { pokemonMuerto, pokemonVivo };
            entrenador.Activo = pokemonMuerto;

            entrenador.CambioPokemonMuerto();

            Assert.AreEqual(pokemonVivo, entrenador.Activo);
        }

        [TestMethod]
        public void SeteodeItems()
        {
            entrenador.SeteodeItems();
            Assert.AreEqual(4, entrenador.ContadorSuperPocion);
            Assert.AreEqual(2, entrenador.ContadorCuraTotal);
            Assert.AreEqual(1, entrenador.ContadorRevivir);
        }
    }
}
