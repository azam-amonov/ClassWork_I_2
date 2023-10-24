using DemoPrj.Models;
using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;

namespace DemoPrj.Data;

public class AppDataContext:  FileContext, IDataContext
{
    public AppDataContext(IFileContextOptions<IFileContext> fileContextOptions, IFileSet<User, Guid> users) : base(fileContextOptions)
    {
        OnSaveChanges += AddPrimaryKeys;
    }
    
    
    private ValueTask AddPrimaryKeys(IEnumerable<IFileSetBase> fileSets)
    {
        foreach (var fileSetBase in fileSets)
        {
            if (fileSetBase is not IFileSet<IFileSetEntity<Guid>, Guid> fileSet) continue;

            foreach (var entry in fileSet.Where(entry => entry.Id == default))
                entry.Id = Guid.NewGuid();
        }

        return new ValueTask(Task.CompletedTask);
    }
    public IFileSet<User, Guid> Users { get; }
}