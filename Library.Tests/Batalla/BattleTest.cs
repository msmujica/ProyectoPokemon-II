using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ucu.Poo.DiscordBot.Domain;

namespace Library.Tests.Batalla
{
    [TestClass] // Asegura que esta clase se use para pruebas
    public class BattleTest
    {
        [TestMethod]
        public void ValidacionPokemon_DeberiaRetornarTrue_CuandoUnJugadorTieneMenosDeSeisPokemon()
        {
            // Configuración del escenario
            var entrenador1 = new Entrenador("Player 1");
            var entrenador2 = new Entrenador("Player 2");

            // Solo agregamos menos de 6 Pokémon a cada equipo
            entrenador1.elegirEquipo(1);
            entrenador1.elegirEquipo(2);
            entrenador1.elegirEquipo(3);
            entrenador1.elegirEquipo(4);
            entrenador1.elegirEquipo(5);
            entrenador1.elegirEquipo(6);

            entrenador2.elegirEquipo(1);
            entrenador2.elegirEquipo(2);
            entrenador2.elegirEquipo(3);
            entrenador2.elegirEquipo(4);
            entrenador2.elegirEquipo(5);

            var battle = new Battle(entrenador1, entrenador2);

            // Actuar
            var resultado = battle.validacionPokemon();

            // Verificar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void ValidacionWin_DeberiaRetornarTrue_CuandoTodosLosPokemonDelOponenteEstanMuertos()
        {
            // Configuración del escenario
            var entrenador1 = new Entrenador("Player 1");
            var entrenador2 = new Entrenador("Player 2");

            // Solo agregamos 6 Pokémon a cada equipo
            entrenador1.elegirEquipo(1);
            entrenador1.elegirEquipo(2);
            entrenador1.elegirEquipo(3);
            entrenador1.elegirEquipo(4);
            entrenador1.elegirEquipo(5);
            entrenador1.elegirEquipo(6);

            entrenador2.elegirEquipo(1);
            entrenador2.elegirEquipo(2);
            entrenador2.elegirEquipo(3);
            entrenador2.elegirEquipo(4);
            entrenador2.elegirEquipo(5);
            entrenador2.elegirEquipo(6);


            foreach (var pokemon in entrenador2.Equipo)
            {
                pokemon.Vida = 0; // Todos los Pokémon de Player2 tienen vida 0, provocando su derrota.
            }

            var battle = new Battle(entrenador1, entrenador2);

            // Actuar
            var resultado = battle.ValidacionWin();

            // Verificar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void CambiarTurno_DeberiaAlternarEntreJugadores()
        {
            // Configuración del escenario
            var entrenador1 = new Entrenador("Player 1");
            var entrenador2 = new Entrenador("Player 2");

            // Solo agregamos 6 Pokémon a cada equipo
            entrenador1.elegirEquipo(1);
            entrenador1.elegirEquipo(2);
            entrenador1.elegirEquipo(3);
            entrenador1.elegirEquipo(4);
            entrenador1.elegirEquipo(5);
            entrenador1.elegirEquipo(6);

            entrenador2.elegirEquipo(1);
            entrenador2.elegirEquipo(2);
            entrenador2.elegirEquipo(3);
            entrenador2.elegirEquipo(4);
            entrenador2.elegirEquipo(5);
            entrenador2.elegirEquipo(6);


            var battle = new Battle(entrenador1, entrenador2);

            // Actuar y verificar
            if (battle.TurnoActual == entrenador1)
            {
                Assert.AreEqual(battle.TurnoActual, entrenador1);

                battle.CambiarTurno();

                Assert.AreEqual(battle.TurnoActual, entrenador2);

                battle.CambiarTurno();

                Assert.AreEqual(battle.TurnoActual, entrenador1);
            }
            else
            {
                Assert.AreEqual(battle.TurnoActual, entrenador2);

                battle.CambiarTurno();

                Assert.AreEqual(battle.TurnoActual, entrenador1);

                battle.CambiarTurno();

                Assert.AreEqual(battle.TurnoActual, entrenador2);
            }

            // Actuar: se realiza el ataque
            var resultado = battle.IntermediarioAtacar("Picadura");

            // Verificar
            Assert.AreEqual("30", resultado);
            Assert.AreEqual(entrenador2.Activo.Vida, battle.TurnoActual.Activo.Vida);
            
            resultado = battle.IntermediarioCambiarPokemonActivo(2);

            // Verificar
            Assert.AreEqual(entrenador1.Activo, battle.TurnoActual.Activo);
            Assert.AreEqual("Hecho", resultado);
        }

    }
}