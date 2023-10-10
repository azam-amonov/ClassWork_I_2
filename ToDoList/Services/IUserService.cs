using ToDoList.Entities;

namespace ToDoList.Services;

public interface IUserService
{
    ValueTask<ICollection<User>> Get (CancellationToken cancellationToken = default);
    
    ValueTask<User?> GetByIdAsync (Guid id, CancellationToken cancellationToken = default);
    
    ValueTask<User> CreateAsync (User user, bool saveChanges = true, CancellationToken cancellationToken = default);
    
    ValueTask<User> UpdateAsync (Guid id,User user,bool saveChanges = true, CancellationToken cancellationToken = default);
    
    ValueTask<User> DeleteAsync (Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}