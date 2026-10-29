using Microsoft.AspNetCore.Identity;

namespace SyndicHub.Domain.Entities;

/// <summary>
/// Représente un utilisateur du système (ADMIN, SYNDIC, RESIDENT)
/// Hérite de IdentityUser pour utiliser ASP.NET Core Identity
/// </summary>
public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    /// <summary>
    /// Role: ADMIN, SYNDIC, RESIDENT
    /// </summary>
    public string Role { get; set; } = string.Empty;
    
    /// <summary>
    /// ID de la résidence (null pour ADMIN)
    /// </summary>
    public Guid? ResidenceId { get; set; }
    
    public bool IsActive { get; set; } = true;
    
    public bool IsDeleted { get; set; } = false;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public Residence? Residence { get; set; }
}
