
using Domain.Entity;

namespace Domain.Interface.Users;

public interface IUserRepository
{
    public Task<IQueryable<User>> Find();
    public Task Add(User user);
    public Task Update(User user);
    public Task Delete(User user);

}
