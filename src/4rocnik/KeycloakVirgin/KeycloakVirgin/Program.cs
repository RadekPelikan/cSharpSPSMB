using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// http://localhost:8080/realms/virgin/protocol/openid-connect/auth?response_type=code&client_id=virgin-dotnet&redirect_uri=http%3A%2F%2Flocalhost%3A5001%2Fswagger%2Foauth2-redirect.html&scope=openid%20profile&state=VGh1IEZlYiAxOSAyMDI2IDEzOjMxOjIxIEdNVCswMTAwIChzdMWZZWRvZXZyb3Bza8O9IHN0YW5kYXJkbsOtIMSNYXMp&code_challenge=po3hmalEvPOe9_7HY44sSxnplWcYKiTvpkjYLR0VMCU&code_challenge_method=S256

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSwagger",
        policy =>
        {
            policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin(); // dev only
        });
});


var configuration = builder.Configuration;
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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

builder.Services.AddSwaggerGen(o =>
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.OAuthClientId(configuration["Keycloak:ClientId"]);
        c.OAuthUsePkce();
        c.OAuthScopes("openid", "profile");
    });
}

app.UseCors("AllowSwagger");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseAuthorization();
app.UseAuthorization();

app.Run();