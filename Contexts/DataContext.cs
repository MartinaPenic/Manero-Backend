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

}
