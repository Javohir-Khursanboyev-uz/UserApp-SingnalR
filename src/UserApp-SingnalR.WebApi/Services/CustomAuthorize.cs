using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UserApp_SingnalR.Service.Services.Assets;
using UserApp_SingnalR.Service.Services.Auths;
using UserApp_SingnalR.Shared.Exceptions;
using UserApp_SingnalR.Shared.Models;

namespace UserApp_SingnalR.WebApi.Services;

public class CustomAuthorize() : Attribute, IAuthorizationFilter
{
    public async void OnAuthorization(AuthorizationFilterContext context)
    {
        var actionDescriptor = context.ActionDescriptor as Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor;

        var allowAnonymous = actionDescriptor?.MethodInfo.GetCustomAttributes(inherit: true)
                .OfType<AllowAnonymousAttribute>().Any() ?? false;
        if (allowAnonymous) return;

        string authorizationHeader = context.HttpContext.Request.Headers["Authorization"];
        if (string.IsNullOrEmpty(authorizationHeader))
        {
            SetStatusCodeResult(context);
            return;
        }

        var action = actionDescriptor.ActionName;
        var controller = actionDescriptor.ControllerName;
        var userId = Convert.ToInt64(context.HttpContext?.User?.FindFirst("Id")?.Value);

        if (!(await InjectHelper.AuthService.HasPermissionAsync(userId, action, controller)))
        {
            SetStatusCodeResult(context);
            return;
        }
    }

    private void SetStatusCodeResult(AuthorizationFilterContext context)
    {
        var exception = new CustomException(403, "You do not have permission for this method");
        context.Result = new ObjectResult(new Response
        {
            StatusCode = exception.StatusCode,
            Message = exception.Message
        })
        {
            StatusCode = exception.StatusCode
        };
    }
}