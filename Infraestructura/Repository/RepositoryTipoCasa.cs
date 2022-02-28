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
    public class RepositoryTipoCasa : IRepositoryTipoCasa
    {
        public void DeleteTipoCasa(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoCasa> GetTipoCasa()
        {
            try
            {
                IEnumerable<TipoCasa> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.TipoCasa.Include("Casa").ToList<TipoCasa>();
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

        public TipoCasa GetTipoCasaByID(int id)
        {
            TipoCasa tipoC = null;
            try
            {

                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    tipoC = ctx.TipoCasa.Find(id);
                }

                return tipoC;
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

        public TipoCasa Save(TipoCasa tipo)
        {
            int retorno = 0;
            TipoCasa oTipoC = null;
            try
            {

                using (MyContext ctx = new MyContext())
                {

                    ctx.Configuration.LazyLoadingEnabled = false;
                    oTipoC = GetTipoCasaByID(tipo.ID);
                    if (oTipoC == null)
                    {
                        ctx.TipoCasa.Add(tipo);
                    }
                    else
                    {
                        ctx.Entry(tipo).State = EntityState.Modified;
                    }
                    retorno = ctx.SaveChanges();
                }

                if (retorno >= 0)
                    oTipoC = GetTipoCasaByID(tipo.ID);

                return oTipoC;
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
    }
}
