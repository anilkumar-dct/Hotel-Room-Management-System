using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.Models
{
    public class Rooms
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string RoomNumber { get; set; }

        [Required]
        public RoomStatus Status { get; set; } = RoomStatus.Available;

        // Navigation Property to workers
        public ICollection<Workers> Workers { get; set; } = new List<Workers>(); // Initialize to avoid null
    }
    public enum RoomStatus
    {
        Available,
        Occupied,
        UnderMaintenance
    }
}
