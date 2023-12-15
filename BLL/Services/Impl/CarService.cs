using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Services.Impl
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _database;

        public CarService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        
        public IEnumerable<CarDTO> GetCars()
        {
            var carsEntitites =
                  _database
                    .Cars
                    .GetAll();
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Car, CarDTO>()
                    ).CreateMapper();
            var carsDTO =
                mapper
                    .Map<IEnumerable<Car>, List<CarDTO>>(
                    carsEntitites);
            return carsDTO;

        }
    }
}
