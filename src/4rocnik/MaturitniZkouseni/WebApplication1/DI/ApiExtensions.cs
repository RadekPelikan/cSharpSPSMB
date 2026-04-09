using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace WebApplication1.DI;

public static class ApiExtensions
{
    public static WebApplicationBuilder AddKeycloakAuthentication(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var services = builder.Services;
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

        return builder;
    }
    public static WebApplicationBuilder AddKeycloakSwagger(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var services = builder.Services;
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

        return builder;
    }


    public static WebApplication UseKeycloakSwaggerUI(this WebApplication app)
    {
        var configuration = app.Configuration;

        app.UseSwaggerUI(c =>
        {
            c.OAuthClientId(configuration["Keycloak:ClientId"]);
            c.OAuthUsePkce();
            c.OAuthScopes("openid", "profile");
        });
        return app;
    }

}