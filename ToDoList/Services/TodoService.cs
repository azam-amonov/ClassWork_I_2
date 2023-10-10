using ToDoList.Data;
using ToDoList.Entities;

namespace ToDoList.Services;

public class TodoService : ITodoService
{
    private IDataContext _appDataContext;

    public TodoService(IDataContext appDataContext)
    {
        _appDataContext = appDataContext;
    }

    public async ValueTask<ICollection<Todo?>> Get(CancellationToken cancellationToken = default)
    {
        return await _appDataContext.Todos.ToListAsync(cancellationToken);
    }

    public async ValueTask<Todo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) 
        => await _appDataContext.Todos.FindAsync(id, cancellationToken);
    

    public async ValueTask<Todo> CreateAsync(Todo todo, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var existsTodo = await GetByIdAsync(todo.Id, cancellationToken);
        if (existsTodo is not null)
            throw new InvalidOperationException("Task is already created");

        await _appDataContext.Todos.AddAsync(todo, cancellationToken);
        if (saveChanges)
            await _appDataContext.SaveChangesAsync();
        
        return todo;
    }

    public async ValueTask<Todo> UpdateAsync(Guid id, Todo todo, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var existsTodo = await GetByIdAsync(id, cancellationToken);
        if (existsTodo is null) throw new InvalidOperationException("Task is not exists");
        
        existsTodo.Id = todo.Id;
        existsTodo.Title = todo.Title;
        existsTodo.Description = todo.Description;
        existsTodo.StartTime = todo.StartTime;
        existsTodo.EndTime = todo.EndTime;
        existsTodo.Duration = todo.Duration;

        return existsTodo;
    }

    public async ValueTask<Todo> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var todoToDelete = await GetByIdAsync(id, cancellationToken);
        if (todoToDelete is null) 
            throw new InvalidOperationException("Task is not exists");

        await _appDataContext.Todos.RemoveAsync(todoToDelete, cancellationToken);
        if (saveChanges) await _appDataContext.Todos.SaveChangesAsync(cancellationToken);
        
        return todoToDelete;
    }
}