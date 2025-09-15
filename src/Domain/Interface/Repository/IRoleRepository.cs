using Core.Entity;

namespace Domain.Interface.Repository;

public interface IRoleRepository
{
    public IQueryable<Role> Find();
    public Task Add(Role role);
    public Task Delete(Guid id);
    public void Update(Role role);
}
