using UserApp_SingnalR.Shared.DTOs.Assets;

namespace UserApp_SingnalR.Service.Services.Assets;

public interface IAssetService
{
    Task<AssetViewModel> UploadAsync(AssetCreateModel model);
    Task<bool> DeleteAsync(long id);
    Task<AssetViewModel> GetByIdAsync(long id);
}