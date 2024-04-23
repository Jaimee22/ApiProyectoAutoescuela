using ApiProyectoAutoescuela.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAutoescuela.Models;

namespace ApiProyectoAutoescuela.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AutoescuelaController : ControllerBase
    {
        private RepositoryAutoescuela repo;

        public AutoescuelaController(RepositoryAutoescuela repo)
        {
            this.repo = repo;
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Autoescuela>>> GetAutoescuelas()
        {
            List<Autoescuela> autoescuelas = await this.repo.GetAutoescuelasAsync();
            return Ok(autoescuelas);
        }

        [Authorize]
        [HttpGet]
        [Route("[action]/{idAutoescuela}")]
        public async Task<ActionResult<Autoescuela>> Details(int idAutoescuela)
        {
            Autoescuela autoescuela = await this.repo.FindAutoescuela(idAutoescuela);
            if (autoescuela == null)
            {
                return NotFound();
            }
            return Ok(autoescuela);
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(Autoescuela autoescuela)
        {
            if (ModelState.IsValid)
            {
                await repo.InsertAutoescuelaAsync(autoescuela.NombreAutoescuela, autoescuela.DireccionAutoescuela, autoescuela.TelefonoAutoescuela);
                return Ok();
            }
            return BadRequest(ModelState);
        }


        [Authorize]
        [HttpPut]
        [Route("[action]/{idAutoescuela}")]
        public async Task<IActionResult> Edit(int idAutoescuela, Autoescuela autoescuela)
        {
            if (idAutoescuela != autoescuela.IdAutoescuela)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await repo.UpdateAutoescuelaAsync(autoescuela.IdAutoescuela, autoescuela.NombreAutoescuela, autoescuela.DireccionAutoescuela, autoescuela.TelefonoAutoescuela);
                return Ok();
            }
            return BadRequest(ModelState);
        }


        [Authorize]
        [HttpDelete]
        [Route("[action]/{idAutoescuela}")]
        public async Task<IActionResult> Delete(int idAutoescuela)
        {
            var autoescuela = await repo.FindAutoescuela(idAutoescuela);
            if (autoescuela == null)
            {
                return NotFound();
            }

            await repo.DeleteAutoescuelaAsync(idAutoescuela);
            return Ok();
        }




    }

}
