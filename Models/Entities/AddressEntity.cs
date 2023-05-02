using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class AddressEntity
{
    [Key]
    [Required]
    public int Id { get; set; } 

    [Required]
    public string StreetName { get; set; }

    [Required]
    public string PostalCode { get; set; }

    [Required]
    public string City { get; set; }
}
