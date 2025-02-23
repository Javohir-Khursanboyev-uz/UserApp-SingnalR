using System.Net;
using Newtonsoft.Json;
using UserApp_SingnalR.Shared.DTOs.Users;
using UserApp_SingnalR.Shared.Models;
using UserApp_SingnalR.Web.Service.Services.Base;

namespace UserApp_SingnalR.Web.Service.Services.Users;

public class UserApiService(IApiService apiService) : IUserApiService
{
    private const string baseUri = "/api/Users";
    public async Task<UserViewModel> CreateAsync(UserCreateModel model)
    {
        var apiResponse = await apiService.PostAsync<Response, UserCreateModel>(baseUri, model);
        if (!apiResponse.IsSuccess)
            throw new Exception(apiResponse.Message);

        var userJson = JsonConvert.SerializeObject(apiResponse.Data);
        var user = JsonConvert.DeserializeObject<UserViewModel>(userJson) 
            ?? throw new Exception("User data is invalid");

        return user;
    }
}