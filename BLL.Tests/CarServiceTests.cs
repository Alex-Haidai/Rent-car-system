using BLL.Services.Impl;
using CCL.Security.Identity;
using CCL.Security;
using DAL.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Tests
{
    public class CarServiceTests
    {

        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(
            () => new CarService(nullUnitOfWork));
        }

        [Fact]
        public void GetCars_CarFromDAL_CorrectMappingToCarDTO()
        {
            // Arrange
            var carService = GetCarService();
            // Act
            var actualCarDto = carService.GetCars().First();
            // Assert
            Assert.True(
            actualCarDto.CarId == 1
            && actualCarDto.Brand == "Suzuki"
            && actualCarDto.Model == "Jimny"
            && actualCarDto.Year == 2020
            && actualCarDto.Rating == 9
            && actualCarDto.CurrentCarState == CarState.UnderMaintenance
            );
        }

        ICarService GetCarService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedCar = new Car("Suzuki", "Jimny")
            {
                CarId = 1,
                Year = 2020,
                Rating = 9,
                CurrentCarState = CarState.UnderMaintenance,
            };
            var mockDbSet = new Mock<ICarRepository>();
            mockDbSet
            .Setup(z =>
             z.GetAll()).Returns(new List<Car>() { expectedCar });

            mockContext
            .Setup(context =>
            context.Cars)
            .Returns(mockDbSet.Object);
            ICarService carService = new CarService(mockContext.Object);
            return carService;
        }
    }
}
