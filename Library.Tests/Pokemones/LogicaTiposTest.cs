using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;

namespace Library.Tests
{
    [TestClass]
    public class LogicaTiposTests
    {
        [TestMethod]
        public void Debilidades()
        {
            double multiplicador = LogicaTipos.CalcularMultiplicador("Fuego", "Planta");
            Assert.AreEqual(2, multiplicador, "El ataque de tipo Fuego debería ser super efectivo contra tipo Planta.");
        }

        [TestMethod]
        public void Resistencias()
        {
            double multiplicador = LogicaTipos.CalcularMultiplicador("Fuego", "Agua");
            Assert.AreEqual(0.5, multiplicador, "El ataque de tipo Fuego debería ser poco efectivo contra tipo Agua.");
        }

        [TestMethod]
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
