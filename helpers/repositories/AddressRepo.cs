using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories;

public class AddressRepo
{
    private readonly DataContext _context;

    public AddressRepo(DataContext context)
    {
        _context = context;
    }

    public async Task<AddressEntity> CreateAddressAsync(AddressEntity entity)
    {
        try
        {
            _context.Addresses.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch { return null; }
    }
    public async Task<AddressEntity> CheckAddressExistsAsync(AddressEntity entity)
    {
        return await _context.Addresses.Where(x => x.StreetName == entity.StreetName && x.PostalCode == entity.PostalCode && x.City == entity.City).FirstOrDefaultAsync();
    }
}
