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
            Car expectedCar = new Mock<Car>().Object;

            repository.Create(expectedCar);

            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedCar
                    ), Times.Once());
        }
    }
}
