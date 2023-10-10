using FileBaseContext.Abstractions.Models.Entity;

namespace ToDoList.Entities;

public class User : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
}