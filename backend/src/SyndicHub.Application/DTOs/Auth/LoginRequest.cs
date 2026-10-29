namespace SyndicHub.Application.DTOs.Auth;

/// <summary>
/// DTO pour la connexion
/// </summary>
public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
