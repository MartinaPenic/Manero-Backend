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
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public IdentityUser User { get; set; }

    public ICollection<UserAddressEntity> UserAddresses { get; set; } = new HashSet<UserAddressEntity>();

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime ModifiedAt { get; set;}
}
