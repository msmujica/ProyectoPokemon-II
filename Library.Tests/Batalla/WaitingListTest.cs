using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ucu.Poo.DiscordBot.Domain;

namespace Library.Tests.Batalla;

[TestClass]
[TestSubject(typeof(WaitingList))]
public class WaitingListTest
{

    private WaitingList waitingList;

    [TestInitialize]
    public void Setup()
    {
        waitingList = new WaitingList();
    }

    [TestMethod]
    public void AgregarEntrenador()
    {
        // Act
        bool result = waitingList.AddTrainer("Player1");

        // Assert
        Assert.IsTrue(result); // Debería haberse agregado correctamente.
        Assert.AreEqual(1, waitingList.Count); // La lista debería tener un solo entrenador.
    }

    [TestMethod]
    public void RemoverEntrenadorExistente()
    {
        // Arrange
        waitingList.AddTrainer("Player1");

        // Act
        bool result = waitingList.RemoveTrainer("Player1");

        // Assert
        Assert.IsTrue(result); // El entrenador debería haberse eliminado correctamente.
        Assert.AreEqual(0, waitingList.Count); // La lista debería estar vacía.
    }


    [TestMethod]
    public void BuscarEntrenadorPorDisplayName()
    {
        // Arrange
        waitingList.AddTrainer("Player1");

        // Act
        var trainer = waitingList.FindTrainerByDisplayName("Player1");

        // Assert
        Assert.IsNotNull(trainer); // El entrenador debería ser encontrado.
        Assert.AreEqual("Player1", trainer?.Nombre); // El nombre del entrenador debería coincidir.
    }
}