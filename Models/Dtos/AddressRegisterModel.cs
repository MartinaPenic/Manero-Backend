using WebApi.Models.Entities;

namespace WebApi.Models.Dtos;

public class AddressRegisterModel
{
    public string StreetName { get; set; }

    public string PostalCode { get; set; }

    public string City { get; set; }

    public static implicit operator AddressEntity(AddressRegisterModel model)
    {
        return new AddressEntity
        {
            StreetName = model.StreetName,
            PostalCode = model.PostalCode,
            City = model.City,
        };
    }
}
