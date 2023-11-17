using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Drive
    {
        public int DriveId { get; set; }
        public Car Car { get; set; } = null!;
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public double Length { get; set; }
        public double Cost { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
