using ApplicationCore.Services;
using Infraestructura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ViewModel
{
    public class ViewModelOrdenDetalle
    {
        public int IdOrden { get; set; }
        public int IdCasa { get; set; }
        //public byte[] Imagen { get; set; }
        public int Cantidad { get; set; }
        public int CantidadServicios { get; set; }
        public int idServicio { get; set; }
        
        public decimal PrecioCasa
        {
            get { return casa.Precio; }

        }
        public decimal PrecioServicio
        {
            get { return Servicios.Precio; }

        }
        public virtual Casa casa { get; set; }
        public virtual TipoServicio Servicios { get; set; }
        public decimal SubTotalCasa
        {
            get
            {
                return calculoSubtotal();
            }
        }
        public decimal SubTotalServicio
        {
            get
            {
                return calculoSubtotalServicio();
            }
        }
        private decimal calculoSubtotal()
        {
            return this.PrecioCasa * this.Cantidad;
        }
        private decimal calculoSubtotalServicio()
        {
            return this.PrecioServicio * this.CantidadServicios;
        }
        public ViewModelOrdenDetalle(int Idcasa)
        {
            IServiceCasa _ServiceCasa = new ServiceCasa();
            //IServiceServicio serviceServicio = new ServiceServicio();
            this.IdCasa = Idcasa;
            //this.idServicio = idServicio;
            this.casa = _ServiceCasa.GetCasaByID(Idcasa);
            //this.Servicios = serviceServicio.GetServicioByID(idServicio);
        }
        public ViewModelOrdenDetalle(float idServicio)
        {
            //IServiceCasa _ServiceCasa = new ServiceCasa();
            IServiceServicio serviceServicio = new ServiceServicio();
            //this.IdCasa = Idcasa;
            this.idServicio = (int)idServicio;
            //this.casa = _ServiceCasa.GetCasaByID(Idcasa);
            this.Servicios = serviceServicio.GetServicioByID((int)idServicio);
        }
        public TipoServicio BuscarServicioByID(int idServicio)
        {
            IServiceServicio serviceServicio = new ServiceServicio();
            this.idServicio = idServicio;
            this.Servicios = serviceServicio.GetServicioByID(idServicio);
            return this.Servicios;
        }
    }
}