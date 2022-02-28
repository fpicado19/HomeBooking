using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Infraestructura.Models;
using web.Utils;

namespace Infraestructure.Repository
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        public void DeleteUsuario()
        {
            throw new NotImplementedException();
        }
        public Usuario GetUsuario(int ID, string password)
        {
            Usuario oUsuario = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oUsuario = ctx.Usuario.
                        Where(p => p.Identificacion.Equals(ID) && p.Contraseña == password).
                        FirstOrDefault<Usuario>();
                }
                if (oUsuario != null)
                    oUsuario = GetUsuarioByID(oUsuario.Identificacion);
                return oUsuario;
            }
            catch (DbUpdateException dbEx)
            {
                
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";

                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public Usuario GetUsuarioByID(int id)
        {
            Usuario usuario = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    usuario = ctx.Usuario.
                     Include("Rol").
                    Where(p => p.Identificacion == id).
                    FirstOrDefault<Usuario>();
                }
                return usuario;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            try
            {
                IEnumerable<Usuario> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.Usuario.ToList<Usuario>();
                }

                return lista;
            }

            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public Usuario Save(Usuario usuario)
        {
            int retorno = 0;
            Usuario oUsuario = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oUsuario = GetUsuarioByID(usuario.Identificacion);
                    if (oUsuario == null)
                    {
                        usuario.Estado = 1;
                        usuario.IdRol = 2;
                        ctx.Usuario.Add(usuario);

                    }
                    else
                    {
                        ctx.Entry(usuario).State = EntityState.Modified;
                    }
                    retorno = ctx.SaveChanges();
                }
                if (retorno >= 0)
                    oUsuario = GetUsuarioByID(usuario.Identificacion);
                return oUsuario;
            }

            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }
    }
}



