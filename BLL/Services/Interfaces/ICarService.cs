using BLL.DTO;
using CCL.Security.Identity;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ICarService
    {
        IEnumerable<CarDTO> GetCars();
    }
}
