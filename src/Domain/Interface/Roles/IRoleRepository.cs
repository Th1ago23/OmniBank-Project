using Core.Entity;

namespace Domain.Interface.Roles;

public interface IRoleRepository
{
    public Task<IQueryable<Role>> Find();
    public Task Add();
    public Task Delete();
    public Task Update();
}
