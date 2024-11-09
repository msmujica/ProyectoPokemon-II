using NUnit.Framework;

namespace Library.Tests
{
    [TestFixture]
    public class EfectoTests
    {
        [Test]
        public void EfectoDormir_IniciaYReduceTurnosCorrectamente()
        {
            // Arrange
            var pokemon = new Pokemon("Bulbasaur", 100, new[] { "Planta" });
            var efectoDormir = new EfectoDormir();

            // Act
            efectoDormir.IniciarEfecto(pokemon);
            var sigueDormido = efectoDormir.ProcesarEfecto(pokemon);

            // Assert
            Assert.IsTrue(sigueDormido); // El Pokémon sigue dormido si no se ha despertado
        }
    }
}