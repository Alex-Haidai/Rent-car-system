using DAL.Entities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Tests
{
    class TestCarRepository : BaseRepository<Car>
    {
        public TestCarRepository(DbContext context)
            : base(context)
        {
        }
    }
}
