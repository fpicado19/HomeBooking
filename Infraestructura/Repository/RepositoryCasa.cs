using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Models;
using web.Utils;

namespace Infraestructura.Repository
{
    public class RepositoryCasa : IRepositoryCasa
    {
        public void DeleteCasa(int id)
        {
            throw new NotImplementedException();
        }
        public Casa GetCasaByID(int id)
        {
            Casa oCasa = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oCasa = ctx.Casa.Find(id);
                    
                }
                return oCasa;
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
        public IEnumerable<Casa> GetCasas()
        {
            IEnumerable<Casa> lista = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                lista = ctx.Casa.ToList();
            }
            return lista;
        }
        public IEnumerable<Casa> GetTipoCasa(int idTcasa)
        {
            IEnumerable<Casa> lista = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                lista = ctx.Casa.Where(l => l.IDTipoCasa == idTcasa).ToList();
            }
            return lista;
        }        
        public Casa Save(Casa casa)        
        {            
            int retorno = 0;            
            Casa oCasa = null;
                using (MyContext ctx = new MyContext())                
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oCasa = GetCasaByID((int)casa.IdCasa);
                //RepositoryTipoCasa repositoryTipoCasa = new RepositoryTipoCasa();

                if (oCasa == null)
                {                        
                    ////Insertar                        
                    ctx.Casa.Add(casa);                        
                    //SaveChanges                        
                    //guarda todos los cambios realizados en el contexto de la base de datos.                        
                    retorno = ctx.SaveChanges();                        
                    //retorna número de filas afectadas
                }                    
                else                    
                {
                    //Actualizar Casa           
                    ctx.Casa.Add(casa);
                    //Actualizar Categorias                        
                    ctx.Entry(casa).State = EntityState.Modified;                            
                    retorno = ctx.SaveChanges();        
                }                
            }                
            if (retorno >= 0)                   
                oCasa = GetCasaByID(casa.IdCasa);                
            return oCasa;
        }
    }
}
