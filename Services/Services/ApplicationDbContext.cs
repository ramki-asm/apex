// APEX.Services/Data/ApplicationDbContext.cs
using System.Data.Entity;
using APEX.Common.Models;

namespace APEX.Services.Data
{
    public class ApplicationDbContext : DbContext
    {
        // DbSet properties must match your model classes
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public ApplicationDbContext() : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure your entity relationships here
            modelBuilder.Entity<User>()
                .HasRequired(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            base.OnModelCreating(modelBuilder);
        }
    }
}