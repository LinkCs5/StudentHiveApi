using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using StudentHive.Infrastructure.Data.Configurations;

namespace StudentHive.Domain.Entities;

public partial class StudentHiveDbContext : DbContext
{
    public StudentHiveDbContext()
    {
    }

    public StudentHiveDbContext(DbContextOptions<StudentHiveDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Arrendador> Arrendadores { get; set; }

    public virtual DbSet<Inquilino> Inquilinos { get; set; }

    public virtual DbSet<Match> Matchs { get; set; }

    public virtual DbSet<Publicacion> Publicaciones { get; set; }

    public virtual DbSet<Reservacion> Reservaciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration( new ArrendadorConfiguration());
        modelBuilder.ApplyConfiguration(new InquilinoConfiguration());
        modelBuilder.ApplyConfiguration(new MatchConfiguration());
        modelBuilder.ApplyConfiguration(new PublicacionConfiguration());
        modelBuilder.ApplyConfiguration(new ReservacionConfiguration());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
