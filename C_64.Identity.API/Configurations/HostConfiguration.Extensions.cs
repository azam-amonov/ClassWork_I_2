using C_64.Identity.Application.Common.Services;
using C_64.Identity.Application.Common.Settings;
using C_64.Identity.Infrastructure.Common.Identity.Service;

namespace C_64.Identity.API.Configurations;

public static partial class HostConfiguration
{
    public static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddEndpointsApiExplorer();
        
        return builder;
    }

    public static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));

        builder.Services.AddTransient<ITokenGeneratorService, TokenGeneratorService>();

        builder.Services.AddScoped<IAuthService, AuthService>();
        
        return builder;
    }

}

