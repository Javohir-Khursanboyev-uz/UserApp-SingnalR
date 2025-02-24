using Microsoft.AspNetCore.Components;
using UserApp_SingnalR.Shared.DTOs.Users;
using UserApp_SingnalR.Web.Service.Services.Auth;

namespace UserApp_SingnalR.Web.Components.Pages.Account;

public partial class Login
{
    [Inject]
    private IAuthApiService authApiService {  get; set; }

    [Inject]
    private NavigationManager navigationManager { get; set; }

    private LoginModel loginModel { get; set; } = new LoginModel();
    private bool showError = false;
    private string errorMessage = string.Empty;

    private async Task HandleLogin()
    {
        try
        {
            var res = await authApiService.LoginAsync(loginModel);
            if (res is not null)
            {
                navigationManager.NavigateTo("/");
            }
        }
        catch (Exception ex)
        {
            showError = true; // Xatolik xabarini ko'rsatish
            errorMessage = ex.Message; // Xatolik xabarini o'rnatish
        }
    }
}