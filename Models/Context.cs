using Microsoft.EntityFrameworkCore;
using RumisBC.Models;

namespace RumisBC.Models
{
    public class Context:DbContext
    {
		public DbSet<Admin> Admins { get; set; }
		public DbSet<Customer> Customers { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Booking> Bookings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RumisBC;Trusted_Connection=True;");
        }


        public DbSet<RumisBC.Models.Employer>? Employer { get; set; }
    }
}
