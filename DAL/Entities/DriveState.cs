using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public enum DriveState
    {
        Scheduled,
        InProgress,
        Completed,
        Calcelled,
        Problem,
        Unpaid
    }
}
