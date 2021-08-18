using System.Collections;
using System.Collections.Generic;
using System.Linq;
using API.BuilderConfigurations;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
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
            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder builder)
        {
            SeedRoles(builder);
            SeedUsers(builder);
            SeedFloors(builder);
            SeedRooms(builder);
            SeedSeats(builder);
            SeedReservations(builder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
                    builder.Entity<Role>().HasData(GetRoles());
        }
        private void SeedUsers(ModelBuilder builder)
        {
                    builder.Entity<User>().HasData(GetUsers());
        }
        private void SeedFloors(ModelBuilder builder)
        {
                builder.Entity<Floor>().HasData(GetFloors());
        }
        private void SeedRooms(ModelBuilder builder)
        {
                builder.Entity<Room>().HasData(GetRooms());
        }
        private void SeedSeats(ModelBuilder builder)
        {
                builder.Entity<Seat>().HasData(GetSeats());
        }
        private void SeedReservations(ModelBuilder builder)
        {
                builder.Entity<Reservation>().HasData(GetReservations());
        }

        private IEnumerable<Role> GetRoles()
        {
            return new List<Role>()
            {
                new Role()
                {
                    Id = 1,
                    Name = "User"
                },
                new Role()
                {
                    Id = 2,
                    Name = "Admin"
                }
            };
        }
        private IEnumerable<User> GetUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = 1,
                    UserName = "logged_user",
                    FirstName = "Ędward",
                    LastName = "Ącki",
                    PasswordHash = "qaz123",
                    RoleId = 1
                },
                new User()
                {
                    Id = 2,
                    UserName = "ADMIN",
                    FirstName = "Karol",
                    LastName = "Kulesza",
                    PasswordHash = "qaz123",
                    RoleId = 2
                }
            };
        }
        private IEnumerable<Floor> GetFloors()
        {
            return new List<Floor>()
            {
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
            };
        }
        private IEnumerable<Room> GetRooms()
        {
            return new List<Room>()
            {
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
            };
        }
        private IEnumerable<Seat> GetSeats()
        {
            return new List<Seat>()
            {
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
            };
        }
        private IEnumerable<Reservation> GetReservations()
        {
            return new List<Reservation>();
        }
    }
}
