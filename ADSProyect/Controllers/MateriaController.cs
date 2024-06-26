﻿using ADSProjectBackend.Models;
using ADSProjectBackend.Repositories;
using ADSProjectBackend.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ADSProjectBackend.Controllers
{
    [Route("ADSProject/Materia")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMateria materiaRepositorio;

        public MateriaController(IMateria materiaRepositorio)
        {
            this.materiaRepositorio = materiaRepositorio;
        }

        // POST api/<MateriaController>
        [HttpPost("insertarMateria")]
        public ActionResult<int> InsertarMateria(Materia value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var valor = materiaRepositorio.InsertarMateria(value);
            if (valor > 0)
            {
                return Ok(valor);
            }
            else
            {
                return BadRequest("Error al intentar insertar");
            }
        }


        // GET: api/<MateriaController>
        [HttpGet("obtenerListaMaterias")]
        public ActionResult<List<Materia>> ObtenerMaterias()
        {
            var valor = materiaRepositorio.ObtenerListaMaterias();
            if (valor.Count <= 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(valor);
            }
        }

        // GET: api/<MateriaController>
        [HttpGet("obtenerMateria/")]
        public ActionResult<Materia> ObtenerMateriaPorId(int id)
        {
            var valor = materiaRepositorio.ObtenerMateriaPorId(id);
            if (valor != null)
            {
                return Ok(valor);
            }
            else
            {
                return NotFound("Materia no encontrada");
            }
        }

        [HttpDelete("eliminarMateria/")]
        public ActionResult<bool> EliminarMateria(int id)
        {
            var valor = materiaRepositorio.ObtenerMateriaPorId(id);
            if (valor != null)
            {
                return Ok(materiaRepositorio.EliminarMateria(id));
            }
            else
            {
                return NotFound("Estudiante no encontrado");
            }
        }

        [HttpPatch("actualizarMateria/")]
        public ActionResult<int> ActualizarMateria(int id, [FromBody] Materia value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var valor = materiaRepositorio.ModificarMateria(id, value);
            if (valor > 0)
            {
                return Ok(valor);
            }
            else
            {
                return BadRequest("Error al actualizar a la materia");
            }
        }
    }
}
