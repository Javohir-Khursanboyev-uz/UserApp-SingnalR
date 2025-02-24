using Newtonsoft.Json;
using UserApp_SingnalR.Shared.Models;
using UserApp_SingnalR.Shared.DTOs.Users;
using UserApp_SingnalR.Web.Service.Services.Base;

namespace UserApp_SingnalR.Web.Service.Services.Auth;

public class AuthApiService(IApiService apiService) : IAuthApiService
{
    private const string baseUri = "/api/Account";

    public async Task<LoginViewModel> LoginAsync(LoginModel loginModel)
    {
        var apiResponse = await apiService.PostAsync<Response, LoginModel>($"{baseUri}/login", loginModel);

        if (!apiResponse.IsSuccess)
            throw new Exception(apiResponse.Message);

        var loginJson = JsonConvert.SerializeObject(apiResponse.Data);
        var loginViewModel = JsonConvert.DeserializeObject<LoginViewModel>(loginJson)
            ?? throw new Exception("Login response is invalid");

        return loginViewModel;
    }
}