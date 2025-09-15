using Domain.Entity;

namespace Domain.Interface.Repository;

public interface IAdressRepository
{
    public Task Add(Adress adress);
    public Task Delete(Adress adress);
    public Task Update(Adress adress);
}
