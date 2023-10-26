
using C_64.Identity.Infrastructure.Common.Identity.Models;

namespace C_64.Identity.Application.Common.Services;

public interface IAuthService
{
    public ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails);
    public ValueTask<string> LoginAsync(LoginDetails loginDetails);
}