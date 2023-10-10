using ToDoList.Data;
using ToDoList.Entities;

namespace ToDoList.Services;

public class UserService: IUserService
{
    private readonly IDataContext _appDataContext;

    public UserService(IDataContext appDataContext)
    {
        _appDataContext = appDataContext;
    }

    public async ValueTask<ICollection<User>> Get(CancellationToken cancellationToken = default)
    {
        return await _appDataContext.Users.ToListAsync(cancellationToken);
    }

    public async ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
                    _appDataContext.Users.FirstOrDefault(u => u.Id == id);

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var existsUser = await GetByIdAsync(user.Id, cancellationToken);
        
        if (existsUser is not null)
            throw new InvalidOperationException("User with this Id is already exists!");

        await _appDataContext.Users.AddAsync(user, cancellationToken);
        
        if (saveChanges)
           await _appDataContext.SaveChangesAsync();
        
        return user;
    }

    public async ValueTask<User> UpdateAsync(Guid id, User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var existsUser = await GetByIdAsync(id, cancellationToken);
        
        if (existsUser is null)
            throw new InvalidOperationException("This user does not exist!");
        
        existsUser.Id = user.Id;
        existsUser.FirstName = user.FirstName;
        existsUser.LastName = user.LastName;
        existsUser.Email = user.Email;
        existsUser.Password = user.Password;

        if (saveChanges)
            await _appDataContext.SaveChangesAsync();
        
        return existsUser;
    }

    public async ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var userToDelete = await GetByIdAsync(id, cancellationToken);
        
        if (userToDelete is null) 
            throw new InvalidOperationException("This user does not exist!");
        
        await _appDataContext.Users.RemoveAsync(userToDelete, cancellationToken);
        
        if (saveChanges) 
            await _appDataContext.SaveChangesAsync();
        
        return userToDelete;
    }
}