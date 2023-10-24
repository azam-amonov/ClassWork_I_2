using DemoPrj.DTOs;
using DemoPrj.Models;
using DemoPrj.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace DemoPrj.Controllers;
[ApiController]
[Route("/api/[controller]")]

public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult CreateUser(UserForCreation userForCreation)
    {
        var user = userForCreation.Adapt<User>();
        user.Id = Guid.NewGuid();
        
        _userService.Create(user);
        
        return Ok(user);
    }

    [HttpGet]
    [Route("/api/{userId:guid}")]
    
    public IActionResult GetUser([FromBody] Guid userId)
    {
        var user = _userService.GetUser(userId);
        var searchUser = user.Adapt<UserViewModel>();
        return Ok(searchUser);
    }
}