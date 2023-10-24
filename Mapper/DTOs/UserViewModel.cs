namespace Mapper.DTOs;

public class UserViewModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set;}
    public string Email { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedTime { get; set; }
}