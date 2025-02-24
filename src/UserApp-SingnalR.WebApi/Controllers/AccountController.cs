using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserApp_SingnalR.Service.Services.Users;
using UserApp_SingnalR.Shared.DTOs.Users;
using UserApp_SingnalR.Shared.Models;

namespace UserApp_SingnalR.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(IUserService userService) : Controller
{
    [HttpPost("login")]
    [AllowAnonymous]
    public async ValueTask<IActionResult> LoginAsync([FromBody]LoginModel loginModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await userService.LoginAsync(loginModel)
        });
    }
}
