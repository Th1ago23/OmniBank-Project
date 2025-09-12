namespace Domain.Interface.Tokens;

public interface IRefreshTokenRepository
{
    public Task Add();
    public Task Remove();
}
