using ADSProyect.Models;

namespace ADSProyect.Interfaces
{
    public interface ICarrera
    {
        public int AgregarCarrera(Carrera carrera);
        
        public int ActualizarCarrera (int IdCarrera, Carrera carrera);

        public bool EliminarCarrera (int IdCarrera);

        public List<Carrera> ObtenertodasLasCarreras();

        public Carrera ObtenerCarreraPorId(int IdCarrera);
    }
}
