using System;
using System.Collections.Generic;

namespace Library
{
    public static class Ataque
    {
        // Diccionario de ataques predefinidos con tres ataques por tipo
        private static readonly Dictionary<string, (int Daño, string Tipo)> ataques = new Dictionary<string, (int Daño, string Tipo)>
        {
            // Agua
            { "Pistola Agua", (40, "Agua") },
            { "Hidrobomba", (110, "Agua") },
            { "Burbuja", (20, "Agua") },

            // Bicho
            { "Picadura", (30, "Bicho") },
            { "Pulso Bicho", (90, "Bicho") },
            { "Tijera X", (80, "Bicho") },

            // Dragón
            { "Garra Dragón", (80, "Dragón") },
            { "Cometa Draco", (130, "Dragón") },
            { "Aliento Dragón", (60, "Dragón") },

            // Eléctrico
            { "Impactrueno", (40, "Eléctrico") },
            { "Rayo", (90, "Eléctrico") },
            { "Trueno", (110, "Eléctrico") },

            // Fantasma
            { "Bola Sombra", (80, "Fantasma") },
            { "Puño Spectral", (90, "Fantasma") },
            { "Puño Sombrío", (70, "Fantasma") },

            // Fuego
            { "Llamarada", (110, "Fuego") },
            { "Lanzallamas", (90, "Fuego") },
            { "Ascuas", (40, "Fuego") },

            // Hielo
            { "Rayo Hielo", (90, "Hielo") },
            { "Ventisca", (110, "Hielo") },
            { "Nieve Polvo", (40, "Hielo") },

            // Lucha
            { "Golpe Karate", (50, "Lucha") },
            { "A Bocajarro", (120, "Lucha") },
            { "Puño Dinámico", (100, "Lucha") },

            // Normal
            { "Tackle", (40, "Normal") },
            { "Puño Sombra", (70, "Normal") }, 
            { "Desenlace", (50, "Normal") }, 

            // Planta
            { "Hoja Afilada", (55, "Planta") },
            { "Látigo Cepa", (45, "Planta") },
            { "Rayo Solar", (120, "Planta") },

            // Psíquico
            { "Confusión", (50, "Psíquico") },
            { "Psíquico", (90, "Psíquico") },
            { "Premonición", (120, "Psíquico") },

            // Roca
            { "Avalancha", (75, "Roca") },
            { "Lanzarrocas", (50, "Roca") },
            { "Roca Afilada", (100, "Roca") },

            // Tierra
            { "Terremoto", (100, "Tierra") },
            { "Excavar", (80, "Tierra") },
            { "Bofetón Lodo", (20, "Tierra") },

            // Veneno
            { "Ácido", (40, "Veneno") },
            { "Bomba Lodo", (90, "Veneno") },
            { "Cola Veneno", (50, "Veneno") },

            // Volador
            { "Tornado", (40, "Volador") },
            { "Ala de Acero", (70, "Volador") },
            { "Ataque Aéreo", (75, "Volador") },
        };

        // Método estático para obtener los ataques predefinidos por nombre
        public static (int Daño, string Tipo) ObtenerAtaque(string nombreAtaque)
        {
            if (ataques.ContainsKey(nombreAtaque))
            {
                return ataques[nombreAtaque];
            }
            else
            {
                Console.WriteLine("Ataque no encontrado.");
                return (0, string.Empty); // Retorna un valor predeterminado si el ataque no existe
            }
        }

        // Método estático para calcular el daño de un ataque
        public static int CalcularDaño(string nombreAtaque, Pokemon objetivo)
        {
            var ataque = ObtenerAtaque(nombreAtaque);
            if (ataque.Daño == 0)
                return 0; // Si el ataque no existe, no calculamos el daño.

            int dañoTotal = ataque.Daño;

            // Verifica si el ataque es preciso
            if (EsPreciso())
            {
                if (EsCritico())
                {
                    dañoTotal = (int)(dañoTotal * 1.2); // Aumenta el daño en un 20% si es crítico
                }

                double multiplicador = LogicaTipos.CalcularMultiplicador(nombreAtaque, objetivo.Tipos); // Calcula multiplicador según tipos
                dañoTotal = (int)(dañoTotal * multiplicador);

                if (GestorEfectos.PokemonConEfecto(objetivo))
                {
                    // Intenta aplicar un efecto especial con una probabilidad fija del 10%
                    if (AplicaEfectoEspecial())
                    {
                        Efecto efectoEspecial = SeleccionarEfectoEspecial();
                        GestorEfectos.AplicarEfecto(efectoEspecial, objetivo);
                    }   
                }
            }
            else
            {
                dañoTotal = 0;
            }

            return dañoTotal;
        }

        // Métodos para comprobar si el ataque es preciso y si es crítico
        public static bool EsPreciso()
        {
            return new Random().NextDouble() <= 0.7; // Probabilidad fija de 70% para precisión
        }

        public static bool EsCritico()
        {
            return new Random().NextDouble() <= 0.2; // 20% de probabilidad de crítico
        }

        public static bool AplicaEfectoEspecial()
        {
            return new Random().NextDouble() <= 0.1; // Probabilidad fija del 10%
        }

        public static Efecto SeleccionarEfectoEspecial()
        {
            int efecto = new Random().Next(1, 5);

            switch (efecto)
            {
                case 1:
                    return new EfectoDormir();
                case 2:
                    return new EfectoParalizar();
                case 3:
                    return new EfectoEnvenenar();
                case 4:
                    return new EfectoQuemar();
            }

            return null;
        }
    }
}
