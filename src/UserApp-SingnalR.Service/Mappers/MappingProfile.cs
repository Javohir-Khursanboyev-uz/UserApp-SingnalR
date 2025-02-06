using AutoMapper;
using UserApp_SingnalR.Domain.Entities;
using UserApp_SingnalR.Shared.DTOs.Assets;
using UserApp_SingnalR.Shared.DTOs.Users;

namespace UserApp_SingnalR.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Asset, AssetViewModel>().ReverseMap();

        CreateMap<UserCreateModel, User>().ReverseMap();
        CreateMap<UserUpdateModel, User>().ReverseMap();
        CreateMap<User, UserViewModel>().ReverseMap();
        CreateMap<UserUpdateModel, UserViewModel>().ReverseMap();
    }
}
