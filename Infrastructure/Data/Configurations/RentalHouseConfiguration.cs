using StudentHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentHive.Infrastructure.Data.Configurations;


public class RentalHouseConfiguration : IEntityTypeConfiguration<RentalHouse>
{
    public void Configure(EntityTypeBuilder<RentalHouse> builder)
    {
        builder.ToTable("RentalHouses");
            builder.HasKey(e => e.IdPublication).HasName("PK__RentalHo__D4F61A3B6FE1A527");

            builder.HasIndex(e => e.IdLocation, "UQ__RentalHo__2F2C70A664E81AA9").IsUnique();

            builder.HasIndex(e => e.IdHouseService, "UQ__RentalHo__BBD08A225D92F9C2").IsUnique();

            builder.HasIndex(e => e.IdTypeHouseRental, "UQ__RentalHo__E17AD5E746021F62").IsUnique();

            builder.HasIndex(e => e.IdRentalHouseDetail, "UQ__RentalHo__EDFA085F830F8774").IsUnique();

            builder.Property(e => e.IdPublication).HasColumnName("ID_Publication");
            builder.Property(e => e.Description).IsUnicode(false);
            builder.Property(e => e.IdHouseService).HasColumnName("ID_HouseService");
            builder.Property(e => e.IdLocation).HasColumnName("ID_Location");
            builder.Property(e => e.IdRentalHouseDetail).HasColumnName("ID_RentalHouseDetail");
            builder.Property(e => e.IdTypeHouseRental).HasColumnName("ID_TypeHouseRental");
            builder.Property(e => e.IdUser).HasColumnName("ID_User");
            builder.Property(e => e.PublicationDate).HasColumnType("datetime");
            builder.Property(e => e.Title)
                .HasMaxLength(400)
                .IsUnicode(false);
            builder.Property(e => e.WhoElse)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.HasOne(d => d.IdHouseServiceNavigation).WithOne(p => p.RentalHouses)
                .HasForeignKey<RentalHouse>(d => d.IdHouseService)
                .HasConstraintName("FK__RentalHou__ID_Ho__49C3F6B7");

            builder.HasOne(d => d.IdLocationNavigation).WithOne(p => p.RentalHouses)
                .HasForeignKey<RentalHouse>(d => d.IdLocation)
                .HasConstraintName("FK__RentalHou__ID_Lo__48CFD27E");

            builder.HasOne(d => d.IdRentalHouseDetailNavigation).WithOne(p => p.RentalHouses)
                .HasForeignKey<RentalHouse>(d => d.IdRentalHouseDetail)
                .HasConstraintName("FK__RentalHou__ID_Re__46E78A0C");

            builder.HasOne(d => d.IdTypeHouseRentalNavigation).WithOne(p => p.RentalHouses)
                .HasForeignKey<RentalHouse>(d => d.IdTypeHouseRental)
                .HasConstraintName("FK__RentalHou__ID_Ty__47DBAE45");

            builder.HasOne(d => d.IdUserNavigation).WithMany(p => p.RentalHouses)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__RentalHou__ID_Us__4AB81AF0");
    }
}