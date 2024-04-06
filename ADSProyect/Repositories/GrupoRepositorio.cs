using ADSProjectBackend.Models;
using ADSProjectBackend.Repositories.Interfaces;

namespace ADSProjectBackend.Repositories
{
    public class GrupoRepositorio : IGrupo
    {
        private List<Grupo> lstGrupos;
        public GrupoRepositorio()
        {
            lstGrupos = new List<Grupo>() {
                new Grupo() {
                    Id = 1,
                    IdCarrera = 1,
                    IdMateria = 1,
                    IdProfesor= 1,
                    Anio = 2023,
                    Ciclo = 1
                },
                   new Grupo() {
                    Id = 2,
                    IdCarrera = 2,
                    IdMateria = 2,
                    IdProfesor= 2,
                    Anio = 2023,
                    Ciclo = 2
                },

            };

        }

        public bool EliminarGrupo(int idValue)
        {
            try
            {
                lstGrupos.RemoveAt(lstGrupos.FindIndex(tmp => tmp.Id == idValue));
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int InsertarGrupo(Grupo value)
        {
            try
            {
                if (lstGrupos.Count > 0)
                {
                    value.Id = lstGrupos.LastOrDefault().Id + 1;
                }
                else
                {
                    value.Id = 1;
                }

                lstGrupos.Add(value);
            }
            catch (Exception)
            {

                throw;
            }
            return value.Id;
        }

        public int ModificarGrupo(int idValue, Grupo value)
        {
            try
            {
                lstGrupos[lstGrupos.FindIndex(tmp => tmp.Id == idValue)] = value;
                return value.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Grupo ObtenerGrupoPorId(int idValue)
        {
            try
            {
                return lstGrupos.FirstOrDefault(tmp => tmp.Id == idValue);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Grupo> ObtenerListaGrupos()
        {
            return lstGrupos;
        }
    }
}
