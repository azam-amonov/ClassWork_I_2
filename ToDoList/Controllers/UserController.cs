using Microsoft.AspNetCore.Mvc;
using ToDoList.Entities;
using ToDoList.Services;

namespace ToDoList.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(User user)
    {
        var result = await _userService.CreateAsync(user);
        return Ok(result);
    }
}

