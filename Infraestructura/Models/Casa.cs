
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
    
public partial class Casa
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Casa()
    {

        this.ReservaDetalles = new HashSet<ReservaDetalles>();

    }


    public int IdCasa { get; set; }

    public string Descripcion { get; set; }

    public int Precio { get; set; }

    public int IDTipoCasa { get; set; }

    public byte[] Foto { get; set; }



    public virtual TipoCasa TipoCasa { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ReservaDetalles> ReservaDetalles { get; set; }

}

}
