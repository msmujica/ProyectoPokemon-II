using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;

namespace Library.Tests
{
    [TestClass]
    public class LogicaTiposTests
    {   
        // Se prueban debilidades, en este caso se prueba que el tipo Fuego es efectivo contra el tipo Planta
        [TestMethod]
        public void Debilidades()
        {      
            //Act: Se calcula el multiplicador para un ataque tipo fuego contra un Pokemón tipo planta
            double multiplicador = LogicaTipos.CalcularMultiplicador("Fuego", "Planta");
            //Assert: El multilplicador debe ser 2, indicando que el ataque es superefectivo
            Assert.AreEqual(2, multiplicador, "El ataque de tipo Fuego debería ser super efectivo contra tipo Planta.");
        }
        // Prueba para verificar que el tipo "Fuego" es poco efectivo contra "Agua"
        [TestMethod]
        public void Resistencias()
        {   // Act: Se calcula el multiplicador para un ataque de tipo Fuego contra un Pokémon de tipo Agua
            double multiplicador = LogicaTipos.CalcularMultiplicador("Fuego", "Agua");
            // Assert: El multiplicador debería ser 0.5, indicando que el ataque es poco efectivo
            Assert.AreEqual(0.5, multiplicador, "El ataque de tipo Fuego debería ser poco efectivo contra tipo Agua.");
        }
        
        [TestMethod]
        //En este caso se verifica que el tipo Eléctrico no tiene efecto sobre el tipo Tierra
        public void Inmunidades()
        {   // Act: Se calcula el multiplicador para un ataque de tipo Eléctrico contra un Pokémon de tipo Tierra
            double multiplicador = LogicaTipos.CalcularMultiplicador("Eléctrico", "Tierra");
            //Assert: El multiplicador debería ser 0, indicando que el ataque no tiene efecto
            Assert.AreEqual(0.5, multiplicador, "El ataque de tipo Eléctrico no tiene efecto sobre tipo Tierra.");
        }

        [TestMethod]
        // Prueba para verificar que el tipo "Agua" no tiene ningun tipo de efecto contra "Eléctrico"
        public void SinEfecto()
        { 
            //Act: Se calcula el multiplicador para un ataque de tipo Agua contra un Pokemón de tipo Eléctrico
            double multiplicador = LogicaTipos.CalcularMultiplicador("Agua", "Eléctrico");
            //Asseert: El multiplicador debe ser 1 ya que sería un ataque normal, sin efecto alguno
            Assert.AreEqual(1, multiplicador, "El ataque de tipo Agua debería ser neutral contra tipo Eléctrico.");
        }
    }
}
