using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.BuilderConfigurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.ToTable("Seats");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(s => s.Description)
                .HasMaxLength(100);

            builder.HasOne(s => s.Room)
                .WithMany(r => r.Seats)
                .HasForeignKey(s => s.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Reservations)
                .WithOne(r => r.Seat)
                .HasForeignKey(r => r.SeatId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
