using StudentHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentHive.Infrastructure.Data.Configurations;


public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("Images");
            builder.HasKey(e => e.IdImage).HasName("PK__Images__31E45A2A32264131");
            builder.Property(e => e.IdImage).HasColumnName("ID_Image");
            builder.Property(e => e.IdPublication).HasColumnName("ID_Publication");
            builder.Property(e => e.UrlImageHouse).IsUnicode(false);
            builder.HasOne(d => d.IdPublicationNavigation).WithMany(p => p.Images)
                .HasForeignKey(d => d.IdPublication)
                .HasConstraintName("FK__Images__ID_Publi__4D94879B");

    }
}