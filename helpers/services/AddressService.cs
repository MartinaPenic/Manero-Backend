using WebApi.Helpers.Repositories;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Services;

public class AddressService
{
    private readonly AddressRepo _addressRepo;

    public AddressService(AddressRepo addressRepo)
    {
        _addressRepo = addressRepo;
    }

    public async Task<AddressEntity> CreateAddressAsync(AddressEntity entity)
    {
        var result = await _addressRepo.CheckAddressExistsAsync(entity);
        if(result != null)
        {
            return result;
        }
        return await _addressRepo.CreateAddressAsync(entity);        
    }
}
