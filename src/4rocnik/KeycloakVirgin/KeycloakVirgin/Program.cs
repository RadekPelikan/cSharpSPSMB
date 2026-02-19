using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using KeycloakVirgin.InstallExtensions;

var builder = WebApplication.CreateBuilder(args);

// http://localhost:8080/realms/virgin/protocol/openid-connect/auth?response_type=code&client_id=virgin-dotnet&redirect_uri=http%3A%2F%2Flocalhost%3A5001%2Fswagger%2Foauth2-redirect.html&scope=openid%20profile&state=VGh1IEZlYiAxOSAyMDI2IDEzOjMxOjIxIEdNVCswMTAwIChzdMWZZWRvZXZyb3Bza8O9IHN0YW5kYXJkbsOtIMSNYXMp&code_challenge=po3hmalEvPOe9_7HY44sSxnplWcYKiTvpkjYLR0VMCU&code_challenge_method=S256

// Add services to the container.

builder.Services.AddControllers();
builder.Services
    .AddVirginAuth(builder.Configuration)
    .AddVirginAuthSwagger(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.OAuthClientId(builder.Configuration["Keycloak:ClientId"]);
        c.OAuthUsePkce();
        c.OAuthScopes("openid", "profile");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseAuthorization();
app.UseAuthorization();

app.Run();