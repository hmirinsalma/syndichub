namespace SyndicHub.Application.DTOs.Residence;

/// <summary>
/// DTO pour la réponse d'une résidence
/// </summary>
public class ResidenceDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? PostalCode { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    
    // Syndic responsable
    public Guid SyndicId { get; set; }
    public string? SyndicName { get; set; }
    
    // Statistiques
    public int BuildingsCount { get; set; }
    public int UnitsCount { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
