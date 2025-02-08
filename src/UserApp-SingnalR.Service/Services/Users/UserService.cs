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

public class UserService(IMapper mapper, 
    IUnitOfWork unitOfWork,
    UserCreateModelValidator createModelValidator,
    LoginModelValidator loginValidator) : IUserService
{
    public async Task<LoginViewModel> CreateAsync(UserCreateModel createModel)
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

        return new LoginViewModel
        {
            User = mapper.Map<UserViewModel>(createdUser),
            Token = AuthHelper.GenerateToken(createdUser)
        };
    }

    public async Task<LoginViewModel> LoginAsync(LoginModel loginModel)
    {
        await loginValidator.EnsureValidatedAsync(loginModel);

        var existUser = await unitOfWork.Users.SelectAsync(u => u.UserName.ToLower() == loginModel.UserName.ToLower())
           ?? throw new ArgumentIsNotValidException("UserName or Password incorrect");

        if (!PasswordHasher.Verify(loginModel.Password, existUser.Password))
            throw new ArgumentIsNotValidException("UserName or Password incorrect)");

        return new LoginViewModel
        {
            User = mapper.Map<UserViewModel>(existUser),
            Token = AuthHelper.GenerateToken(existUser)
        };
    }
}