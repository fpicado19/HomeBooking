using System.Collections.Generic;
using Infraestructura.Models;

namespace Infraestructure.Repository
{
    public interface IRepositoryUsuario
    {

        Usuario GetUsuario(int id, string password);
        IEnumerable<Usuario> GetUsuarios();
        Usuario GetUsuarioByID(int id);
        void DeleteUsuario();
        Usuario Save(Usuario usuario);
    }
}
