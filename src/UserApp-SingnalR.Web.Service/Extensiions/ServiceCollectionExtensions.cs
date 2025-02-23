using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserApp_SingnalR.Web.Service.Services.Auth;
using UserApp_SingnalR.Web.Service.Services.Base;
using UserApp_SingnalR.Web.Service.Services.Users;

namespace UserApp_SingnalR.Web.Service.Extensiions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        var apiUrl = configuration["Api:Url"]!;
        services.AddHttpClient<IApiService, ApiService>(client =>
        {
            client.BaseAddress = new Uri(apiUrl);
        });

        services.AddScoped<IAuthApiService, AuthApiService>();
        services.AddScoped<IUserApiService, UserApiService>();

        return services;
    }
}