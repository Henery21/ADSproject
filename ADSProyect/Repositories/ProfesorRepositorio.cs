using ADSProjectBackend.Models;
using ADSProjectBackend.Repositories.Interfaces;

namespace ADSProjectBackend.Repositories
{
    public class ProfesorRepositorio : IProfesor
    {
        private List<Profesor> lstProfesores;
        public ProfesorRepositorio()
        {
            lstProfesores = new List<Profesor>() {
                new Profesor() {
                    Id = 1,
                    Nombres = "Lola",
                    Apellidos = "Mento",
                    Email = "LolaMento@gmail.com"
                },

                new Profesor() {
                    Id = 2,
                    Nombres = "Andrés",
                    Apellidos = "Trozado",
                    Email = "ATrozado@gmail.com"
                  },
            };

        }

        public bool EliminarProfesor(int idValue)
        {
            try
            {
                lstProfesores.RemoveAt(lstProfesores.FindIndex(tmp => tmp.Id == idValue));
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int InsertarProfesor(Profesor value)
        {
            try
            {
                if (lstProfesores.Count > 0)
                {
                    value.Id = lstProfesores.LastOrDefault().Id + 1;
                }
                else
                {
                    value.Id = 1;
                }

                lstProfesores.Add(value);
            }
            catch (Exception)
            {

                throw;
            }
            return value.Id;
        }

        public int ModificarProfesor(int idValue, Profesor value)
        {
            try
            {
                lstProfesores[lstProfesores.FindIndex(tmp => tmp.Id == idValue)] = value;
                return value.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Profesor ObtenerProfesorPorId(int idValue)
        {
            try
            {
                return lstProfesores.FirstOrDefault(tmp => tmp.Id == idValue);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Profesor> ObtenerListaProfesores()
        {
            return lstProfesores;
        }
    }
}
