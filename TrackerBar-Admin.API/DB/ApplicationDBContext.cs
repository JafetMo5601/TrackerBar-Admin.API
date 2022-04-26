using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrackerBar_Admin.API.DataModels;

namespace TrackerBar_Admin.API.DB
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Direction> Direction { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<ReceiptDetail> ReceiptDetail { get; set; }
        public DbSet<RestaurantDirection> RestaurantDirection { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Receipt> Receipt { get; set; }
    }
}
