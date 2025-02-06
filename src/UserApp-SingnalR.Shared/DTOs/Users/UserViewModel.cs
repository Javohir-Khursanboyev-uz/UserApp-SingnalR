using UserApp_SingnalR.Shared.DTOs.Assets;

namespace UserApp_SingnalR.Shared.DTOs.Users;

public class UserViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public AssetViewModel Picture { get; set; }
}