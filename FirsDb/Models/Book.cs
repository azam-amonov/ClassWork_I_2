namespace FirsDb.Models;

public class Book
{
    public Guid Id { get; set; }

    public Guid AuthorId { get; set; }
    
    public string Title { get; set; } = default!;

    public string Description { get; set; } = default!;
    
    public virtual Author Author { get; set;} = default!;
}
    