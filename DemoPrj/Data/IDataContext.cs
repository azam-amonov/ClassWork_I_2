using DemoPrj.Models;
using FileBaseContext.Abstractions.Models.FileSet;

namespace DemoPrj.Data;


public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }
    ValueTask SaveChangesAsync();
}
