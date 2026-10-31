namespace SyndicHub.Application.DTOs.Building;

/// <summary>
/// DTO pour la réponse d'un immeuble
/// </summary>
public class BuildingDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int FloorsCount { get; set; }
    
    // Résidence parente
    public Guid ResidenceId { get; set; }
    public string? ResidenceName { get; set; }
    
    // Statistiques
    public int UnitsCount { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
