using EFCoreVIrgin.Data.EF.Context;
using KeycloakVirgin.Data.EF.Pg.Context;
using KeycloakVirgin.Common.AppSettings;
using KeycloakVirgin.Common.Repository;
using KeycloakVirgin.Data.EF.Audit;
using KeycloakVirgin.Data.EF.Repository;
using KeycloakVirgin.Data.EF.Sqlite.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace KeycloakVirgin.InstallExtensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        var databaseConfig = new DatabaseConfig(configuration);
        services.AddSingleton(databaseConfig);
        
        // Register the appropriate DbContext based on the provider
        switch (databaseConfig.Provider)
        {
            case DatabaseProvider.Sqlite:
                services.AddDbContext<SqliteAppDbContext>((serviceProvider, options) =>
                {
                    var config = serviceProvider.GetRequiredService<DatabaseConfig>();
                    var connectionString = config.GetConnectionString();
                    
                    options.UseSqlite(connectionString,
                        b => b.MigrationsHistoryTable("__EFMigrationsHistory_Sqlite")
                              .MigrationsAssembly(typeof(SqliteAppDbContext).Assembly.GetName().Name));
                });
                services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<SqliteAppDbContext>());
                break;
                
            case DatabaseProvider.PostgreSql:
                services.AddDbContext<PostgreSqlAppDbContext>((serviceProvider, options) =>
                {
                    var config = serviceProvider.GetRequiredService<DatabaseConfig>();
                    var connectionString = config.GetConnectionString();
                    
                    options.UseNpgsql(connectionString,
                        b => b.MigrationsHistoryTable("__EFMigrationsHistory_PostgreSql")
                              .MigrationsAssembly(typeof(PostgreSqlAppDbContext).Assembly.GetName().Name));
                });
                services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<PostgreSqlAppDbContext>());
                break;
                
            default:
                throw new ArgumentException($"Unsupported database provider: {databaseConfig.Provider}");
        }
        
        return services;
    }
    
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Add repository registrations here
        services.AddScoped<AuditContext>(provider =>
        {
            var httpContextAccessor = provider.GetService<IHttpContextAccessor>();
            var auditContext = new AuditContext();
            
            if (httpContextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated == true)
            {
                // Try to get the user ID from claims
                var userIdClaim = httpContextAccessor.HttpContext.User.FindFirst("sub") // Keycloak uses "sub" for user ID
                    ?? httpContextAccessor.HttpContext.User.FindFirst("userId")
                    ?? httpContextAccessor.HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                
                if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out var userId))
                {
                    auditContext.UserId = userId;
                }
            }
            
            return auditContext;
        });
        
        services.AddScoped<IBasketRepository, BasketRepository>();
        
        return services;
    }
    
    public static IServiceCollection AddVirginAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var authConfig = new AuthenticationConfig(configuration);
        
        services.AddSingleton(authConfig);
        
        services.AddAuthorization();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.Audience = authConfig.Audience;
                o.MetadataAddress = authConfig.GetMetadataAddress();
                o.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = authConfig.GetValidIssuer()
                };
            });

        return services;
    }
    
    public static IServiceCollection AddVirginAuthSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        var keycloakConfig = new KeycloakConfig(configuration);
        
        services.AddSingleton(keycloakConfig);
        
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
                        AuthorizationUrl = new Uri(keycloakConfig.GetAuthorizationUrl()),
                        TokenUrl = new Uri(keycloakConfig.GetTokenUrl()),
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
