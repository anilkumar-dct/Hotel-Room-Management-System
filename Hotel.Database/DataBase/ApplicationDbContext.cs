using Hotel.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomManagementSystem
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Workers> Workers { get; set; }
        public DbSet<Rooms> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workers>().HasData(
                new Workers
                {
                    ID = 001,
                    Name = "Jone",
                    Availability="Available",
                    RoomNumber=101,
                },
                 new Workers
                 {
                     ID = 002,
                     Name = "Sarah Jonshon",
                     Availability = "Occupied",
                     RoomNumber = 102,
                 },
                  new Workers
                  {
                      ID = 003,
                      Name = "Emily",
                      Availability = "On Break",
                      RoomNumber = 103,
                  }
                );
            modelBuilder.Entity<Rooms>().HasData();
        }
    }
}