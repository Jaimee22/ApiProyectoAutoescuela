using ApiProyectoAutoescuela.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAutoescuela.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProyectoAutoescuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {
        private readonly RepositoryAutoescuela repo;

        public SesionController(RepositoryAutoescuela repo)
        {
            this.repo = repo;
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<Sesion>> GetSesion()
        {
            var sesion = await repo.FindSesionAsync();
            if (sesion == null)
            {
                return NotFound();
            }
            return Ok(sesion);
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateSesion(Sesion sesion)
        {
            if (ModelState.IsValid)
            {
                await repo.InsertSesionAsync(sesion);
                return CreatedAtAction(nameof(GetSesion), sesion);
            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateSesion(Sesion sesion)
        {
            try
            {
                await repo.UpdateSesionAsync(sesion);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await repo.FindSesionAsync() == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [Authorize]
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteSesion()
        {
            var sesion = await repo.FindSesionAsync();
            if (sesion == null)
            {
                return NotFound();
            }

            await repo.DeleteSesionAsync();
            return NoContent();
        }
    }
}
