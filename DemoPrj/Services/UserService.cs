using DemoPrj.Models;

namespace DemoPrj.Services;

public class UserService
{
    private List<User> _users = new();

    public User Create(User user)
    {
        var existingUser = _users.FirstOrDefault(u => u.Email == user.Email);
        if (existingUser is not null)
        {
            throw new ArgumentException("This email is already in use");
        }
        
        _users.Add(user);
        return user;
    }

    public User GetUser(Guid userId) => _users.FirstOrDefault(u => u.Id == userId);
    
}