using Catalog.DAL.Entities;
using DAL.EF;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Impl
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        internal UserRepository(RentCarContext context)
            : base(context)
        {
        }
    }
}
