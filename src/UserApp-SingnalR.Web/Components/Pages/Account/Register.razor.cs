using Microsoft.AspNetCore.Components;
using UserApp_SingnalR.Shared.DTOs.Users;
using UserApp_SingnalR.Web.Service.Services.Users;

namespace UserApp_SingnalR.Web.Components.Pages.Account;

public partial class Register
{
    [Inject]
    IUserApiService userApiService { get; set; }

    private NavigationManager navigationManager { get; set; }
    private UserCreateModel createModel = new UserCreateModel();
    private bool showError = false;
    private string errorMessage = string.Empty;

    private async Task HandleRegister()
    {
        try
        {
            await userApiService.CreateAsync(createModel);
            navigationManager.NavigateTo("/");
        }
        catch (Exception ex)
        {
            showError = true;
            errorMessage = ex.Message;
        }
    }
}
