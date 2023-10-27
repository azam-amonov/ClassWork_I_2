using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using C_64.Identity.Domain.Entity;
using Microsoft.IdentityModel.Tokens;
using C_64.Identity.Application.Common.Services;
using C_64.Identity.Application.Common.Constants;

namespace C_64.Identity.Infrastructure.Common.Identity.Service;

public class TokenGeneratorService //: ITokenGeneratorService
{
    private string SecretKey = "mySecretKey";

    public string GetToken(User user)
    {
        var jwtToken = GetJwtToken(user);
        
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        
        return token;
    }

    public JwtSecurityToken GetJwtToken(User user)
    {
        var claims = GetClaims(user);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(issuer: "TodoApp",
                        audience: "Todo.ClaintApp",
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: credentials);
    }

    public List<Claim> GetClaims(User user)
    {
        return new List<Claim>()
        {
                        new(ClaimTypes.Email, user.Email),
                        new(ClaimConstants.UserId, user.Id.ToString()),
        };
    }
}