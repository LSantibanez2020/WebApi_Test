using System.Collections.Generic;
using System.Linq;
using webapi_csharp.Modelos;

namespace webapi_csharp.Repositorios
{
    public class RPTareas
    {
        public List<tarea> _listaTareas = new List<tarea>()
        {
            new tarea() { Nombre = "Tarea 1", Estado = "Incompleta", Descripcion = "" },
            new tarea() { Nombre = "Tarea 2", Estado = "Incompleta", Descripcion = "" },
            new tarea() { Nombre = "Tarea 3", Estado = "Completa"  , Descripcion = "" }
        };

        public IEnumerable<tarea> ObtenerTarea()
        {
            return _listaTareas;
        }

        public tarea ObtenerTarea(string name)
        {
            var tarea = _listaTareas.Where(tar => tar.Nombre == name);

            return tarea.FirstOrDefault();
        }

        public void Agregar(tarea nuevaTarea)
        {
            _listaTareas.Add(nuevaTarea);
        }
    }
}