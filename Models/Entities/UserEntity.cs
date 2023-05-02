using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class UserEntity
{
    [Key, ForeignKey(nameof(User))]
    [Required]
    public string Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public IdentityUser User { get; set; }

    [Required]
    [ForeignKey(nameof(Address))]
    public int AddressId { get; set; }

    public AddressEntity Address { get; set; }
}
