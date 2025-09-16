using Domain.Entity;
using Domain.Interface.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly DbConfig _context;

    public UserRepository(DbConfig context)
    {
        _context = context;
    }
    private IQueryable<User> Find()
    {
        return _context.Users.AsQueryable();
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);        
    }
    public void Update(User user)
    {
        _context.Users.Update(user);
    }
    public async Task Delete(Guid id)
    {
        var user = await Find().FirstOrDefaultAsync(i => i.Id == id) ?? throw new NullReferenceException();

        _context.Users.Remove(user);
    }
}
