using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WebApi.helpers;
using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Services;

public class UserService
{
    private readonly UserRepo _userRepo;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly TokenGenerator _tokenGenerator;

    public UserService(UserRepo userRepo, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, TokenGenerator tokenGenerator)
    {
        _userRepo = userRepo;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<bool> CreateUserAsync(UserRegisterModel model)
    {
        IdentityUser identityUser = model;
        var identityResult = await _userManager.CreateAsync(identityUser, model.Password);

        if(identityResult.Succeeded)
        {
            UserEntity userEntity = model;
            userEntity.Id = identityUser.Id;
            await _userRepo.CreateUserAsync(userEntity);
            return true;
        }

        return false;   
    }

    public async Task<string> LogInAsync(UserLoginModel model)
    {
        var identityUser = await _userManager.FindByEmailAsync(model.Email);
        if (identityUser != null)
        {
            var signInResult = await _signInManager.CheckPasswordSignInAsync(identityUser, model.Password, false);
            if (signInResult.Succeeded)
            {
                var claimsIdentity = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", identityUser.Id.ToString()),
                    new Claim(ClaimTypes.Name, identityUser.Email!)
                });
                return _tokenGenerator.GenerateJwtToken(claimsIdentity, DateTime.Now.AddHours(1));
            }
        }
        return string.Empty;
    }
}
