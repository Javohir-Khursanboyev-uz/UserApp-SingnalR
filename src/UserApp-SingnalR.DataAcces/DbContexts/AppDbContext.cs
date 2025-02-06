using Microsoft.EntityFrameworkCore;
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
}