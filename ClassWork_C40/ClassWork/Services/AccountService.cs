using ClassWork_C40.ClassWork.Helper;
using N40_C.Models;

namespace ClassWork_C40.ClassWork.Services;

public class AccountService
{
    private List<User> _users;
    private List<Email> _emails;

    public AccountService()
    {
        _users = new List<User>();
        _emails = new List<Email>();
    }

    public void RegisterAsync(string emailAddress, string password)
    {
        // invalid email address
        if (!Validator.IsValidEmail(emailAddress))
            throw new InvalidDataException("Invalid email address");

        // invalid password
        if (Validator.IsValidPassword(password))
            throw new InvalidDataException("Invalid password");

        // email address already exists
        var existingEmail = _users.Any(user => user.EmailAddress.Equals(emailAddress));
        if (existingEmail)
            throw new ArgumentException("This email is already registered");
    }
}