using Hotel.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Edit(int? id)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.ID == id);
            return View(room);

        }
        [HttpPost]
        public IActionResult Edit(Rooms rooms)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("ID", "Selected Id Is Not Found");
                return NotFound();
            }
            //fetch the selected id data Rooms id
            var room = _context.Rooms.Find(rooms.ID);
            room.Status = rooms.Status;
            _context.Rooms.Update(room);
            _context.SaveChanges();
            return RedirectToAction("Rooms");
        }
        public IActionResult Details(int id)
        {
            
            var room= _context.Rooms.FirstOrDefault(r=>r.ID == id);
            room = _context.Rooms.Include(r => r.Workers).FirstOrDefault(r=>r.ID==id);
            return View(room);
        }
    }
}
