using Microsoft.AspNetCore.Mvc;
using ToDoList.Entities;
using ToDoList.Services;

namespace ToDoList.Controllers;


[ApiController]
[Route("/api/[controller]")]

public class ToDoController: ControllerBase
{
    private ITodoService _todoService;

    public ToDoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var result = await _todoService.Get();
        return Ok(result);
    }

    [HttpGet]
    [Route("getById/{id:guid}")]
    public async ValueTask<IActionResult> GetByGuid(Guid id)
    {
        var result = await _todoService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(Todo todo)
    {
        var result = await _todoService.CreateAsync(todo);
        return Ok(result);
    }

    [HttpPut]
    [Route("update/{id:guid}")]
    public async ValueTask<IActionResult> UpdateAsync(Guid id, Todo todo)
    {
        var result = await _todoService.UpdateAsync(id, todo);
        return Ok(result);
    }

    
    [HttpDelete]
    [Route("delete/{id:guid}")]
    public async ValueTask<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _todoService.DeleteAsync(id);
        return Ok(result);
    }
}