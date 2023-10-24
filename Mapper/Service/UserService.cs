using Mapper.DTOs;
using Mapper.Entites;
using Mapster;

namespace Mapper.Service;

public class UserService
{
    private readonly List<User> _users = new ();

    public User Create(UserForCreation userForCreation)
    {
        var existingUser = _users.FirstOrDefault(u => u.Email == userForCreation.Email);
        if (existingUser is not null)
        {
            Console.WriteLine("Creating user is exits");
            return existingUser;
        }
        
        // Mapsterdan keluvchi Adapt extensions ishlatiladi
        var newUser = userForCreation.Adapt<User>();
        _users.Add(newUser);
        return newUser;
    }

    public UserViewModel GetUser(Guid userId)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);
        return user.Adapt<UserViewModel>();
    }
}