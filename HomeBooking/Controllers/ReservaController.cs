using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ApplicationCore.Services;
using Infraestructura.Models;
using web.Utils;
using Web.Util;
using Web.ViewModel;

namespace HomeBooking.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
        public ActionResult Index()
        {
            if (TempData.ContainsKey("NotificationMessage"))
            {
                ViewBag.NotificationMessage = TempData["NotificationMessage"];
            }
            ViewBag.idCliente = listaClientes();

            ViewBag.DetalleOrden = Carrito.Instancia.Casa;
            return View();
        }
        private SelectList listaClientes()
        {
            //Lista de Clientes
            IServiceUsuario _ServiceUsuario = new ServiceUsuario();
            IEnumerable<Usuario> listaUsuairo = (IEnumerable<Usuario>)_ServiceUsuario.GetUsuarios();

            return new SelectList(listaUsuairo, "Identificacion", "Nombre");
        }
        public ActionResult ordenarCasa(int? idCasa)
        {
            int cantidadCasas = Carrito.Instancia.Casa.Count();
            ViewBag.NotiCarrito = Carrito.Instancia.AgregarItem((int)idCasa);
            return PartialView("_OrdenCantidad");
        }
        public ActionResult ordenarServicio(int? idServicio)
        {
            int cantidadServicios = Carrito.Instancia.TipoServicio.Count();
            ViewBag.NotiCarrito = Carrito.Instancia.AgregarItem2((int)idServicio);
            return PartialView("_OrdenCantidad");
            //return View("carrito", "Reserva");
        }

        //Actualizar Vista parcial detalle carrito
        private ActionResult DetalleCarrito()
        {
            return PartialView("_DetalleOrden", Carrito.Instancia.Casa);
        }
        public ActionResult eliminarCasa(int? idCasa)
        {
            ViewBag.NotificationMessage = Carrito.Instancia.EliminarItem((int)idCasa);
            return PartialView("_DetalleOrden", Carrito.Instancia.Casa);
        }

        public ActionResult IndexAdmin()
        {
            IEnumerable<Reserva> lista = null;

            try
            {
                IServiceReserva _ServiceReserva = new ServiceReserva();
                lista = _ServiceReserva.GetReserva();
                return View(lista);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Reserva";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult IndexCliente(int id)
        {
            IEnumerable<Reserva> lista = null;

            try
            {
                IServiceReserva _ServiceReserva = new ServiceReserva();
                lista = _ServiceReserva.GetReservasByCliente(id);
                return View(lista);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Reserva";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult Details(int? id)
        {
            ServiceReserva _ServiceReserva = new ServiceReserva();
            Reserva reserva = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }
                reserva = _ServiceReserva.GetReservaByID(id.Value);
                if (reserva == null)
                {
                    TempData["Message"] = "No existe la reserva solicitada";
                    TempData["Redirect"] = "Reserva";
                    TempData["Redirect-Action"] = "IndexAdmin";
                    //TempData.Keep();
                    return RedirectToAction("IndexAdmin", "Reserva");
                }
                return View(reserva);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Reserva";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        [HttpPost]
        //[CustomAuthorize((int)Roles.Administrador, (int)Roles.Procesos)]
        public ActionResult Save(Reserva reserva)
        {
            try
            {
                // Si no existe la sesión no hay nada
                if (Carrito.Instancia.Casa.Count() <= 0)
                {
                    // Validaciones de datos requeridos.
                    TempData["NotificationMessage"] = SweetAlertHelper.Mensaje("Reserva", "Seleccione la Casa a reservar", SweetAlertMessageType.warning);
                    return RedirectToAction("Index");
                }
                else
                {
                    var listaDetalle = Carrito.Instancia.Casa;

                    foreach (var item in listaDetalle)
                    {
                        ReservaDetalles reservaDetalles = new ReservaDetalles();
                        reservaDetalles.IDCasa = item.IdCasa;
                        reservaDetalles.Precio = (int)item.PrecioCasa;

                        //ordenDetalle.Cantidad = item.Cantidad;
                        //reserva.ReservaDetalles.Add(reservaDetalles);
                    }
                }

                IServiceReserva _ServiceReserva = new ServiceReserva();
                Reserva reservaSave = _ServiceReserva.Save(reserva);

                // Limpia el Carrito de compras
                Carrito.Instancia.eliminarCarrito();
                TempData["NotificationMessage"] = SweetAlertHelper.Mensaje("Reserva", "Reserva guardada satisfactoriamente!", SweetAlertMessageType.success);
                // Reporte orden
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Salvar el error  
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Reserva";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        public ActionResult Menu()
        {
            
            IEnumerable<Casa> listaCasas = null;
            try
            {
                IServiceCasa _ServiceProducto = new ServiceCasa();
                listaCasas = _ServiceProducto.GetCasas();
                return View(listaCasas);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "¡Error al procesar los datos!" + ex.Message;

                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult MenuServicios()
        {
            IEnumerable<TipoServicio> listaServicios = null;
            try
            {
                IServiceServicio _ServiceProducto = new ServiceServicio();
                listaServicios = _ServiceProducto.GetServicio();
                return View(listaServicios);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "¡Error al procesar los datos!" + ex.Message;

                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult carrito()
        {
            IEnumerable<TipoServicio> listaServicios = null;
            IServiceServicio _ServiceServicio = new ServiceServicio();

            listaServicios = _ServiceServicio.GetServicio();

            if (TempData.ContainsKey("NotificationMessage"))
            {
                ViewBag.NotificationMessage = TempData["NotificationMessage"];
            }
            //ViewBag.idCliente = listaClientes();
            ViewBag.VServicios = listaServicios;

            ViewBag.DetalleOrdenCasa = Carrito.Instancia.Casa;
            ViewBag.DetalleOrdenServicio = Carrito.Instancia.TipoServicio;

            return View();
        }

        public ActionResult registarReserva(Reserva reserva)
        {
            
            try
            {
                if (Carrito.Instancia.Casa.Count() <= 0)
                {
                    TempData["NotificationMessage"] = SweetAlertHelper.Mensaje("Reserva", "Seleccione alguna Casa", SweetAlertMessageType.warning);
                    return RedirectToAction("Menu");
                }
                else
                {

                    var listaDetalle = Carrito.Instancia.Casa;

                    foreach (var item in listaDetalle)
                    {
                        ReservaDetalles productoPedido = new ReservaDetalles();
                        ServicioSolicitado servicioPedido = new ServicioSolicitado();
                        productoPedido.IDCasa = item.IdCasa;
                        productoPedido.IDReserva = reserva.ID;
                        productoPedido.Precio = (int)item.PrecioCasa;
                        productoPedido.IDReservaDetalles = reserva.ID;

                        //servicioPedido.IDReservaDetalles = reserva.ID;
                        //servicioPedido.IDServicio = item.idServicio;
                        //servicioPedido.ID = reserva.ID;

                        //reserva.ServicioSolicitado.Add(servicioPedido);
                        
                        
                        reserva.ReservaDetalles.Add(productoPedido);
                        
                    }
                }
                var seed = Environment.TickCount;
                var random = new Random(seed);
                reserva.ID = random.Next(0, 100);
                reserva.SubTotal= Carrito.Instancia.AllSubTotal();
                IServiceReserva _ServicePedido = new ServiceReserva();
                Reserva pedidoSave = _ServicePedido.Save(reserva);


                Carrito.Instancia.eliminarCarrito();
                TempData["NotificationMessage"] = SweetAlertHelper.Mensaje("Reserva", "¡Reserva guardado satisfactoriamente!", SweetAlertMessageType.success);
                return RedirectToAction("ClienteHome", "Home");//Redirecionar al menu de inicio
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Pedido";
                TempData["Redirect-Action"] = "Carrito";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}