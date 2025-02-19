using UserApp_SingnalR.DataAcces.UnitOfWorks;
using UserApp_SingnalR.Shared.Exceptions;

namespace UserApp_SingnalR.Service.Services.Auths;

public class AuthService(IUnitOfWork unitOfWork) : IAuthService
{
    public async Task<bool> HasPermissionAsync(long userId, string action, string controller)
    {
        var existUser = await unitOfWork.Users.SelectAsync(expression: u => u.Id == userId, includes: ["Role.RolePermissions.Permission"])
            ?? throw new NotFoundException("User not found");

        var hasPermission = existUser.Role.RolePermissions
                 .Any(rp => rp.Permission.Action == action && rp.Permission.Controller == controller);

        return hasPermission;
    }
}