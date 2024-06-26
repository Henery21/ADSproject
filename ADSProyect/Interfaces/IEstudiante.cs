﻿using ADSProyect.Models;
using System.ComponentModel.DataAnnotations;

namespace ADSProyect.Interfaces
{
    public interface IEstudiante
    {
        public int AgregarEstudiante(Estudiante estudiante);

        public int ActualizarEstudiante(int idEstudiante, Estudiante estudiante);

        public bool EliminarEstudiante(int idEstudiante);

        public List<Estudiante> ObtenerTodosLosEstudiantes();

        public Estudiante ObtenerEstudiantePorID(int idEstudiante);
    }
}
