using System.ComponentModel.DataAnnotations;
using SyndicHub.Domain.Enums;

namespace SyndicHub.Application.DTOs.Unit;

/// <summary>
/// DTO pour mettre à jour un lot existant
/// </summary>
public class UpdateUnitDto
{
    [Required(ErrorMessage = "Le numéro du lot est obligatoire")]
    [StringLength(20, ErrorMessage = "Le numéro ne peut pas dépasser 20 caractères")]
    public string UnitNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le type du lot est obligatoire")]
    public UnitType Type { get; set; }

    [Required(ErrorMessage = "L'étage est obligatoire")]
    [Range(-5, 100, ErrorMessage = "L'étage doit être entre -5 (sous-sol) et 100")]
    public int Floor { get; set; }

    [Required(ErrorMessage = "La surface est obligatoire")]
    [Range(0.01, 10000, ErrorMessage = "La surface doit être entre 0.01 et 10000 m²")]
    public decimal Surface { get; set; }

    [Required(ErrorMessage = "Les tantièmes sont obligatoires")]
    [Range(1, 1000000, ErrorMessage = "Les tantièmes doivent être entre 1 et 1 000 000")]
    public int Shares { get; set; }

    /// <summary>
    /// ID du résident qui occupe ce lot (optionnel, null = lot vacant)
    /// </summary>
    public Guid? ResidentId { get; set; }
}
