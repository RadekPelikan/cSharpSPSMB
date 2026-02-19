using EFCoreVIrgin.Data.EF.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace KeycloakVirgin.InstallExtensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddSqlLite(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddTransient<AppDbContext>();
    }
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        
    }
    public static IServiceCollection AddVirginAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuthorization();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.Audience = configuration["Authentication:Audience"];
                o.MetadataAddress = configuration["Authentication:MetadataAddress"];
                o.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = configuration["Authentication:ValidIssuer"]
                };
            });

        return services;
    }
    
    public static IServiceCollection AddVirginAuthSwagger(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddSwaggerGen(o =>
        {
            o.CustomSchemaIds(id => id.FullName!.Replace('+', '-'));

            o.AddSecurityDefinition("Keycloak", new OpenApiSecurityScheme()
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows()
                {
                    AuthorizationCode = new OpenApiOAuthFlow()
                    {
                        AuthorizationUrl = new Uri(configuration["Keycloak:AuthorizationUrl"]),
                        TokenUrl = new Uri(configuration["Keycloak:TokenUrl"]),
                        Scopes = new Dictionary<string, string>()
                        {
                            { "openid", "openid" },
                            { "profile", "profile" },
                        }
                    }
                }
            });

            o.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Keycloak"
                        },
                        Scheme = "oauth2",
                        Name = "Keycloak",
                        In = ParameterLocation.Header
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }
}