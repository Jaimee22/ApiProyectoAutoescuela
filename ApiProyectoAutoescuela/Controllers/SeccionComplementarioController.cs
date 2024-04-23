using ApiProyectoAutoescuela.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAutoescuela.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProyectoAutoescuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeccionComplementarioController : ControllerBase
    {
        private readonly RepositoryAutoescuela repo;


        public SeccionComplementarioController(RepositoryAutoescuela repo)
        {
            this.repo = repo;
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Alumno>>> GetAlumnos()
        {
            try
            {
                // Obtener la sesión actual
                var sesion = await repo.FindSesionAsync();
                if (sesion == null)
                {
                    return NotFound("No se encontró la sesión.");
                }

                // Usar los datos de la sesión para obtener los alumnos
                var alumnos = await repo.GetAlumnosPorSeccionAsync(sesion.SeccionId);
                return Ok(alumnos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<AlumnoCompleto>> InsertarAlumnoCompleto(AlumnoCompleto alumno)
        {
            try
            {
                await repo.InsertarAlumnoCompletoAsync(alumno.Nombre, alumno.Apellido, alumno.FechaNacimiento, alumno.VehiculoId, alumno.AutoescuelaId, alumno.SeccionId, alumno.ProfesorId, alumno.PermisoId);
                return CreatedAtAction(nameof(DetallesAlumnoCompleto), new { alumnoId = alumno.AlumnoId }, alumno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar el alumno completo: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("[action]/{alumnoId}")]
        public async Task<IActionResult> DetallesAlumnoCompleto(int alumnoId)
        {
            try
            {
                var alumnoDetalles = await repo.GetDetallesAlumnoAsync(alumnoId);
                return Ok(alumnoDetalles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los detalles del alumno: {ex.Message}");
            }
        }


        // Método para eliminar un alumno por su ID
        [Authorize]
        [HttpDelete]
        [Route("[action]/{alumnoId}")]
        public async Task<IActionResult> EliminarAlumno(int alumnoId)
        {
            try
            {
                await repo.EliminarAlumnoAsync(alumnoId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el alumno: {ex.Message}");
            }
        }


        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Profesor>>> GetProfesores()
        {
            try
            {
                // Obtener la sesión actual
                var sesion = await repo.FindSesionAsync();
                if (sesion == null)
                {
                    return NotFound("No se encontró la sesión.");
                }

                // Usar los datos de la sesión para obtener los profesores
                var profesores = await repo.GetProfesoresPorSeccionAsync(sesion.SeccionId);
                return Ok(profesores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // Método para obtener un profesor por su ID
        [Authorize]
        [HttpGet]
        [Route("[action]/{profesorId}")]
        public async Task<ActionResult<Profesor>> ObtenerProfesorPorId(int profesorId)
        {
           return await this.repo.ObtenerProfesorAsync(profesorId);
        }


        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> InsertarProfesor(string nombre, string apellido, int seccionId)
        {
            try
            {
                await repo.InsertarProfesorAsync(nombre, apellido, seccionId);
                return Ok("Profesor insertado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar el profesor: {ex.Message}");
            }
        }

        // Método para editar un profesor por su ID
        [Authorize]
        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> EditarProfesor(int id, Profesor profesor)
        {
            if (id != profesor.ProfesorId)
            {
                return BadRequest("ID del profesor no coincide.");
            }

            try
            {
                await repo.EditarProfesorAsync(id, profesor.Nombre, profesor.Apellido);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al editar el profesor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("[action]/{profesorId}")]
        public async Task<IActionResult> EliminarProfesor(int profesorId)
        {
            try
            {
                await repo.EliminarProfesorAsync(profesorId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el profesor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<VehiculoCategoria>>> VehiculosCategorias()
        {
            try
            {
                // Obtener la sesión actual del repositorio
                var sesion = await repo.FindSesionAsync();

                if (sesion == null)
                {
                    // Si no hay una sesión válida, retornar un error
                    return BadRequest("No se encontró una sesión válida.");
                }

                // Obtener todas las categorías de vehículos para la sección de la sesión
                List<VehiculoCategoria> vehiculoCategorias = await repo.GetVehiculoCategoriasAsync(sesion.SeccionId);
                return Ok(vehiculoCategorias);
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra
                return StatusCode(500, $"Error al obtener las categorías de vehículos: {ex.Message}");
            }
        }


        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Coche>>> CargarCoches()
        {
            var coches = await repo.ObtenerTodosLosCochesAsync();
            return Ok(coches);
        }



    }
}
