using AutoMapper;
using UserApp_SingnalR.DataAcces.UnitOfWorks;
using UserApp_SingnalR.Domain.Entities;
using UserApp_SingnalR.Service.Extensions;
using UserApp_SingnalR.Service.Helpers;
using UserApp_SingnalR.Service.Validators.Assets;
using UserApp_SingnalR.Shared.DTOs.Assets;
using UserApp_SingnalR.Shared.Exceptions;

namespace UserApp_SingnalR.Service.Services.Assets;

public class AssetService(IMapper mapper, IUnitOfWork unitOfWork, AssetCreateModelValidator createModelValidator) : IAssetService
{
    public async Task<AssetViewModel> UploadAsync(AssetCreateModel model)
    {
        await createModelValidator.EnsureValidatedAsync(model);

        var assetData = await FileHelper.CreateFileAsync(model);
        var asset = new Asset()
        {
            Name = assetData.Name,
            Path = assetData.Path,
            FileType = model.FileType
        };
        
        var createdAsset = await unitOfWork.Assets.InsertAsync(asset);
        await unitOfWork.SaveAsync();

        return mapper.Map<AssetViewModel>(asset);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existAsset = await unitOfWork.Assets.SelectAsync(asset => asset.Id == id)
            ?? throw new NotFoundException("Asset is not found");

        await unitOfWork.Assets.DropAsync(existAsset);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async Task<AssetViewModel> GetByIdAsync(long id)
    {
        var existAsset = await unitOfWork.Assets.SelectAsync(asset => asset.Id == id)
           ?? throw new NotFoundException("Asset is not found");

        return mapper.Map<AssetViewModel>(existAsset);
    }
}
