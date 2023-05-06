using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories;

public class UserRepo
{
    private readonly DataContext _context;

    public UserRepo(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateUserAsync(UserEntity entity)
    {
        try
        {
            _context.UserProfiles.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch { return false; }
    }
}
