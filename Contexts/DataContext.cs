using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi.Contexts;

public class DataContext : IdentityDbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> UserProfiles { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
	public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductRatingEntity> ProductRatings { get; set; }
    public DbSet<UserAddressEntity> UserAddresses { get; set; }
    public DbSet<CreditCardEntity> CreditCards { get; set;}

}
