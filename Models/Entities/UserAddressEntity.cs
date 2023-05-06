using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

[PrimaryKey(nameof(UserId), nameof(AddressId))]
public class UserAddressEntity
{
    [Required]
    public string UserId { get; set; }
    [Required]
    public UserEntity User { get; set; }

    [Required]
    public int AddressId { get; set; }
    [Required]
    public AddressEntity Address { get; set; }
}
