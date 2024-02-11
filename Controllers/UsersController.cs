namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is not correct !" });

        return Ok(response);
    }
    
    // Note: outcomment /remove autorize attribute for testing if needed !
    [Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
}
