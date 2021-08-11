using API.BuilderConfigurations;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public AppDbContext() { }
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FloorConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new SeatConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            SeedDb(modelBuilder);
        }

        private void SeedDb(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Name = "Admin"
                }
            );
            builder.Entity<Floor>().HasData(
                new Floor()
                {
                    Id = 1,
                    Number = 0,
                    Name = "Parter"
                },
                new Floor()
                {
                    Id = 2,
                    Number = 1,
                    Name = "Piętro 1"
                },
                new Floor()
                {
                    Id = 3,
                    Number = 2,
                    Name = "Piętro 2"
                }
            );
            builder.Entity<Room>().HasData(
                new Room()
                {
                    Id = 1,
                    Number = 1,
                    Name = "Portiernia",
                    Description = "Tylko dla portierki",
                    FloorId = 1
                },
                new Room()
                {
                    Id = 2,
                    Number = 101,
                    Name = "Pokój komputerowy",
                    Description = "Do pracy",
                    FloorId = 2
                },
                new Room()
                {
                    Id = 3,
                    Number = 102,
                    Name = "Sala konferencyjna",
                    Description = "Do konferencji",
                    FloorId = 2
                },
                new Room()
                {
                    Id = 4,
                    Number = 201,
                    Name = "Serwerownia",
                    Description = "Tylko dla informatyków",
                    FloorId = 3
                }
            );
            builder.Entity<Seat>().HasData(
                new Seat()
                {
                    Id = 1,
                    Name = "Fotel",
                    Description = null,
                    RoomId = 1
                },
                new Seat()
                {
                    Id = 2,
                    Name = "Krzesło 1",
                    Description = null,
                    RoomId = 2
                },
                new Seat()
                {
                    Id = 3,
                    Name = "Krzesło 2",
                    Description = null,
                    RoomId = 2
                },
                new Seat()
                {
                    Id = 4,
                    Name = "Taboret 1",
                    Description = null,
                    RoomId = 3
                },
                new Seat()
                {
                    Id = 5,
                    Name = "Taboret 2",
                    Description = null,
                    RoomId = 3
                },
                new Seat()
                {
                    Id = 6,
                    Name = "Pufa",
                    Description = null,
                    RoomId = 4
                }
            );
        }
    }
}
