
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Infraestructura.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Reserva
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Reserva()
    {

        this.ReservaDetalles = new HashSet<ReservaDetalles>();

        this.Factura = new HashSet<Factura>();

        this.ServicioSolicitado = new HashSet<ServicioSolicitado>();

    }


    public int IDCliente { get; set; }

    public System.DateTime FechaLlegada { get; set; }

    public System.DateTime FechaSalida { get; set; }

    public int ID { get; set; }

    public double SubTotal { get; set; }



    public virtual Usuario Usuario { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ReservaDetalles> ReservaDetalles { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Factura> Factura { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ServicioSolicitado> ServicioSolicitado { get; set; }

}

}