using Microsoft.AspNetCore.Http;
using UserApp_SingnalR.Domain.Enums;

namespace UserApp_SingnalR.Shared.DTOs.Assets;

public class AssetCreateModel
{
    public IFormFile File { get; set; }
    public FileType FileType { get; set; }
}