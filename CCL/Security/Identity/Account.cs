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
        protected string AccountType { get; }

        public Account(int userId, string name, string email, string password, string accountType)
        {
            AccountId = userId;
            Name = name;
            Email = email;
            Password = password;
            AccountType = accountType;
        }
    }
}
