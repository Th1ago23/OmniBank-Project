using Domain.Entity;
using Domain.Interface.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class AdressRepository:IAdressRepository
{
    private readonly DbConfig _context;

    public AdressRepository(DbConfig context)
    {
        _context = context;
    }
    public async Task Add(Adress adress)
    {
        await _context.Adresses.AddAsync(adress);
    }
    public async Task Delete(Guid id)
    {
        var adress = await _context.Adresses.FirstOrDefaultAsync(i => i.Id == id) ?? throw new NullReferenceException();
        _context.Adresses.Remove(adress);
    }
    public void Update(Adress adress)
    {
        _context.Adresses.Update(adress);
    }

}
