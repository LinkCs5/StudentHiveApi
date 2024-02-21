using StudentHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentHive.Infrastructure.Data.Configurations;


public class HouseServiceConfiguration : IEntityTypeConfiguration<HouseService>
{
    public void Configure(EntityTypeBuilder<HouseService> builder)
    {
            builder.ToTable("HouseServices");
            builder.HasKey(e => e.IdHouseService).HasName("PK__HouseSer__BBD08A233EB3B5AC");
            builder.Property(e => e.IdHouseService).HasColumnName("ID_HouseService");


    }
}