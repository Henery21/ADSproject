using ADSProyect.Interfaces;
using ADSProyect.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace ADSProyect.Controllers
{
    [Route("api/estudiantes/")]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudiante estudiante;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private String pCodRespuesta;
        private String pMensajeUsuario;
        private String pMensajeTecnico;

        public EstudiantesController(IEstudiante estudiante)
        {
            this.estudiante = estudiante;
        }

        [HttpPost("agregarEstudiante")]
        public ActionResult<string> AgregarEstudiante([FromBody] Estudiante estudiante)
        {
            try
            {
                //verificar todas las validaciones por atirbuto 
                if (!ModelState.IsValid)
                {
                    //en caso de no cumplir con todas las validaciones 
                    return BadRequest(ModelState);
                }
                int contador = this.estudiante.AgregarEstudiante(estudiante);
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

        [HttpPut("actualizarEstudiante/{idEstudiante}")]
        public ActionResult<string> ActualizarEstudiante(int idEstudiante, [FromBody] Estudiante estudiante)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.estudiante.ActualizarEstudiante(idEstudiante, estudiante);

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

        [HttpDelete("eliminarEstudiante/{idEstudiante}")]
        public ActionResult<string> EliminarEstudiante(int idEstudiante)
        {
            try
            {
                bool eliminado = this.estudiante.EliminarEstudiante(idEstudiante);
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

        [HttpGet("obtenerEstudiantePorID/{idEstudiante}")]
        public ActionResult<Estudiante> ObtenerEstudiantePorID(int idEstudiante)
        {
            try
            {
                Estudiante estudiante = this.estudiante.ObtenerEstudiantePorID(idEstudiante);
                if (estudiante != null)
                {
                    return Ok(estudiante);
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

        [HttpGet("obtenerEstudiantes")]
        public ActionResult<List<Estudiante>> ObtenerEstudiantes()
        {
            try
            {
                List<Estudiante> lstEstudiantes = this.estudiante.ObtenerTodosLosEstudiantes();
                return Ok(lstEstudiantes);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}