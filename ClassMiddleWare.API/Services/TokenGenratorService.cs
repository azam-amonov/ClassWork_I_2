using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ClassMiddleWare.API.Constants;
using ClassMiddleWare.API.Models.Entitiy;
using Microsoft.IdentityModel.Tokens;

namespace ClassMiddleWare.API.Services;

public class TokenGeneratorService : ITokenGeneratorService, ITokenGeneratorService
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