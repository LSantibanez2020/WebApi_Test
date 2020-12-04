using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_csharp.Modelos;
using webapi_csharp.Repositorios;

namespace webapi_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        List<tarea> _tareas { get; set; }

        [HttpGet]
        public IActionResult Get()
        {
            RPTareas rpTar = new RPTareas();
            return Ok(rpTar.ObtenerTarea());
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            RPTareas rpTar = new RPTareas();

            var tarRet = rpTar.ObtenerTarea(name);

            if (tarRet == null)
            {
                var nf = NotFound("La Tarea con el Nombre " + name + " no existe.");
                return nf;
            }

            return Ok(tarRet);
        }

        [HttpPost("agregar")]
        public IActionResult AgregarTarea(tarea nuevaTarea)
        {
            RPTareas rpTar = new RPTareas();
            rpTar.Agregar(nuevaTarea);
            return CreatedAtAction(nameof(AgregarTarea), nuevaTarea);
        }

        [HttpPatch("{name}")]
        public IActionResult ModificaTarea(string name, [FromBody] JsonPatchDocument<tarea> item)
        {
            var UpdTar = _tareas.Where(tar => tar.Nombre == name);
            var entity = UpdTar.FirstOrDefault(tar => tar.Nombre == name);

            if (entity == null)
            {
                return NotFound();
            }

            item.ApplyTo(entity, ModelState);
            return Ok(entity);
        }
    }
}