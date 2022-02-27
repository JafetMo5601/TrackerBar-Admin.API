using Microsoft.EntityFrameworkCore;


namespace tracker_bar_admin_api.DataModels
{
    public class UserAdminContext: DbContext
    {
        public UserAdminContext(DbContextOptions<UserAdminContext> options) : base(options) 
        { 
        }
        
        public DbSet<User> User { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<ReceiptDetail> ReceiptDetail { get; set; }
        public DbSet<RestaurantDirection> RestaurantDirection { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Role> Roles { get; set; }
        // public DbSet<AdminRestaurante> AdminRestaurantes { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        //public DbSet<UserDirection> UserDirections { get; set; }
        //public DbSet<UserPhone> UserPhones { get; set; }
    }
}
