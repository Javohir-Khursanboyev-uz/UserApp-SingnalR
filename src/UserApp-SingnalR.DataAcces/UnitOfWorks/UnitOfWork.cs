using Microsoft.EntityFrameworkCore.Storage;
using UserApp_SingnalR.DataAcces.DbContexts;
using UserApp_SingnalR.DataAcces.Repositories;
using UserApp_SingnalR.Domain.Entities;

namespace UserApp_SingnalR.DataAcces.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    private IDbContextTransaction transaction;
    public IRepository<User> Users { get; }

    public IRepository<Asset> Assets { get; }

    public IRepository<Message> Messages { get; }

    public IRepository<Contact> Contacts { get; }
    public IRepository<UserRole> Roles { get; }

    public IRepository<Permission> Permissions {  get; }

    public IRepository<RolePermission> RolePermissions {  get; }

    public UnitOfWork(AppDbContext context)
    {
        this.context = context;
        Users = new Repository<User>(context);
        Assets = new Repository<Asset>(context);
        Contacts = new Repository<Contact>(context);
        Messages = new Repository<Message>(context);
        Roles = new Repository<UserRole>(context);
        Permissions = new Repository<Permission>(context);
        RolePermissions = new Repository<RolePermission>(context);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public async Task BeginTransactionAsync()
    {
        transaction = await context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await transaction.CommitAsync();
    }
}
