using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using C_64.Identity.Domain.Entity;

namespace C_64.Identity.Application.Common.Services;

public interface ITokenGeneratorService
{
    public string GetToken(User user);
    public JwtSecurityToken GetJwtToken(User user);
    public List<Claim> GetClaims(User user);
}