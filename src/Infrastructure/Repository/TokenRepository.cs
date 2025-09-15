using Core.Entity;
using Domain.Interface.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class TokenRepository:IRefreshTokenRepository
{
    private readonly DbConfig _context;

    public TokenRepository(DbConfig context)
    {
        _context = context;
    }

    public async Task Add(RefreshToken token)
    {
        await _context.Tokens.AddAsync(token);
    }
    public async Task Delete(Guid id)
    {
        var token = await _context.Tokens.FirstOrDefaultAsync(i=>i.Id == id) ?? throw new NullReferenceException();
        _context.Tokens.Remove(token);
    }


}
