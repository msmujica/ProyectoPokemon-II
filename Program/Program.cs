using System;
using System.Collections.Generic;
using Library;

// Se crean Tipos
Tipos Agua = new Tipos("Agua");
Tipos Bicho = new Tipos("Bicho");
Tipos Dragón = new Tipos("Dragón");
Tipos Electrico = new Tipos("Electrico");
Tipos Fantasma = new Tipos("Fantasma");
Tipos Fuego = new Tipos("Fuego");
Tipos Hielo = new Tipos("Hielo");
Tipos Lucha = new Tipos("Lucha");
Tipos Normal = new Tipos("Normal");
Tipos Planta = new Tipos("Planta");
Tipos Psíquico = new Tipos("Psíquico");
Tipos Roca = new Tipos("Roca");
Tipos Tierra = new Tipos("Tierra");
Tipos Veneno = new Tipos("Veneno");
Tipos Volador = new Tipos("Volador");

// Agregar debilidades
Agua.AgregarDebilidades(new List<Tipos> { Electrico, Planta });
Bicho.AgregarDebilidades(new List<Tipos> { Fuego, Roca, Volador, Veneno });
Dragón.AgregarDebilidades(new List<Tipos> { Dragón, Hielo });
Electrico.AgregarDebilidades(new List<Tipos> { Tierra });
Fantasma.AgregarDebilidades(new List<Tipos> { Fantasma });
Fuego.AgregarDebilidades(new List<Tipos> { Agua, Roca, Tierra });
Hielo.AgregarDebilidades(new List<Tipos> { Fuego, Lucha, Roca });
Lucha.AgregarDebilidades(new List<Tipos> { Psíquico, Volador, Bicho, Roca });
Normal.AgregarDebilidades(new List<Tipos> { Lucha });
Planta.AgregarDebilidades(new List<Tipos> { Bicho, Fuego, Hielo, Veneno, Volador });
Psíquico.AgregarDebilidades(new List<Tipos> { Bicho, Lucha, Fantasma });
Roca.AgregarDebilidades(new List<Tipos> { Agua, Lucha, Planta, Tierra });
Tierra.AgregarDebilidades(new List<Tipos> { Agua, Hielo, Planta, Roca, Veneno });
Veneno.AgregarDebilidades(new List<Tipos> { Bicho, Psíquico, Tierra, Lucha, Planta });
Volador.AgregarDebilidades(new List<Tipos> { Electrico, Hielo, Roca });

// Agregar resistencias
Agua.AgregarResistencia(new List<Tipos> { Agua, Fuego, Hielo });
Bicho.AgregarResistencia(new List<Tipos> { Lucha, Planta, Tierra });
Dragón.AgregarResistencia(new List<Tipos> { Agua, Electrico, Fuego, Planta });
Electrico.AgregarResistencia(new List<Tipos> { Volador });
Fantasma.AgregarResistencia(new List<Tipos> { Veneno, Lucha, Normal });
Fuego.AgregarResistencia(new List<Tipos> { Bicho, Fuego, Planta });
Hielo.AgregarResistencia(new List<Tipos> { Hielo });
Lucha.AgregarResistencia(new List<Tipos> { });
Normal.AgregarResistencia(new List<Tipos> { });
Planta.AgregarResistencia(new List<Tipos> { Agua, Electrico, Planta, Tierra });
Psíquico.AgregarResistencia(new List<Tipos> { });
Roca.AgregarResistencia(new List<Tipos> { Fuego, Normal, Veneno, Volador });
Tierra.AgregarResistencia(new List<Tipos> { Electrico });
Veneno.AgregarResistencia(new List<Tipos> { Planta, Veneno });
Volador.AgregarResistencia(new List<Tipos> { Bicho, Lucha, Planta, Tierra });

// Agregar inmunidades
Agua.AgregarInmune(new List<Tipos> { });
Bicho.AgregarInmune(new List<Tipos> { });
Dragón.AgregarInmune(new List<Tipos> { });
Electrico.AgregarInmune(new List<Tipos> { Electrico });
Fantasma.AgregarInmune(new List<Tipos> { });
Fuego.AgregarInmune(new List<Tipos> { });
Hielo.AgregarInmune(new List<Tipos> { });
Lucha.AgregarInmune(new List<Tipos> { });
Normal.AgregarInmune(new List<Tipos> { Fantasma });
Planta.AgregarInmune(new List<Tipos> { });
Psíquico.AgregarInmune(new List<Tipos> { });
Roca.AgregarInmune(new List<Tipos> { });
Tierra.AgregarInmune(new List<Tipos> { });
Veneno.AgregarInmune(new List<Tipos> { });
Volador.AgregarInmune(new List<Tipos> { });


GestorEfectos gestorEfectos = new GestorEfectos();