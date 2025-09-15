using Domain.Interface.Repository;
using Infrastructure.Context;

namespace Infrastructure.Repository;

public class AdressRepository:IAdressRepository
{
    private readonly DbConfig _context;

    public AdressRepository(DbConfig context)
    {
        _context = context;
    }
}
