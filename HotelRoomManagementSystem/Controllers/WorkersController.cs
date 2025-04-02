using Hotel.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public IActionResult Edit(int? id) {
            if (id == null)
            {
                return NotFound();
            }
            Workers worker = _context.Workers.FirstOrDefault(w=>w.ID==id);
            ViewBag.RoomList = new SelectList(_context.Rooms, "ID", "RoomNumber");
            return View(worker);   
        }
        [HttpPost]
        public IActionResult Edit(Workers workers)
        {
            var worker = _context.Workers.FirstOrDefault(w=>w.ID==workers.ID);
            worker.Name = workers.Name;
            worker.Availability = workers.Availability;
            worker.RoomId = workers.RoomId;
            _context.Workers.Update(worker);
            _context.SaveChanges();
            return RedirectToAction("Workers");
        }
    }
}
