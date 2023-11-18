using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class User : Account
    {
        public double Balance { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        public User(int userId, string name, string email, string password) : base(userId, name, email, password)
        {
            Balance = 0;
            Bookings = new List<Booking>();
        }
        }
    }

