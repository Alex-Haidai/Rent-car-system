using CCL.Security.Identity;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public double Cost { get; set; }
        public Drive Drive { get; set; }
        public Account User { get; set; }
    }
}
