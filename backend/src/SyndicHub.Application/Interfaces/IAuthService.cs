using SyndicHub.Application.DTOs.Auth;

namespace SyndicHub.Application.Interfaces;

/// <summary>
/// Interface pour le service d'authentification
/// </summary>
public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(RegisterRequest request);
    Task<AuthResponse> LoginAsync(LoginRequest request);
}
