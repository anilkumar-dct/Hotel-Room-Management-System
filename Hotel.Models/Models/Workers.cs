using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayName("Availability Status")]
        public string Availability { get; set; }
        [Required]
        [DisplayName("Room Number")]
        public int RoomNumber { get; set; }
    }
}
