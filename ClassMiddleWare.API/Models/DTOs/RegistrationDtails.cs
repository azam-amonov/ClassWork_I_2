namespace ClassMiddleWare.API.Models.DTOs;

public class RegistrationDetails
{
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    public int Age { get; set; }
    
    public string Email { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;
}