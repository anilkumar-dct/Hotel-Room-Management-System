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
                    Availability=WorkerStatus.Available,
                    RoomNumber="101",
                    RoomId=1,
                    
                },
                 new Workers
                 {
                     ID = 002,
                     Name = "Sarah Jonshon",
                     Availability = WorkerStatus.Occupied ,
                     RoomNumber = "102",
                     RoomId=2,
                 },
                  new Workers
                  {
                      ID = 003,
                      Name = "Emily",
                      Availability =WorkerStatus.OnBreak ,
                      RoomNumber = "103",
                      RoomId=3,
                  }
                );
            modelBuilder.Entity<Rooms>().HasData(
                new Rooms
                {
                    ID=1,
                    RoomNumber="101",
                    Status=RoomStatus.Occupied,
                },
                 new Rooms
                 {
                     ID = 2,
                     RoomNumber = "102",
                     Status = RoomStatus.Available,
                 },
                  new Rooms
                  {
                      ID = 3,
                      RoomNumber = "103",
                      Status = RoomStatus.UnderMaintenance,
                  },
                   new Rooms
                   {
                       ID = 4,
                       RoomNumber = "104",
                       Status = RoomStatus.Available,
                   },
                    new Rooms
                    {
                        ID = 5,
                        RoomNumber = "105",
                        Status = RoomStatus.Occupied,
                    },
                     new Rooms
                     {
                         ID = 6,
                         RoomNumber = "106",
                         Status = RoomStatus.Occupied,
                     },
                      new Rooms
                      {
                          ID = 7,
                          RoomNumber = "107",
                          Status = RoomStatus.Occupied,
                      },
                       new Rooms
                       {
                           ID = 8,
                           RoomNumber = "108",
                           Status = RoomStatus.Occupied,
                       },
                        new Rooms
                        {
                            ID = 9,
                            RoomNumber = "109",
                            Status = RoomStatus.Occupied,
                        }, new Rooms
                        {
                            ID = 10,
                            RoomNumber = "110",
                            Status = RoomStatus.Occupied,
                        }, new Rooms
                        {
                            ID = 11,
                            RoomNumber = "111",
                            Status = RoomStatus.Occupied,
                        }, new Rooms
                        {
                            ID = 12,
                            RoomNumber = "112",
                            Status = RoomStatus.Occupied,
                        }
                );
        }
    }
}