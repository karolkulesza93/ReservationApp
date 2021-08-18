using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.BuilderConfigurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(r => r.Description)
                .HasMaxLength(200);
            builder.Property(r => r.Start)
                .IsRequired();
            builder.Property(r => r.End)
                .IsRequired();
        }
    }
}
