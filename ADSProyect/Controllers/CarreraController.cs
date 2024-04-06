using ADSProyect.Interfaces;
using ADSProyect.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSProyect.Controllers
{
    [Route("api/carrera/")]
    public class CarreraController : ControllerBase
    {
        private readonly ICarrera carrera;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private String pCodRespuesta;
        private String pMensajeUsuario;
        private String pMensajeTecnico;

        public CarreraController(IEstudiante estudiante)
        {
            this.carrera = carrera;
        }
        [HttpPost("AgregarCarrera")]
        public ActionResult<string> AgregarCarrera([FromBody] Carrera carrera)
        {
            try
            {
                //verificar todas las validaciones por atirbuto 
                if (!ModelState.IsValid)
                {
                    //en caso de no cumplir con todas las validaciones 
                    return BadRequest(ModelState);
                }

                int contador = this.carrera.AgregarCarrera(carrera);
                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro insertado con exito";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un porblema al inserta el registro";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("ActualizarCarrera/{IdCarrera}")]
        public ActionResult<string> ActualizarEstudiante(int IdCarrera, [FromBody] Carrera carrera)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                   return BadRequest(ModelState);
                }
                int contador = this.carrera.ActualizarCarrera(IdCarrera, carrera);

                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Resgistro actualizado con exito";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;

                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un erro en el registro";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("EliminarCarrera/{IdCarrera}")]
        public ActionResult<string> EliminarEstudiante(int IdCarrera)
        {
            try
            {
                bool eliminado = this.carrera.EliminarCarrera(IdCarrera);
                if (eliminado)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro elininado con exito";
                    pMensajeTecnico = pCodRespuesta + " ||" + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al eliminar el registro";
                    pMensajeTecnico = pCodRespuesta + "|| " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ObtenerCarreraPorId/{IdCarrera}")]
        public ActionResult<Carrera> ObtenerCarreraPorId(int IdCarrera)
        {
            try
            {
                Carrera carrera = this.carrera.ObtenerCarreraPorId(IdCarrera);
                if (carrera != null)
                {
                    return Ok(carrera);
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron datos del estudiante";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception)
            {
                throw;
            }


        }

        [HttpGet("carreras")]
        public ActionResult<List<Carrera>> ObtenertodasLasCarreras()
        {
            try
            {
                List<Carrera> lstCarrera = this.carrera.ObtenertodasLasCarreras();
                return Ok(lstCarrera);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

        
    
