﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class Booking_HomeEntities : DbContext
{
    public Booking_HomeEntities()
        : base("name=Booking_HomeEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Casa> Casa { get; set; }

    public virtual DbSet<Factura> Factura { get; set; }

    public virtual DbSet<Reserva> Reserva { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<TipoCasa> TipoCasa { get; set; }

    public virtual DbSet<TipoPago> TipoPago { get; set; }

    public virtual DbSet<TipoServicio> TipoServicio { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<ReservaDetalles> ReservaDetalles { get; set; }

    public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

    public virtual DbSet<ServicioSolicitado> ServicioSolicitado { get; set; }

}

}
