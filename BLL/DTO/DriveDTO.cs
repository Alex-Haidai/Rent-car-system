using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class DriveDTO
    {
        public int DriveId { get; set; }
        public double Length { get; set; }
        public double Cost { get; set; }
       
    }
}
