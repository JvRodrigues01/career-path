namespace P2P.Domain.Options;

public class JwtOptions
{
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public string SecretKey { get; init; }
    public string ApiKeyName { get; set; }
    public string ApiKey { get; set; }
}
