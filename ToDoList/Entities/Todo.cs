using FileBaseContext.Abstractions.Models.Entity;

namespace ToDoList.Entities;

public class Todo : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }
    
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }
    
    public int Duration { get; set; }
}