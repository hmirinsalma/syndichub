using System.ComponentModel.DataAnnotations;

namespace SyndicHub.Application.DTOs.Residence;

/// <summary>
/// DTO pour mettre à jour une résidence existante
/// </summary>
public class UpdateResidenceDto
{
    [Required(ErrorMessage = "Le nom de la résidence est obligatoire")]
    [StringLength(200, ErrorMessage = "Le nom ne peut pas dépasser 200 caractères")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "L'adresse est obligatoire")]
    [StringLength(300, ErrorMessage = "L'adresse ne peut pas dépasser 300 caractères")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "La ville est obligatoire")]
    [StringLength(100, ErrorMessage = "La ville ne peut pas dépasser 100 caractères")]
    public string City { get; set; } = string.Empty;

    [StringLength(20, ErrorMessage = "Le code postal ne peut pas dépasser 20 caractères")]
    public string? PostalCode { get; set; }

    [Phone(ErrorMessage = "Le numéro de téléphone n'est pas valide")]
    [StringLength(20, ErrorMessage = "Le téléphone ne peut pas dépasser 20 caractères")]
    public string? Phone { get; set; }

    [EmailAddress(ErrorMessage = "L'adresse email n'est pas valide")]
    [StringLength(100, ErrorMessage = "L'email ne peut pas dépasser 100 caractères")]
    public string? Email { get; set; }
}
