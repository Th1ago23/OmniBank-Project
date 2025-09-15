using Core.Entity;

namespace Domain.Interface.Repository;

public interface IRefreshTokenRepository
{
    public Task Add(RefreshToken token);
    public Task Delete(Guid Id);
}
