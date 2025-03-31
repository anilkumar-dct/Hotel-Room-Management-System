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
        [Key] public int ID {  get; set; }
        [Key] public int RoomNumber { get; set; }
        [Key] public string Status { get; set; }
    }
}
