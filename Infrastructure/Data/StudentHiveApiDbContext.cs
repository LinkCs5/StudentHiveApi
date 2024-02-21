using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Data.Configurations;

namespace StudentHive.Infrastructure.Data;

public partial class StudentHiveApiDbContext : DbContext
{
    public StudentHiveApiDbContext()
    {
    }

    public StudentHiveApiDbContext(DbContextOptions<StudentHiveApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<HouseService> HouseServices { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<RentalHouseDetail> RentalHouseDetails { get; set; }

    public virtual DbSet<RentalHouse> RentalHouses { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<TypesHouseRental> TypesHouseRental { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RentalHouseDetailConfiguration());
        modelBuilder.ApplyConfiguration(new RequestConfiguration());
        modelBuilder.ApplyConfiguration(new RentalHouseConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TypesHouseRentalConfiguration());
        modelBuilder.ApplyConfiguration(new NotificationConfiguration());
        modelBuilder.ApplyConfiguration(new LocationConfiguration());
        modelBuilder.ApplyConfiguration(new ImageConfiguration());
        modelBuilder.ApplyConfiguration(new HouseServiceConfiguration());
        modelBuilder.ApplyConfiguration(new EventConfiguration());
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
