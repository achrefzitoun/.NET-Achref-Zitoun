using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Section
    {
        [Key]
        public int idSection { get; set; }
        [Required(ErrorMessage = "Error")]
        [MinLength(1)]
        public string name { get; set; }
        public virtual List<Seat> seats { get; set; }

        
    }
}
