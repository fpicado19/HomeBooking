
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
    
public partial class ServicioSolicitado
{

    public int IDServicio { get; set; }

    public int IDReservaDetalles { get; set; }

    public int ID { get; set; }



    public virtual TipoServicio TipoServicio { get; set; }

    public virtual Reserva Reserva { get; set; }

}

}
