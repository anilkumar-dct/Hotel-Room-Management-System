using Hotel.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelRoomManagementSystem.Controllers
{
    public class RoomsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RoomsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Rooms()
        {
            List<Rooms> rooms = _context.Rooms.ToList();
            return View(rooms);
        }
        //Shorting Applying
        public IActionResult AllRooms(RoomStatus? roomStatus)
        {
            ViewBag.SelectedRoom = roomStatus;
           var rooms = _context.Rooms.AsQueryable();
            if (roomStatus.HasValue)
            {
                rooms = rooms.Where(r => r.Status == roomStatus);
            }
            return View("Rooms",rooms.ToList());
        }
    }
}
