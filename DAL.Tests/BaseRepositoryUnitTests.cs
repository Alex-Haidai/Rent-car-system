using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using DAL.EF;
using System.IO;
using DAL.Entities;

namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputCarInstance_CalledAddMethodOfDBSetWithCarInstance() 
        { 
            DbContextOptions opt = new DbContextOptionsBuilder<RentCarContext>().Options;
            var mockContext = new Mock<RentCarContext>(opt);
            var mockDbSet = new Mock<DbSet<Car>>();
            mockContext
                .Setup(context =>
                    context.Set<Car>(
                        ))
                .Returns(mockDbSet.Object);
            var repository = new TestCarRepository(mockContext.Object);
            Car expectedCar = new Mock<Car>("Toyota", "Supra").Object;

            repository.Create(expectedCar);

            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedCar
                    ), Times.Once());
        }
        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<RentCarContext>().Options;
            var mockContext = new Mock<RentCarContext>(opt);
            var mockDbSet = new Mock<DbSet<Car>>();
            mockContext
                .Setup(context =>
                    context.Set<Car>(
                        ))
                .Returns(mockDbSet.Object);

            Car expectedCar = new Car("Bmw", "M5") { CarId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedCar.CarId))
                .Returns(expectedCar);
            var repository = new TestCarRepository(mockContext.Object);

            var actualCar = repository.Get(expectedCar.CarId);

            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedCar.CarId
                    ), Times.Once());
            Assert.Equal(expectedCar, actualCar);
        }
        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<RentCarContext>().Options;
            var mockContext = new Mock<RentCarContext>(opt);
            var mockDbSet = new Mock<DbSet<Car>>();
            mockContext
                .Setup(context =>
                    context.Set<Car>(
                        ))
                .Returns(mockDbSet.Object);

            Car expectedCar = new Car("Subaru", "Impreza") { CarId = 2 };

            mockDbSet.Setup(mock => mock.Find(expectedCar.CarId))
                .Returns(expectedCar);
            var repository = new TestCarRepository(mockContext.Object);

            repository.Delete(expectedCar.CarId);

            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedCar
                    ), Times.Once());
        }
    }
}
