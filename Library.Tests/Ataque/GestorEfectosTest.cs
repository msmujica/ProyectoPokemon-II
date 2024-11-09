using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;

namespace Tests
{
    [TestClass]
    public class GestorEfectosTests
    {
        [TestMethod]
        public void AplicarEfecto_ValidarAplicacionDeEfecto()
        {
            var pokemon = new Pokemon("Pikachu", 100, new List<string>{"Impactrueno"} ,"Eléctrico");
            var gestorEfectos = new GestorEfectos();
            var efecto = new EfectoParalizar(); 
            gestorEfectos.AplicarEfecto(efecto, pokemon);

            Assert.IsTrue(gestorEfectos.PokemonConEfecto(pokemon));
        }

        [TestMethod]
        public void LimpiarEfectos_DeberiaLimpiarEfectosCorrectamente()
        {
            var pokemon = new Pokemon("Pikachu", 100, new List<string>{"Impactrueno"} ,"Eléctrico");
            var gestorEfectos = new GestorEfectos();
            var efecto = new EfectoParalizar();

            gestorEfectos.AplicarEfecto(efecto, pokemon);
            gestorEfectos.LimpiarEfectos(pokemon);

            Assert.IsFalse(gestorEfectos.PokemonConEfecto(pokemon));
        }
        

        [TestMethod]
        public void ProcesarEfectosDaño_DeberiaAplicarDañoCorrectamente()
        {
            var pokemon = new Pokemon("Venusaur", 100, new List<string>{"Látigo Cepa"},"Planta");
            var gestorEfectos = new GestorEfectos();
            var efecto = new EfectoEnvenenar(); 
            gestorEfectos.AplicarEfecto(efecto, pokemon);
            gestorEfectos.ProcesarEfectosDaño(); // Procesa el daño de efectos

            // Aquí se debería verificar que el daño se haya aplicado correctamente
            Assert.AreEqual(95, pokemon.Vida); 
        }
    }
}
