using ToDoList.Entities;

namespace ToDoList.Services;

public interface ITodoService
{
    ValueTask<ICollection<Todo?>> Get(CancellationToken cancellationToken = default);
    
    ValueTask<Todo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    ValueTask<Todo> CreateAsync(Todo todo, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Todo> UpdateAsync(Guid id, Todo todo, bool saveChanges = true, CancellationToken cancellationToken = default);
    
    ValueTask<Todo> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}