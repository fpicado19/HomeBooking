using System;
using System.Collections.Generic;
using ApplicationCore.Util;
using Infraestructura.Models;
using Infraestructure.Repository;

namespace ApplicationCore.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        public void DeleteUsuario()
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuario(int id, string password)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            // Encriptar el password para poder compararlo
            //string crytpPasswd = Cryptography.EncrypthAES(password);
            return repository.GetUsuario(id,password);
        }

        public Usuario GetUsuarioByID(int id)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            Usuario oUsuario = repository.GetUsuarioByID(id);
            //oUsuario.Contraseña = Cryptography.DecrypthAES(oUsuario.Contraseña);
            return oUsuario;

        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            return repository.GetUsuarios();
        }

        public Usuario Save(Usuario usuario)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            //usuario.Contraseña = Cryptography.EncrypthAES(usuario.Contraseña);
            return repository.Save(usuario);
        }
    }
}
