
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
        public User(int userId, string name)
            : base(userId, name, nameof(User))
        {
            Balance = 0;
        }
    }
}

