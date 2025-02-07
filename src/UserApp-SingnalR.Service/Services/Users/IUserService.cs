using UserApp_SingnalR.Shared.DTOs.Users;

namespace UserApp_SingnalR.Service.Services.Users;

public interface IUserService
{
    Task<UserViewModel> CreateAsync(UserCreateModel createModel);
}