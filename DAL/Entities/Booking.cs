
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public double Cost { get; set; }
        public Drive Drive { get; set; } = null!;

    }
}
