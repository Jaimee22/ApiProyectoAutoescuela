//using ApiProyectoAutoescuela.Repositories;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using ProyectoAutoescuela.Models;
//using ProyectoAutoescuela.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace ProyectoAutoescuela.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsuarioController : ControllerBase
//    {
//        private RepositoryAutoescuela repo;

//        public UsuarioController(RepositoryAutoescuela repo)
//        {
//            this.repo = repo;
//        }

//        [HttpPost("Register")]
//        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            try
//            {
//                await this.repo.RegisterUserAsync(model.Nombre, model.Email, model.Password);
//                return Ok("Usuario registrado correctamente.");
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Error al registrar usuario: {ex.Message}");
//            }
//        }

//        [HttpPost("Login")]
//        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            try
//            {
//                Usuario usuario = await this.repo.LoginUserAsync(model.Email, model.Password);
//                if (usuario == null)
//                {
//                    return BadRequest("Credenciales incorrectas.");
//                }

//                // Aquí podrías utilizar JWT para generar un token y devolverlo en lugar de simplemente redirigir
//                return Ok("Usuario autenticado correctamente.");
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Error al autenticar usuario: {ex.Message}");
//            }
//        }

//        [HttpPost("Logout")]
//        public IActionResult Logout()
//        {
//            // Elimina la sesión del usuario
//            HttpContext.Session.Remove("UserId");
//            return Ok("Sesión cerrada correctamente.");
//        }

//        [HttpGet("MostrarSecciones")]
//        public async Task<IActionResult> MostrarSecciones()
//        {
//            try
//            {
//                // Obtener el ID de usuario de la sesión
//                int? usuarioId = HttpContext.Session.GetInt32("UserId");

//                // Verificar si el ID de usuario existe en la sesión
//                if (usuarioId.HasValue)
//                {
//                    // Obtener las secciones del usuario usando el ID recuperado de la sesión
//                    List<Seccion> secciones = await repo.GetSeccionesUsuarioAsync(usuarioId.Value);

//                    return Ok(secciones);
//                }
//                else
//                {
//                    // Si el ID de usuario no está en la sesión, devolver un código de estado 401 (No autorizado)
//                    return StatusCode(401, "No se encontró el ID de usuario en la sesión.");
//                }
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Error al obtener las secciones del usuario: {ex.Message}");
//            }
//        }

//        [HttpGet("DropdownSecciones")]
//        public async Task<IActionResult> DropdownSecciones()
//        {
//            try
//            {
//                // Obtener el ID de usuario de la sesión
//                int? usuarioId = HttpContext.Session.GetInt32("UserId");

//                // Verificar si el ID de usuario existe en la sesión
//                if (usuarioId.HasValue)
//                {
//                    // Obtener las secciones del usuario usando el ID recuperado de la sesión
//                    List<Seccion> secciones = await repo.GetSeccionesUsuarioAsync(usuarioId.Value);

//                    return Ok(secciones);
//                }
//                else
//                {
//                    // Si el ID de usuario no está en la sesión, devolver un código de estado 401 (No autorizado)
//                    return StatusCode(401, "No se encontró el ID de usuario en la sesión.");
//                }
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Error al obtener las secciones del usuario: {ex.Message}");
//            }
//        }

//        [HttpPost("GuardarSeccionId")]
//        public IActionResult GuardarSeccionId([FromBody] int seccionId)
//        {
//            // Guardar el valor en la sesión
//            HttpContext.Session.SetInt32("SeccionId", seccionId);
//            return Ok("Sección guardada correctamente.");
//        }
//    }
//}
