using Microsoft.Extensions.Configuration;

namespace KeycloakVirgin.Common.AppSettings;

public class KeycloakConfig
{
    public KeycloakConfig(IConfiguration configuration)
    {
        if (configuration is null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        configuration.GetSection("Keycloak").Bind(this);
    }

    public string ClientId { get; set; } = string.Empty;
    public string AuthorizationUrl { get; set; } = string.Empty;
    public string TokenUrl { get; set; } = string.Empty;
    public string Realm { get; set; } = "virgin";
    public string Host { get; set; } = "http://localhost:8080";

    public string GetAuthorizationUrl()
    {
        if (!string.IsNullOrEmpty(AuthorizationUrl))
        {
            return AuthorizationUrl;
        }
        
        return $"{Host}/realms/{Realm}/protocol/openid-connect/auth";
    }

    public string GetTokenUrl()
    {
        if (!string.IsNullOrEmpty(TokenUrl))
        {
            return TokenUrl;
        }
        
        return $"{Host}/realms/{Realm}/protocol/openid-connect/token";
    }
}
