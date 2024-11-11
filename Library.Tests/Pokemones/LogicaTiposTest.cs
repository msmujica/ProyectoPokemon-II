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

        [TestMethod]
        public void Resistencias()
        {
            double multiplicador = LogicaTipos.CalcularMultiplicador("Fuego", "Agua");
            Assert.AreEqual(0.5, multiplicador, "El ataque de tipo Fuego debería ser poco efectivo contra tipo Agua.");
        }
        
        [TestMethod]
        //En este caso se verifica
        public void Inmunidades()
        {
            double multiplicador = LogicaTipos.CalcularMultiplicador("Eléctrico", "Tierra");
            Assert.AreEqual(0.5, multiplicador, "El ataque de tipo Eléctrico no tiene efecto sobre tipo Tierra.");
        }

        [TestMethod]
        public void SinEfecto()
        {
            double multiplicador = LogicaTipos.CalcularMultiplicador("Agua", "Eléctrico");
            Assert.AreEqual(1, multiplicador, "El ataque de tipo Agua debería ser neutral contra tipo Eléctrico.");
        }
    }
}
