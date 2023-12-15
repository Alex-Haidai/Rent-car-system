using CCL.Security.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security
{
    public static class SecurityContext
    {
        static Account _account = null;

        public static Account GetAccount()
        {
            return _account;
        }

        public static void SetAccount(Account account)
        {
            _account = account;
        }
    }
}
