using UserApp_SingnalR.Shared.DTOs.Users;
using UserApp_SingnalR.Web.Service.Services.Base;

namespace UserApp_SingnalR.Web.Service.Services.Auth;

public interface IAuthApiService
{
    Task<LoginViewModel> LoginAsync(LoginModel loginModel);
}