using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Dtos;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserService _userService;

    public AccountController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register(UserRegisterModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _userService.CreateUserAsync(model);
            if(result)
                return Created("", model);
        }
        return BadRequest();
    }

    [HttpPost]
    [Route("LogIn")]
    public async Task<IActionResult> LogIn(UserLoginModel model)
    {
        if (ModelState.IsValid)
        {
            var token = await _userService.LogInAsync(model);

            if (!string.IsNullOrEmpty(token))
                return Ok(token);
        }
        return Unauthorized("Incorrect email or password");
    }
}
