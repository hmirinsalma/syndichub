using SyndicHub.Domain.Enums;

namespace SyndicHub.Application.DTOs.Unit;

/// <summary>
/// DTO pour la réponse d'un lot (appartement, local commercial, etc.)
/// </summary>
public class UnitDto
{
    public Guid Id { get; set; }
    public string UnitNumber { get; set; } = string.Empty;
    public UnitType Type { get; set; }
    public string TypeDisplay { get; set; } = string.Empty;
    public int Floor { get; set; }
    public decimal Surface { get; set; }
    public int Shares { get; set; } // Tantièmes
    
    // Immeuble parent
    public Guid BuildingId { get; set; }
    public string? BuildingName { get; set; }
    
    // Résidence
    public Guid ResidenceId { get; set; }
    public string? ResidenceName { get; set; }
    
    // Résident actuel
    public Guid? ResidentId { get; set; }
    public string? ResidentName { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
