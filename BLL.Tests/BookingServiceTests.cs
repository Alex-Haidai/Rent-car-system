using CCL.Security.Identity;
using CCL.Security;
using DAL.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using BLL.Services.Impl;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace BLL.Tests
{
    public class BookingServiceTests
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
        public void MakeBooking_AccountIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            Account account = new Admin(1, "Alex");
            SecurityContext.SetAccount(account);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IBookingService streetService = new BookingService(mockUnitOfWork.Object);
            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => streetService.MakeBooking());
        }

        [Fact]
        public void MakeBooking_BookingFromDAL_CorrectMappingToBookingDTO()
        {
            // Arrange
            Account user = new User(1, "Alex");
            SecurityContext.SetAccount(user);
            var bookingService = GetBookingService();
            // Act
            var actualBookingDTO = bookingService.MakeBooking();
            // Assert
            Console.WriteLine(actualBookingDTO.BookingId);
            Assert.True(
            actualBookingDTO.User.Name == "Alex"
            );
           
        }

        IBookingService GetBookingService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedBooking = new Booking()
            {
                User = new User(1, "Alex")
            };
            var mockDbSet = new Mock<IBookingRepository>();
            mockDbSet.Setup(mock => mock.Get(expectedBooking.BookingId))
                 .Returns(expectedBooking);

            mockContext
            .Setup(context =>
            context.Bookings)
            .Returns(mockDbSet.Object);
             IBookingService bookingService = new BookingService(mockContext.Object);
            return bookingService;
        }
    }
}
