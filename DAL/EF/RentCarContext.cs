
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class RentCarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Drive> Drives { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public RentCarContext(DbContextOptions<RentCarContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=TestDb;Trusted_Connection=True;");
        }
    }
}
