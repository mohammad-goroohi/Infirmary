namespace Infirmary.Models.Authenticate
{
    public record AuthResult(bool Succeeded, string? ErrorMessage = null);
}
