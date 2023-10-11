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

    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var result = await _userService.Get();
        return Ok(result);
    }

    [HttpGet]
    [Route("api/{id:guid}")]
    public async ValueTask<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        var result = await _userService.GetByIdAsync(id); 
        return Ok(result);
    }
    
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(User user)
    {
        var result = await _userService.CreateAsync(user);
        return Ok(result);
    }
}

