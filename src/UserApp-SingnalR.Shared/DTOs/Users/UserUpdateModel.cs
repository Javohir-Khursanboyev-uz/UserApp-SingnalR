using UserApp_SingnalR.Shared.DTOs.Assets;

namespace UserApp_SingnalR.Shared.DTOs.Users;

public class UserUpdateModel
{
    public string Name { get; set; }
    public string UserName { get; set; }
    public AssetCreateModel Picture { get; set; }
}