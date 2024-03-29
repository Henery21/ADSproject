using ADSProjectBackend.Models;
using ADSProjectBackend.Repositories.Interfaces;

namespace ADSProjectBackend.Repositories
{
    public class MateriaRepositorio : IMateriaRepositorio
    {
        private List<Materia> lstMaterias;

        public MateriaRepositorio()
        {
            lstMaterias = new List<Materia>() {
                new Materia() {
                    Id = 1,
                    Nombre = "Analisis de Sistemas"
                },
                new Materia() {
                    Id = 2,
                    Nombre = "Sistemas Electricos"
                },

            };
        }

        public bool EliminarMateria(int idValue)
        {
            try
            {
                lstMaterias.RemoveAt(lstMaterias.FindIndex(tmp => tmp.Id == idValue));
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int InsertarMateria(Materia value)
        {
            try
            {
                if (lstMaterias.Count > 0)
                {
                    value.Id = lstMaterias.LastOrDefault().Id + 1;
                }
                else
                {
                    value.Id = 1;
                }

                lstMaterias.Add(value);
            }
            catch (Exception)
            {

                throw;
            }
            return value.Id;
        }

        public int ModificarMateria(int idValue, Materia value)
        {
            try
            {
                lstMaterias[lstMaterias.FindIndex(tmp => tmp.Id == idValue)] = value;
                return value.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Materia> ObtenerListaMaterias()
        {
            return lstMaterias;
        }

        public Materia ObtenerMateriaPorId(int idValue)
        {
            try
            {
                return lstMaterias.FirstOrDefault(tmp => tmp.Id == idValue);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
