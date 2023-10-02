using System.Linq.Expressions;
using ClassWork49.API.Models;

namespace ClassWork49.API.Services;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>> predicate);

    ValueTask<ICollection<User>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    ValueTask<User?> GetByIdAsync(Guid ids, CancellationToken cancellationToken = default);
    
}

