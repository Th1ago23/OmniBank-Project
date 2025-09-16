using Core.Entity;

namespace Domain.Interface.Repository;

public interface IAttemptsRepository
{
    public Task Add (UserLoginAttempt attempt);
    public Task Delete(Guid id);
}
