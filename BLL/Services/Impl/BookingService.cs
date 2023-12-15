using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _database;

        public BookingService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public BookingDTO MakeBooking()
        {
            var account = SecurityContext.GetAccount();
            var accountType = account.GetType();
            if (accountType != typeof(User))
            {
                throw new MethodAccessException();
            }
            User user = new User(1, "Alex");
            var booking = new Booking();
            booking.User = account;
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Booking, BookingDTO>()
                    ).CreateMapper();
            var bookingDTO = mapper.Map<BookingDTO>(booking);

            return bookingDTO;
        }
    }
}
