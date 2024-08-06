using HarvestLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace HarvestLibrary.Database
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
