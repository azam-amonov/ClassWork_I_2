using FileBaseContext.Abstractions.Models.Entity;

namespace ClassWork49.API.Models;

public class Order : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int Amount { get; set; }
}