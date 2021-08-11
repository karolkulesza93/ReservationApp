using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.BuilderConfigurations
{
    public class FloorConfiguration : IEntityTypeConfiguration<Floor>
    {
        public void Configure(EntityTypeBuilder<Floor> builder)
        {
            builder.ToTable("Floors");

            builder.HasKey(f => f.Id);
            builder.HasAlternateKey(f => f.Number);

            builder.Property(f => f.Number)
                .IsRequired();
            builder.Property(f => f.Name)
                .HasMaxLength(50);

            builder.HasMany(f => f.Rooms)
                .WithOne(r => r.Floor)
                .HasForeignKey(r => r.FloorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
