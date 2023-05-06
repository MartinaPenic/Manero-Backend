using Microsoft.AspNetCore.Identity;
using WebApi.Models.Entities;

namespace WebApi.Models.Dtos;

public class UserRegisterModel
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Password { get; set; }   


    public static implicit operator UserEntity(UserRegisterModel model)
    {
        return new UserEntity
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
        };
    }
    public static implicit operator IdentityUser(UserRegisterModel model)
    {
        return new IdentityUser
        {
            Email = model.Email,
            UserName = model.Email
        };
    }
}
