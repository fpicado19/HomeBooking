using Infraestructura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
   public interface IServiceUsuario
    {
        Usuario GetUsuario(int ID, string password);
        IEnumerable<Usuario> GetUsuarios();
        Usuario GetUsuarioByID(int id);
        void DeleteUsuario();
        Usuario Save(Usuario usuario);
    }
}
