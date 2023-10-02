using ClassWork49.API.Models;
using FileBaseContext.Abstractions.Models.FileSet;

namespace ClassWork49.API.DataAccsess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }
    IFileSet<Order, Guid> Orders { get; }
    
    ValueTask SaveChangesAsync();
}