using ClassWork49.API.DataAccsess;
using ClassWork49.API.Models;
using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;

namespace ClassWork49.API.DataAccess;

public class AppFileContext : FileContext, IDataContext
{
    public IFileSet<User, Guid> Users => Set<User>(nameof(Users));
    public IFileSet<Order, Guid> Orders => Set<Order>(nameof(Orders));
    
    public AppFileContext(IFileContextOptions<IFileContext> fileContextOptions, IFileSet<User, Guid> users, IFileSet<Order, Guid> orders) : base(fileContextOptions)
    {
        OnSaveChanges += AddPrimaryKeys;
    }

    protected virtual ValueTask AddPrimaryKeys(IEnumerable<IFileSetBase> fileSets)
    {
        foreach (var fileSetBase in fileSets)
        {
            if (fileSetBase is not IFileSet<IFileSetEntity<Guid>, Guid> fileSet) continue;

            foreach (var entry in fileSet.Where(entry => entry.Id == default))
                entry.Id = Guid.NewGuid();
        }

        return new ValueTask(Task.CompletedTask);
    }
}