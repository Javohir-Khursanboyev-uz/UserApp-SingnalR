using UserApp_SingnalR.Shared.DTOs.Users;

namespace UserApp_SingnalR.Web.Service.Services.Users;

public interface IUserApiService
{
    Task<UserViewModel> CreateAsync(UserCreateModel model);
}