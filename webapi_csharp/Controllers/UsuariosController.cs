using Microsoft.AspNetCore.Mvc;
using webapi_csharp.Modelos;
using webapi_csharp.Repositorios;

namespace webapi_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            RPUsuarios rpUsu = new RPUsuarios();
            return Ok(rpUsu.ObtenerUsuario());
        }

        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            RPUsuarios rpUsu = new RPUsuarios();

            var usuRet = rpUsu.ObtenerUsuario(username);

            if (usuRet == null)
            {
                var nf = NotFound("El usuario " + username + " no existe.");
                return nf;
            }

            return Ok(usuRet);
        }

        [HttpPost("agregar")]
        public IActionResult AgregarUsuario(usuario nuevoUsuario)
        {
            RPUsuarios rpUsu = new RPUsuarios();
            rpUsu.Agregar(nuevoUsuario);
            return CreatedAtAction(nameof(AgregarUsuario), nuevoUsuario);
        }
    }
}