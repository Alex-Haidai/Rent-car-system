using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public abstract class Account
    {
        public int AccountId { get; }
        public string Name { get; } 
        public string Email { get; }
        public string Password { get; }

        public Account(int userId, string name, string email, string password)
        {
            AccountId = userId;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
