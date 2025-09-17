using Application.DTO.Users;
using Shared;

namespace Application.Interface.UserService;

public interface IAuthService
{
    public Task<UserResponseDTO> Login(UserLoginDTO login);
    public Task<bool> Logout();
    public Task<UserResponseDTO> Register(UserRegisterDTO register);
}
