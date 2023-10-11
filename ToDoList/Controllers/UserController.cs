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
    [Route("getByID/{id:guid}")]
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

    [HttpPut]
    [Route("update/{id:guid}")]
    public async ValueTask<IActionResult> UpdateAsync(Guid id, User user)
    {
        var result = await _userService.UpdateAsync(id, user);
        return Ok(result);
    }

    [HttpDelete]
    [Route("delete/{id:guid}")]

    public async ValueTask<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _userService.DeleteAsync(id);
        return Ok(result);
    }
}

