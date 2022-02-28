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
    public class RepositoryReserva : IRepositoryReserva
    {
        public IEnumerable<Reserva> GetReserva()
        {
            List<Reserva> reservas = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    reservas = ctx.Reserva.
                               Include("Usuario").
                               ToList<Reserva>();
                }
                return reservas;
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
                throw new Exception(mensaje);
            }
        }

        public Reserva GetReservaByID(int id)
        {
            Reserva reservas = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    reservas = ctx.Reserva.
                               Include("Usuario").
                               Include("ReservaDetalles").
                               Include("ReservaDetalles.Casa").
                               Where(p => p.ID == id).
                               FirstOrDefault<Reserva>();
                }
                return reservas;
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
                throw new Exception(mensaje);
            }
        }
        public IEnumerable<Reserva> GetReservasByCliente(int id)
        {
            List<Reserva> reservas = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    reservas = ctx.Reserva.Include("Usuario").Where(r => r.IDCliente == id).ToList<Reserva>();
                }
                return reservas;
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
                throw new Exception(mensaje);
            }
        }

        public Reserva Save(Reserva reserva)
        {
            int resultado = 0;
            Reserva orden = null;
            try
            {
                // Salvar pero con transacción porque son 2 tablas
                // 1- Reserva
                // 2- ReservaDetalle 
                using (MyContext ctx = new MyContext())
                {
                    using (var transaccion = ctx.Database.BeginTransaction())
                    {
                        ctx.Reserva.Add(reserva);
                        resultado = ctx.SaveChanges();
                        foreach (var detalle in reserva.ReservaDetalles)
                        {
                            detalle.IDReserva = reserva.ID;
                        }

                        foreach (var item in reserva.ReservaDetalles)
                        {
                            // Busco el producto que está en el detalle por IdCasa
                            Casa oLibro = ctx.Casa.Find(item.IDCasa);

                            // Se indica que se alteró
                            ctx.Entry(oLibro).State = EntityState.Modified;
                            // Guardar                         
                            resultado = ctx.SaveChanges();
                        }
                        
                        // Commit 
                        transaccion.Commit();
                    }
                }
                // Buscar la orden que se salvó y reenviarla
                if (resultado >= 0)
                    orden = GetReservaByID(reserva.ID);
                return orden;
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
                throw new Exception(mensaje);
            }
        }
    }
}
