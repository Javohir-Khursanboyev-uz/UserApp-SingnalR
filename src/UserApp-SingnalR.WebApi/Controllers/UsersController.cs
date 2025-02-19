using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserApp_SingnalR.Domain.Entities;
using UserApp_SingnalR.Service.Services.Users;
using UserApp_SingnalR.Shared.DTOs.Users;
using UserApp_SingnalR.Shared.Models;
using UserApp_SingnalR.WebApi.Services;

[Route("api/[controller]")]
[ApiController]
[CustomAuthorize]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostAsync(UserCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await userService.CreateAsync(createModel)
        });
    }

    [HttpGet("login")]
    [AllowAnonymous]
    public async ValueTask<IActionResult> LoginAsync([FromQuery] LoginModel loginModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await userService.LoginAsync(loginModel)
        });
    }
}