using ApiProyectoAutoescuela.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoAutoescuela.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProyectoAutoescuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private RepositoryAutoescuela repo;

        public AlumnoController(RepositoryAutoescuela repo)
        {
            this.repo = repo;
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Alumno>>> GetAlumnos()
        {
            return await this.repo.GetAlumnosAsync();
        }

        [Authorize]
        [HttpGet]
        [Route("[action]/{idAlumno}")]
        public async Task<ActionResult<Alumno>> Details(int idAlumno)
        {
            return await this.repo.FindAlumno(idAlumno);
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                await repo.InsertAlumnoAsync(alumno.Nombre, alumno.Apellido, alumno.FechaNacimiento, alumno.VehiculoId, alumno.AutoescuelaId, alumno.SeccionId, alumno.ProfesorId);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPut]
        [Route("[action]/{idAlumno}")]
        public async Task<IActionResult> Edit(int idAlumno, Alumno alumno)
        {
            if (idAlumno != alumno.AlumnoId)
            {
                return BadRequest();
            }

            await repo.UpdateAlumnoAsync(alumno.AlumnoId, alumno.Nombre, alumno.Apellido, alumno.FechaNacimiento, alumno.VehiculoId, alumno.AutoescuelaId, alumno.SeccionId, alumno.ProfesorId);
            return Ok();
        }

        [Authorize]
        [HttpDelete]
        [Route("[action]/{idAlumno}")]
        public async Task<IActionResult> Delete(int idAlumno)
        {
            var alumno = await repo.FindAlumno(idAlumno);
            if (alumno == null)
            {
                return NotFound();
            }

            await repo.DeleteAlumnoAsync(idAlumno);
            return Ok();
        }


        //[HttpGet]
        //[Route("[action]")]
        //public async Task<ActionResult<List<Alumno>>> AlumnosPorSeccion()
        //{
        //    // Obtener el SeccionId de la sesión
        //    int? seccionId = HttpContext.Session.GetInt32("SeccionId");

        //    if (!seccionId.HasValue)
        //    {
        //        // Si no se ha seleccionado ninguna sección, retornar un error
        //        return BadRequest("No se ha seleccionado ninguna sección.");
        //    }

        //    // Obtener los alumnos por sección
        //    List<Alumno> alumnos = await this.repo.GetAlumnosPorSeccionAsync(seccionId.Value);
        //    return alumnos;
        //}

    }
}
