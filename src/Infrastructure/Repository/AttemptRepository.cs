using Core.Entity;
using Domain.Interface.Repository;
using Infrastructure.Context;

namespace Infrastructure.Repository;

public class AttemptRepository:IAttemptsRepository
{
    private readonly DbConfig _context;

    public AttemptRepository(DbConfig context)
    {
        _context = context;
    }

    public async Task Add(UserLoginAttempt attempt)
    {
        await _context.UserLoginAttempts.AddAsync(attempt);
    }

    public async Task Delete (Guid id)
    {
        var attempt = await _context.UserLoginAttempts.FindAsync(id) ?? throw new NullReferenceException();
        _context.UserLoginAttempts.Remove(attempt);

    }
 

}
