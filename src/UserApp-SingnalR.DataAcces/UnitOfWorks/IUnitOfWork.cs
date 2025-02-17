using System;
using UserApp_SingnalR.DataAcces.Repositories;
using UserApp_SingnalR.Domain.Entities;

namespace UserApp_SingnalR.DataAcces.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; }
    IRepository<Asset> Assets { get; }
    IRepository<Contact> Contacts { get; }
    IRepository<Message> Messages { get; }
    IRepository<UserRole> Roles { get; }
    Task<bool> SaveAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
}