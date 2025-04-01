using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.Models
{
    public class Workers
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Availability")]
        public WorkerStatus Availability { get; set; } = WorkerStatus.Available;

        [Required]
        [DisplayName("Room Number")]
        public string RoomNumber { get; set; }

        //Foreign Key Relation
        //step on define the property or foreign key 

        // Foreign Key Property
        public int RoomId { get; set; }

        // Navigation Property (establishing relationship between Workers and Rooms)
        [ForeignKey("RoomId")]
        public Rooms Rooms { get; set; }
    }
    public enum WorkerStatus
    {
        Available,
        OnBreak,
        Occupied,
    }
}
