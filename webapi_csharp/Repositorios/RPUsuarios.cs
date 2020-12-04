using System.Collections.Generic;
using System.Linq;
using webapi_csharp.Modelos;

namespace webapi_csharp.Repositorios
{
    public class RPUsuarios
    {
        public static List<usuario> _listaUsuarios = new List<usuario>()
        {
            new usuario() { Username = "User_1", Password = "111", Nombre = "Juan Perez" },
            new usuario() { Username = "User_2", Password = "222", Nombre = "Pedro Gonzalez" },
            new usuario() { Username = "User_3", Password = "333", Nombre = "Luis Santibañez"  }                    
        };

        public IEnumerable<usuario> ObtenerUsuario()
        {
            return _listaUsuarios;
        }

        public usuario ObtenerUsuario(string username)
        {
            var usuario = _listaUsuarios.Where(usu => usu.Username == username);

            return usuario.FirstOrDefault();
        }

        public void Agregar(usuario nuevoUsuario)
        {
            _listaUsuarios.Add(nuevoUsuario);
        }
    }
}