using System.ComponentModel.DataAnnotations;

namespace webapi_csharp.Modelos
{
    public class usuario
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Nombre { get; set; }

    }
}