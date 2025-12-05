using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UsuariosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpPost("autenticar")]
        public IActionResult Autenticar()
        {
            // Lógica de autenticación aquí
            return Ok();
        }

        [HttpPost("criar")]
        public IActionResult Criar()
        {
            return Ok();
        }
    }
}
