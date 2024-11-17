using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Movie_Rental_Management.Entities;

namespace Movie_Rental_Management.Database
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
           
        }
        public DbSet<Movie>Movies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Rent>Rents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User -> UserRoles
            modelBuilder.Entity<User>()
                .HasMany<UserRole>(u => u.UserRoles)
                .WithOne()
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade); 

            // Role -> UserRoles
            modelBuilder.Entity<Role>()
                .HasMany<UserRole>(r => r.UserRoles)
                .WithOne()
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Restrict); 
            base.OnModelCreating(modelBuilder);
        }


    }
}
