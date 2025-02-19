using System.Reflection.Metadata.Ecma335;

namespace UserApp_SingnalR.Service.Services.Auths;

public interface IAuthService
{
    Task<bool> HasPermissionAsync(long userId, string action, string controller);
}