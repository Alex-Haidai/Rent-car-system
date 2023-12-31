﻿using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRepository Cars { get; }
        IDriveRepository Drives { get; }
        IBookingRepository Bookings { get; }
        void Save();
    }
}
