    using ADSProyect.Interfaces;
using ADSProyect.Models;

namespace ADSProyect.RepoActualizarEstudiantesitories
{
    public class EstudianteRepository : IEstudiante
    {
        private List<Estudiante> LstEstudiante = new List<Estudiante>
        {
            new Estudiante{IdEstudiante = 1, NombresEstudiante = "JOSE ERNESTO",
                ApellidosEstudiante = "CALZADILLA ALVAREZ", CodigoEstudiante = "CA24I04001",
                CorreoEstudiante ="CA24I04001@usonsonte.edu.sv"

            }
        };

        public int ActualizarEstudiante(int idEstudiante, Estudiante estudiante)
        {
            try
            {
                //obtenemos el indice de objeto para actualizar 
                int indice = LstEstudiante.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);
                //procedemos conla actualizacion
                LstEstudiante[indice] = estudiante;
                return idEstudiante;
            }
            catch (Exception )
            {
                throw;
            }
        }
       

        public int AgregarEstudiante(Estudiante estudiante)
        {
            {
                try
                {
                    if (LstEstudiante.Count > 0)
                    {
                        estudiante.IdEstudiante = LstEstudiante.Last().IdEstudiante + 1;

                    }
                    LstEstudiante.Add(estudiante);
                    return estudiante.IdEstudiante;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public bool EliminarEstudiante(int IdEstudiante) 
        {
            try
            {
                // ontenemos el indice del objeto a eliminar
                int indice = LstEstudiante.FindIndex(tmp => tmp.IdEstudiante == IdEstudiante);
                // procedemos a eliminar el registro
                LstEstudiante.RemoveAt(indice);
                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Estudiante ObtenerEstudiantePorID(int IdEstudiante)
        {
            try 
            { 
                // buscamos y asignamos el objeto estudiante 
                Estudiante estudiante = LstEstudiante.FirstOrDefault(tmp => tmp.IdEstudiante == IdEstudiante);
                return estudiante;
            }
            catch(Exception)
            {
                throw;
            }

        }
        

        public List<Estudiante> ObtenerTodosLosEstudiantes()
        {
            try
            {
                return LstEstudiante;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
