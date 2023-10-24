using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Data.Configurations;

namespace StudentHive.Infrastructure.Data;

public partial class StudentHiveDbContext : DbContext
{
    public StudentHiveDbContext()
    {
    }

    public StudentHiveDbContext(DbContextOptions<StudentHiveDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Habitacion> Habitaciones { get; set; }

    public virtual DbSet<Publicacion> Publicaciones { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new HabitacionConfiguration());
        modelBuilder.ApplyConfiguration(new PublicacionConfiguration());
        modelBuilder.ApplyConfiguration(new ReservaConfiguration());
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
