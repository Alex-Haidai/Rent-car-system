
using CCL.Security.Identity;
using System;

namespace DAL.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public double Cost { get; set; }
        public Drive Drive { get; set; }
        public Account User { get; set; }

        public Booking(Drive drive, Account user)
        {
            Drive = drive;
            User = user;
        }
    }
}
