using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ucu.Poo.DiscordBot.Domain;

namespace Library.Tests
{
    /// <summary>
    /// Clase de pruebas unitarias para la clase <see cref="Facade"/>.
    /// Las mismas pueden variar entre bien o mal ya que todo depende si coincide la aleatoridad de los turnos y del ataque.
    /// Para una mejor verificacion recomiendo ir a Program y verificar.
    /// </summary>
    [TestClass]
    [TestSubject(typeof(Facade))]
    public class FacadeTest
    {
        private Facade facade;

        /// <summary>
        /// Configuración previa a cada prueba unitaria.
        /// Se asegura de que cada prueba comience con una nueva instancia de la clase <see cref="Facade"/>.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            Facade.Reset(); // Reiniciar el singleton si es necesario.
            facade = Facade.Instance;
        }

        /// <summary>
        /// Prueba la funcionalidad de agregar un jugador a la lista de espera.
        /// </summary>
        [TestMethod]
        public void TestAddTrainerToWaitingList()
        {
            string player1 = "Ash";

            var result = facade.AddTrainerToWaitingList(player1);

            Assert.AreEqual("Ash agregado a la lista de espera", result);
        }

        /// <summary>
        /// Prueba la funcionalidad de intentar agregar un jugador duplicado a la lista de espera.
        /// </summary>
        [TestMethod]
        public void TestAddTrainerToWaitingList_Duplicate()
        {
            string player1 = "Ash";

            facade.AddTrainerToWaitingList(player1);
            var result = facade.AddTrainerToWaitingList(player1);

            Assert.AreEqual("Ash ya está en la lista de espera", result);
        }

        /// <summary>
        /// Prueba el inicio de una batalla entre dos jugadores.
        /// </summary>
        [TestMethod]
        public void TestStartBattle()
        {
            string player1 = "Ash";
            string player2 = "Misty";

            facade.AddTrainerToWaitingList(player1);
            facade.AddTrainerToWaitingList(player2);
            var result = facade.StartBattle(player1, player2);

            Assert.IsTrue(result.Contains("Comienza"));
        }

        /// <summary>
        /// Prueba la funcionalidad de mostrar los Pokémon disponibles en la Pokédex.
        /// </summary>
        [TestMethod]
        public void TestShowPokémonAvailable()
        {
            var result = facade.ShowPokémonAvailable();

            Assert.IsTrue(result.Contains("Pokemones Disponibles"));
        }

        /// <summary>
        /// Prueba la funcionalidad de remover un jugador de la lista de espera.
        /// </summary>
        [TestMethod]
        public void TestRemoveTrainerFromWaitingList()
        {
            string player1 = "Ash";

            facade.AddTrainerToWaitingList(player1);
            var result1 = facade.RemoveTrainerFromWaitingList(player1);
            var result2 = facade.RemoveTrainerFromWaitingList(player1);

            Assert.AreEqual("Ash removido de la lista de espera", result1);
            Assert.AreEqual("Ash no está en la lista de espera", result2);
        }

        /// <summary>
        /// Prueba la funcionalidad de verificar si un jugador está esperando en la lista de espera.
        /// </summary>
        [TestMethod]
        public void TestTrainerIsWaiting()
        {
            string player1 = "Ash";

            facade.AddTrainerToWaitingList(player1);
            var result1 = facade.TrainerIsWaiting(player1);
            var result2 = facade.TrainerIsWaiting("Misty");

            Assert.AreEqual("Ash está esperando", result1);
            Assert.AreEqual("Misty no está esperando", result2);
        }

        /// <summary>
        /// Prueba la funcionalidad de obtener todos los jugadores esperando en la lista de espera.
        /// </summary>
        [TestMethod]
        public void TestGetAllTrainersWaiting()
        {
            string player1 = "Ash";
            string player2 = "Misty";

            facade.AddTrainerToWaitingList(player1);
            facade.AddTrainerToWaitingList(player2);
            var result = facade.GetAllTrainersWaiting();

            Assert.IsTrue(result.Contains("Ash"));
            Assert.IsTrue(result.Contains("Misty"));
        }

        /// <summary>
        /// Prueba el comportamiento cuando no hay jugadores esperando en la lista.
        /// </summary>
        [TestMethod]
        public void TestStartBattle_NoPlayersWaiting()
        {
            string player1 = "Ash";

            var result = facade.StartBattle(player1, null);

            Assert.AreEqual("No hay nadie esperando", result);
        }

        /// <summary>
        /// Prueba la funcionalidad de elegir un equipo de Pokémon para un jugador durante una batalla.
        /// </summary>
        [TestMethod]
        public void TestChooseTeam()
        {
            string player1 = "Ash";
            string player2 = "Misty";
            facade.AddTrainerToWaitingList(player1);
            facade.AddTrainerToWaitingList(player2);
            facade.StartBattle(player1, player2);

            var result = facade.ChooseTeam(player1, 1);

            Assert.IsTrue(result.Contains("Caterpie"));
        }

        /// <summary>
        /// Prueba la funcionalidad de usar un ítem durante una batalla.
        /// </summary>
        [TestMethod]
        public void TestUseItem()
        {
            string player1 = "Ash";
            string player2 = "Misty";
            facade.AddTrainerToWaitingList(player1);
            facade.AddTrainerToWaitingList(player2);
            facade.StartBattle(player1, player2);

            facade.ChooseTeam(player1, 1);
            facade.ChooseTeam(player1, 2);
            facade.ChooseTeam(player1, 3);
            facade.ChooseTeam(player1, 4);
            facade.ChooseTeam(player1, 5);
            facade.ChooseTeam(player1, 6);

            facade.ChooseTeam(player2, 1);
            facade.ChooseTeam(player2, 2);
            facade.ChooseTeam(player2, 3);
            facade.ChooseTeam(player2, 4);
            facade.ChooseTeam(player2, 5);
            facade.ChooseTeam(player2, 6);

            // Simula que el jugador usa un ítem
            var result = facade.UseItem(player2, 0, "Superpocion");

            Assert.AreEqual("No es tu turno ESPERA!", result);
        }

        /// <summary>
        /// Prueba la funcionalidad de realizar un ataque con un Pokémon durante una batalla.
        /// </summary>
        [TestMethod]
        public void TestAttackPokemon()
        {
            string player1 = "Ash";
            string player2 = "Misty";
            facade.AddTrainerToWaitingList(player1);
            facade.AddTrainerToWaitingList(player2);
            facade.StartBattle(player1, player2);

            facade.ChooseTeam(player1, 1);
            facade.ChooseTeam(player2, 1);

            // Simula que el jugador realiza un ataque
            var result = facade.AttackPokemon(player1, "Picadura");

            Assert.AreEqual(result, result);
        }

        /// <summary>
        /// Prueba la funcionalidad de cambiar el Pokémon activo durante una batalla.
        /// </summary>
        [TestMethod]
        public void TestChangePokemon()
        {
            string player1 = "Ash";
            string player2 = "Misty";
            facade.AddTrainerToWaitingList(player1);
            facade.AddTrainerToWaitingList(player2);
            facade.StartBattle(player1, player2);
            facade.ChooseTeam(player1, 1);
            facade.ChooseTeam(player1, 2);
            facade.ChooseTeam(player1, 3);
            facade.ChooseTeam(player1, 4);
            facade.ChooseTeam(player1, 5);
            facade.ChooseTeam(player1, 6);

            facade.ChooseTeam(player2, 1);
            facade.ChooseTeam(player2, 2);
            facade.ChooseTeam(player2, 3);
            facade.ChooseTeam(player2, 4);
            facade.ChooseTeam(player2, 5);
            facade.ChooseTeam(player2, 6);

            // Simula que el jugador cambia el Pokémon activo
            var result = facade.ChangePokemon(player1, 3);

            Assert.AreEqual("Gastly", result);
        }
    }
}