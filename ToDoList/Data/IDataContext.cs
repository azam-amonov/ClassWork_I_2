using FileBaseContext.Abstractions.Models.FileSet;
using ToDoList.Entities;

namespace ToDoList.Data;

public interface IDataContext
{
        IFileSet<User, Guid> Users { get; }

        IFileSet<Todo?, Guid> Todos { get; }

        ValueTask SaveChangesAsync();
}