using System.ComponentModel.DataAnnotations;

namespace SyndicHub.Application.DTOs.Building;

/// <summary>
/// DTO pour créer un nouvel immeuble
/// </summary>
public class CreateBuildingDto
{
    [Required(ErrorMessage = "Le nom de l'immeuble est obligatoire")]
    [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Le nombre d'étages est obligatoire")]
    [Range(1, 100, ErrorMessage = "Le nombre d'étages doit être entre 1 et 100")]
    public int FloorsCount { get; set; }

    [Required(ErrorMessage = "L'ID de la résidence est obligatoire")]
    public Guid ResidenceId { get; set; }
}
