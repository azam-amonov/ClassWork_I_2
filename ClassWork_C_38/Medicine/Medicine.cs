namespace ClassWork_C_38.Medicine;

public class Medicine
{
    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public uint LeftCount { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime ExpirationDate { get; set; }

    public Medicine(long id, string name, decimal price, uint leftCount, string description, DateTime updatedAt, DateTime expirationDate)
    {
        Id = id;
        Name = name;
        Price = price;
        LeftCount = leftCount;
        Description = description;
        CreatedAt = DateTime.Now;
        UpdatedAt = updatedAt;
        ExpirationDate = expirationDate;
    }

    public override string ToString()
    {
        return $"Id:{Id} Name:{Name} Price:{Price} LeftCount:{LeftCount} ";
    }
}