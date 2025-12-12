using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApp.Domain.Interfaces.Services;

namespace UsuariosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController (IUsuarioService usuarioService) : ControllerBase
    {
        [HttpPost("autenticar")]
        public IActionResult Autenticar()
        {
            // Lógica de autenticação aquí
            return Ok();
        }

        [HttpPost("criar")]
        public IActionResult Criar()
        {
            return Ok();
        }
    }
}
