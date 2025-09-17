using Application.DTO.Users;
using Domain.Entity;

namespace Application.Interface.UserService;

public interface IUserMapper
{
    public User ToEntity(UserLoginDTO login);
    public User ToEntity(UserRegisterDTO register);
    public UserResponseDTO ToResponse(UserLoginDTO login);
    public UserLoginDTO ToResponse(UserRegisterDTO register);
}
