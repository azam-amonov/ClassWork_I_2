namespace Mapper.Entites;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set;}
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public bool IsDelete { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}