using Domain.Entity;

namespace Domain.Interface.Repository;

public interface IAdressRepository
{
    public Task Add(Adress adress);
    public Task Delete(Guid id);
    public void Update(Adress adress);
}
