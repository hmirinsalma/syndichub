namespace SyndicHub.Application.DTOs.Auth;

/// <summary>
/// DTO pour l'inscription d'un nouvel utilisateur
/// </summary>
public class RegisterRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Role { get; set; } = "RESIDENT"; // ADMIN, SYNDIC, RESIDENT
    public Guid? ResidenceId { get; set; }
}
