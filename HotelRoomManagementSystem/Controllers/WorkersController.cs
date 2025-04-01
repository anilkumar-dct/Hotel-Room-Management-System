using Hotel.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelRoomManagementSystem.Controllers
{
    public class WorkersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public WorkersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Workers()
        {
            List<Workers> workers = _context.Workers.ToList();
            return View(workers);
        }
        //Short Based on Availability
        public IActionResult AllStatus(WorkerStatus? status)
        
        {
            ViewBag.SelectedStatus = status;
            //Get all the Data
            var worker = _context.Workers.AsQueryable();
            if (status.HasValue)
            {
                worker = worker.Where(r => r.Availability == status);
            }
            return View("Workers",worker.ToList());
        }
        //Adding New Worker
        public IActionResult Add()
        {
           
            var availableRooms = _context.Rooms.Where(r => r.Status ==RoomStatus.Available).ToList();
            ViewBag.RoomList = new SelectList(availableRooms, "ID", "RoomNumber");
            return View();
        }
        [HttpPost]
        public IActionResult Add(Workers workers)
        {
            if (workers.Availability == WorkerStatus.Available)
            {
                workers.Availability = WorkerStatus.Available;
            }

            var selectedRoom = _context.Rooms.Find(workers.RoomId);
            if (selectedRoom == null)
            {
                ModelState.AddModelError("RoomId", "Selected Room is Not Found");
                return View(workers);
            }
            workers.RoomNumber = selectedRoom.RoomNumber;
            _context.Workers.Add(workers);
            _context.SaveChanges();
            return RedirectToAction("Workers");
        }
    }
}
