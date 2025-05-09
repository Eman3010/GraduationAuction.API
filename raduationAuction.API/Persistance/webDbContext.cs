using Microsoft.EntityFrameworkCore;
using raduationAuction.API.Model;
using System.Reflection;

namespace GraduationAuction.API.Persistance
{
    public class webDbContext:DbContext
    {

        public webDbContext(DbContextOptions options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
       // public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Bidding> Bids { get; set; }
        public DbSet<Auction> Auctions { get; set; }   

       
    }
}
