﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeriesAngularDAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SeriesDBEntities : DbContext
    {
        public SeriesDBEntities()
            : base("name=SeriesDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Actor> Actores { get; set; }
        public virtual DbSet<Capitulo> Capitulos { get; set; }
        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<Serie> Series { get; set; }
        public virtual DbSet<Temporada> Temporadas { get; set; }
        public virtual DbSet<Usuario_Serie> Usuario_Series { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
