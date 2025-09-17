using Application.DTO.Users;
using Application.Interface.UserService;
using Domain.Entity;

namespace Application.Service;

public class UserMapper:IUserMapper
{
    public User ToEntity(UserLoginDTO userLoginDTO)
    {
        return new User
        {
            Email = userLoginDTO.email,

        }
    }
}
