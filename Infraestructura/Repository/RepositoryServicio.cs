using Infraestructura.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.Utils;

namespace Infraestructura.Repository
{
    public class RepositoryServicio : IRepositoryServicio
    {
        public void DeleteServicio(int ID)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<TipoServicio> GetServicio()
        {
            IEnumerable<TipoServicio> lista = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                lista = ctx.TipoServicio.ToList();
            }
            return lista;
        }
        public TipoServicio GetServicioByID(int ID)
        {
            TipoServicio olibro = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                olibro = ctx.TipoServicio.Where(l => l.ID == ID).FirstOrDefault();
            }
            return olibro;
        }

        public TipoServicio Save(TipoServicio servicio)
        {
            int retorno = 0;
            TipoServicio oServicio = null;

                using (MyContext ctx = new MyContext())
                {
                ctx.Configuration.LazyLoadingEnabled = false;
                oServicio = GetServicioByID((int)servicio.ID);

                if (oServicio == null)
                    {
                        ctx.TipoServicio.Add(servicio);
                        //SaveChanges
                        //guarda todos los cambios realizados en el contexto de la base de datos.
                        retorno = ctx.SaveChanges();
                        //retorna número de filas afectadas
                    }
                    else
                    {
                        //Registradas: 1,2,3
                        //Actualizar: 1,3,4
                        //Actualizar Servicio
                        ctx.TipoServicio.Add(servicio);
                        ctx.Entry(servicio).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }
                }
                if (retorno >= 0)
                    oServicio = GetServicioByID(servicio.ID);
                return oServicio;
        }
    }
}
