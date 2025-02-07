using AutoMapper;
using UserApp_SingnalR.DataAcces.UnitOfWorks;
using UserApp_SingnalR.Domain.Entities;
using UserApp_SingnalR.Service.Configurations;
using UserApp_SingnalR.Service.Extensions;
using UserApp_SingnalR.Service.Helpers;
using UserApp_SingnalR.Service.Validators.Users;
using UserApp_SingnalR.Shared.DTOs.Users;
using UserApp_SingnalR.Shared.Exceptions;

namespace UserApp_SingnalR.Service.Services.Users;

public class UserService(IMapper mapper, IUnitOfWork unitOfWork, UserCreateModelValidator createModelValidator) : IUserService
{
    public async Task<UserViewModel> CreateAsync(UserCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);

        var existUser = await unitOfWork.Users.SelectAsync(u => u.Email == createModel.Email || u.UserName == createModel.UserName);
        if (existUser is not null)
            throw new AlreadyExistException($"User already exist this email {createModel.Email} or username {createModel.UserName}");

        var user = mapper.Map<User>(createModel);
        user.Password = PasswordHasher.Hash(createModel.Password);
        user.RoleId = Constants.UserRoleId;
        user.PictureId = Constants.DefultImageId;

        var createdUser = await unitOfWork.Users.InsertAsync(user);
        await unitOfWork.SaveAsync();

        return mapper.Map<UserViewModel>(createdUser);
    }
}