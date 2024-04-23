using ApiProyectoAutoescuela.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAutoescuela.Models;

namespace ApiProyectoAutoescuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {

        private RepositoryAutoescuela repo;

        public DocumentoController(RepositoryAutoescuela repo) 
        {
            this.repo = repo;
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Documento>>> GetDocumentos()
        {
            return await this.repo.GetDocumentosAsync();
        }


        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Alumno>>> GetDocumentosPorSeccion(int seccionId)
        {
            List<Documento> documentos = await repo.GetDocumentosPorSeccionAsync(seccionId);
            return Ok(documentos);
        }




    }
}
