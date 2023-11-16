using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

       

        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            Bookings = new List<Booking>();
        }

    }
}
