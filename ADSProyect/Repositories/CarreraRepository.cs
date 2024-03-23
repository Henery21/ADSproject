using ADSProyect.Interfaces;
using ADSProyect.Models;


namespace ADSProyect.Repositories
{
    public class CarreraRepository : ICarrera
    {
        private List<Carrera> lstCarrera = new List<Carrera>
        {
            new Carrera
            {
                IdCarrera = 1, Codigo ="MATE01", Nombre ="Matematica" 
            }
        };
        public int ActualizarCarrera (int IdCarrera ,Carrera carrera)
        {
            try
            {
                int indice = lstCarrera.FindIndex(tmp => tmp.IdCarrera == IdCarrera);
                lstCarrera[indice] = carrera;

                return IdCarrera;
            }
            catch (Exception)
            {

                throw;
            }
        }

        int ICarrera.ActualizarCarrera(int IdCarrera, Carrera carrera)
        {
            try
            {
                int indice = lstCarrera.FindIndex(tmp => tmp.IdCarrera == IdCarrera);

                lstCarrera[indice] = carrera;
                return IdCarrera;
            }
            catch (Exception)
            {
                throw;
            }
        }

        int ICarrera.AgregarCarrera(Carrera carrera)
        {
            try
            {
                if(lstCarrera.Count > 0)
                {
                    carrera.IdCarrera = lstCarrera.Last().IdCarrera+1;
                }
                lstCarrera.Add(carrera);
                return carrera.IdCarrera;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Carrera> ObtenertodasLasCarreras()
        {
            try
            {
                return lstCarrera;

            }
            catch (Exception)
            {
                throw;
            }
        }

        bool ICarrera.EliminarCarrera(int IdCarrera)
        {
            try
            {
                int indice =lstCarrera.FindIndex(tmp => tmp.IdCarrera==IdCarrera);
                lstCarrera.RemoveAt(indice);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        
        Carrera ICarrera.ObtenerCarreraPorId(int IdCarrera)
        {
            try
            {

                Carrera carrera = lstCarrera.FirstOrDefault(tmp => tmp.IdCarrera == IdCarrera);
                return carrera;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
