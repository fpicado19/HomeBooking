using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeBooking.Util;
using Infraestructura.Models;
using Web.Util;

namespace Web.ViewModel
{
    public class Carrito
    {
        public List<ViewModelOrdenDetalle> Casa { get; private set; }
        public List<ViewModelOrdenDetalle> TipoServicio { get; private set; }
        //Implementación Singleton
        // Las propiedades de solo lectura solo se pueden establecer en la inicialización o en un constructor
        public static readonly Carrito Instancia;
        // Se llama al constructor estático tan pronto como la clase se carga en la memoria
        static Carrito()
        {
            // Si el carrito no está en la sesión, cree uno y guarde los items.
            if (HttpContext.Current.Session["carrito"] == null)
            {
                Instancia = new Carrito();
                Instancia.Casa = new List<ViewModelOrdenDetalle>();
                Instancia.TipoServicio = new List<ViewModelOrdenDetalle>();
                HttpContext.Current.Session["carrito"] = Instancia;
            }
            else
            {
                // De lo contrario, obténgalo de la sesión.
                Instancia = (Carrito)HttpContext.Current.Session["carrito"];
            }
        } 
        // Un constructor protegido asegura que un objeto no se puede crear desde el exterior
        protected Carrito() { }

        /**
         * AgregarItem (): agrega un artículo a la compra
         */
        public String AgregarItem(int CasaId)
        {
            String mensaje = "";
            // Crear un nuevo artículo para agregar al carrito
            ViewModelOrdenDetalle nuevoItem = new ViewModelOrdenDetalle(CasaId);
            // Si este artículo ya existe en lista de libros, aumente la Cantidad
            // De lo contrario, agregue el nuevo elemento a la lista
            if (nuevoItem != null)
            {
                if (Casa.Exists(x => x.IdCasa == CasaId))
                {
                    ViewModelOrdenDetalle item = Casa.Find(x => x.IdCasa == CasaId);
                    item.Cantidad++;
                }
                else
                {
                    nuevoItem.Cantidad = 1;
                    Casa.Add(nuevoItem);
                }
                mensaje = SweetAlertHelper.Mensaje("Reserva Casa", "Casa agregada a la reserva", Util.SweetAlertMessageType.success);
            }
            else
            {
                mensaje = SweetAlertHelper.Mensaje("Reserva Casa", "La casa solicitada no existe", Util.SweetAlertMessageType.warning);
            }
            return mensaje;
        }
        public String AgregarItem2(float ServicioId)
        {
            String mensaje = "";
            // Crear un nuevo artículo para agregar al carrito
            ViewModelOrdenDetalle nuevoItem = new ViewModelOrdenDetalle(ServicioId);
            // Si este artículo ya existe en lista de libros, aumente la Cantidad
            // De lo contrario, agregue el nuevo elemento a la lista
            if (nuevoItem != null)
            {
                if (TipoServicio.Exists(x => x.idServicio == ServicioId))
                {
                    ViewModelOrdenDetalle item = TipoServicio.Find(x => x.idServicio == ServicioId);
                    item.CantidadServicios++;
                }
                else
                {
                    nuevoItem.CantidadServicios = 1;
                    TipoServicio.Add(nuevoItem);
                }
                mensaje = SweetAlertHelper.Mensaje("Reserva Casa", "Casa agregada a la reserva", Util.SweetAlertMessageType.success);
            }
            else
            {
                mensaje = SweetAlertHelper.Mensaje("Reserva Casa", "La casa solicitada no existe", Util.SweetAlertMessageType.warning);
            }
            return mensaje;
        }
        /**
         * SetItemCantidad(): cambia la Cantidad de un artículo en el carrito
         */
        public String SetItemCantidad(int CasaId, int Cantidad)
        {
            String mensaje = "";
            // Si estamos configurando la Cantidad a 0, elimine el artículo por completo
            if (Cantidad == 0)
            {
                EliminarItem(CasaId);
                mensaje = SweetAlertHelper.Mensaje("Reserva Casa", "Casa eliminado", Util.SweetAlertMessageType.success);
            }
            else
            {
                // Encuentra el artículo y actualiza la Cantidad
                ViewModelOrdenDetalle actualizarItem = new ViewModelOrdenDetalle(CasaId);
                if (Casa.Exists(x => x.IdCasa == CasaId))
                {
                    ViewModelOrdenDetalle item = Casa.Find(x => x.IdCasa == CasaId);
                    item.Cantidad = Cantidad;
                    mensaje = SweetAlertHelper.Mensaje("Reserva Casa", "Cantidad actualizada", Util.SweetAlertMessageType.success);
                }
            }
            return mensaje;
        }
        /**
         * EliminarItem (): elimina un artículo del carrito de compras
         */
        public String EliminarItem(int CasaId)
        {
            String mensaje = "La casa no existe";
            if (Casa.Exists(x => x.IdCasa == CasaId))
            {
                var itemEliminar = Casa.Single(x => x.IdCasa == CasaId);
                Casa.Remove(itemEliminar);
                mensaje = SweetAlertHelper.Mensaje("Reserva Casa", "Casa eliminada", Util.SweetAlertMessageType.success);
            }
            return mensaje;
        }
        public double AllSubTotal()
        {
            double stotal = 0;
            stotal = (double)Casa.Sum(x => x.SubTotalCasa) + (double)TipoServicio.Sum(x => x.SubTotalServicio);           
            return stotal;
        }
        public double AllSubTotalAndIVA()
        {
            double stotal = 0;
            stotal = (double)Casa.Sum(x => x.SubTotalCasa) + (double)TipoServicio.Sum(x => x.SubTotalServicio);

            return stotal * 0.30;
        }
        public int GetCountItems()
        {
            int total = 0;
            total = Casa.Sum(x => x.Cantidad) + TipoServicio.Sum(x => x.CantidadServicios);

            return total;
        }
        public void eliminarCarrito()
        {
            Casa.Clear();
        }
    }
}