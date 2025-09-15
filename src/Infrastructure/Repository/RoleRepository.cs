using Core.Entity;
using Domain.Interface.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class RoleRepository:IRoleRepository
{
    private readonly DbConfig _context;

    public RoleRepository(DbConfig context)
    {
        _context = context;
    }

    public IQueryable<Role> Find()
    {
        return _context.Roles.AsQueryable();
    }

    public async Task Add(Role role)
    {
        await _context.AddAsync(role);
    }
    public async Task Delete(Guid id)
    {
        var role = await Find().FirstOrDefaultAsync(i => i.Id == id) ?? throw new NullReferenceException();
        _context.Roles.Remove(role);
    }
    public void Update(Role role)
    {
        _context.Roles.Update(role);
    }


}
