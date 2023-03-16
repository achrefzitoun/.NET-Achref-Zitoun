using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Seat
    {
        public int seatId { get; set; }
        [Required(ErrorMessage = "Error")]
        [MinLength(1)]
        public string name { get; set; }
        public string seatNumber { get; set; }
        [Range(0, 20)]
        public int size { get; set;}
        public virtual Plane plane { get; set; }
        public virtual Section? section { get; set; }
        public virtual List<Reservation> reservations { get; set; }

        [ForeignKey("plane")]
        public int planeFK { get; set; }

        [ForeignKey("section")]
        public int? sectionFK { get; set; }        


     
    }
}
