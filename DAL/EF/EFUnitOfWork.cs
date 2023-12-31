﻿using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;


namespace DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private RentCarContext _db;
        private CarRepository _carRepository;
        private DriveRepository _driveRepository;
        private BookingRepository _bookingRepository;
        private bool disposed = false;

        public EFUnitOfWork(DbContextOptions options)
        {
            _db = new RentCarContext((DbContextOptions<RentCarContext>)options);
        }

        ICarRepository IUnitOfWork.Cars
        {
            get
            {
                if (_carRepository == null)
                    _carRepository = new CarRepository(_db);
                return _carRepository;
            }
        }
        IDriveRepository IUnitOfWork.Drives
        {
            get
            {
                if (_driveRepository == null)
                    _driveRepository = new DriveRepository(_db);
                return _driveRepository;
            }
        }
        IBookingRepository IUnitOfWork.Bookings
        {
            get
            {
                if (_bookingRepository == null)
                    _bookingRepository = new BookingRepository(_db);
                return _bookingRepository;
            }
        }


        public void Save()
        {
            _db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
