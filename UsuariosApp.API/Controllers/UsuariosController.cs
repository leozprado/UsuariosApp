using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApp.Domain.Dtos;
using UsuariosApp.Domain.Interfaces.Services;

namespace UsuariosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController(IUsuarioService usuarioService) : ControllerBase
    {
        [HttpPost("autenticar")]
        [ProducesResponseType(typeof(AutenticarResponse), 200)]
        public IActionResult Autenticar([FromBody] AutenticarRequest request)
        {
            try
            {
                var response = usuarioService.Autenticar(request);

                //HTTP 200 (OK)
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                //HTTP 401 (UNAUTHORIZED)
                return StatusCode(401, new { e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPost("criar")]
        [ProducesResponseType(typeof(CriarContaResponse), 201)]
        public IActionResult Criar([FromBody] CriarContaRequest request)
        {
            try
            {
                var response = usuarioService.CriarConta(request);

                //HTTP 201 (CREATED)
                return StatusCode(201, response);
            }
            catch (ValidationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new { e.Errors });
            }
            catch (ApplicationException e)
            {
                //HTTP 409 (CONFLICT)
                return StatusCode(409, new { e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
