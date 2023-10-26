using ClassMiddleWare.API.Entitiy;
using ClassMiddleWare.API.Models.DTOs;

namespace ClassMiddleWare.API.Services;

public class AuthService
{
    private readonly TokenGeneratorService _tokenGeneratorService;

    public AuthService(TokenGeneratorService tokenGeneratorService)
    {
        _tokenGeneratorService = tokenGeneratorService;
    }
    
    private static readonly List<User> _users = new ();

    public  ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails)
    {
        var user = new User
        {
                        Id = Guid.NewGuid(),
                        FirstName = registrationDetails.FirstName,
                        LastName = registrationDetails.LastName,
                        Email = registrationDetails.Email,
                        Age = registrationDetails.Age,
                        Password = registrationDetails.Password
        };
        _users.Add(user);
        
        return new (true);
    }

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var foundUser = _users.FirstOrDefault(user => user.Email == loginDetails.EmailAddress && user.Password == loginDetails.Password);
        if (foundUser is null)
            throw new ArgumentException("Error login");

        var accessToken = _tokenGeneratorService.GetToken(foundUser);
        return new (accessToken);
    }
}