using Microsoft.EntityFrameworkCore;
using UserApp_SingnalR.DataAcces.EntityConfigurations;
using UserApp_SingnalR.Domain.Entities;

namespace UserApp_SingnalR.DataAcces.DbContexts;

public class AppDbContext :DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<UserRole> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        modelBuilder.ApplyConfiguration(new AssetConfiguration());


        modelBuilder.Entity<Contact>()
           .HasOne(c => c.Owner)
           .WithMany(u => u.Contacts)
           .HasForeignKey(c => c.OwnerId)
           .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Contact>()
            .HasOne(c => c.TargetUser)
            .WithMany() // TargetUser uchun orqaga bog‘liq xususiyat yo‘q
            .HasForeignKey(c => c.TargetUserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}