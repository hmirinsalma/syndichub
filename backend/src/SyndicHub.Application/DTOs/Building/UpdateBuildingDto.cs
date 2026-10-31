using System.ComponentModel.DataAnnotations;

namespace SyndicHub.Application.DTOs.Building;

/// <summary>
/// DTO pour mettre à jour un immeuble existant
/// </summary>
public class UpdateBuildingDto
{
    [Required(ErrorMessage = "Le nom de l'immeuble est obligatoire")]
    [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Le nombre d'étages est obligatoire")]
    [Range(1, 100, ErrorMessage = "Le nombre d'étages doit être entre 1 et 100")]
    public int FloorsCount { get; set; }
}
