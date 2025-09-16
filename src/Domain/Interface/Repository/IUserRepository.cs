using Domain.Entity;

namespace Domain.Interface.Repository;

public interface IUserRepository
{
    private IQueryable<User> Find();
    public Task Add(User user);
    public void Update(User user);
    public Task Delete(Guid id);

}
