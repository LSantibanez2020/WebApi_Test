using System.ComponentModel.DataAnnotations;

namespace webapi_csharp.Modelos
{
    public class tarea
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Estado { get; set; }
        public string Descripcion { get; set; }
    }
}
