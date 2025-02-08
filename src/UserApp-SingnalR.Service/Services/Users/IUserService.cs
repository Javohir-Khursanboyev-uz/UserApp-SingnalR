using UserApp_SingnalR.Shared.DTOs.Users;

namespace UserApp_SingnalR.Service.Services.Users;

public interface IUserService
{
    Task<LoginViewModel> CreateAsync(UserCreateModel createModel);
    Task<LoginViewModel> LoginAsync(LoginModel loginModel);
}