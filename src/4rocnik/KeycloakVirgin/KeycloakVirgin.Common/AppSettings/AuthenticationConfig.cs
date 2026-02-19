using Microsoft.Extensions.Configuration;

namespace KeycloakVirgin.Common.AppSettings;

public class AuthenticationConfig
{
    public AuthenticationConfig(IConfiguration configuration)
    {
        if (configuration is null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        configuration.GetSection("Authentication").Bind(this);
    }

    public string Audience { get; set; } = "account";
    public string MetadataAddress { get; set; } = string.Empty;
    public string ValidIssuer { get; set; } = string.Empty;
    public string Realm { get; set; } = "virgin";
    public string Host { get; set; } = "http://localhost:8080";

    public string GetMetadataAddress()
    {
        if (!string.IsNullOrEmpty(MetadataAddress))
        {
            return MetadataAddress;
        }
        
        return $"{Host}/realms/{Realm}/.well-known/openid-configuration";
    }

    public string GetValidIssuer()
    {
        if (!string.IsNullOrEmpty(ValidIssuer))
        {
            return ValidIssuer;
        }
        
        return $"{Host}/realms/{Realm}";
    }
}
