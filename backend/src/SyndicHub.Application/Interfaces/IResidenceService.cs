using SyndicHub.Application.DTOs.Residence;

namespace SyndicHub.Application.Interfaces;

/// <summary>
/// Service métier pour la gestion des résidences
/// </summary>
public interface IResidenceService
{
    /// <summary>
    /// Créer une nouvelle résidence
    /// </summary>
    Task<ResidenceDto> CreateAsync(CreateResidenceDto dto, Guid currentUserId);

    /// <summary>
    /// Obtenir une résidence par son ID
    /// </summary>
    Task<ResidenceDto?> GetByIdAsync(Guid id, Guid currentUserId);

    /// <summary>
    /// Obtenir toutes les résidences (filtrées par utilisateur)
    /// </summary>
    Task<IEnumerable<ResidenceDto>> GetAllAsync(Guid currentUserId, bool isAdmin);

    /// <summary>
    /// Mettre à jour une résidence
    /// </summary>
    Task<ResidenceDto> UpdateAsync(Guid id, UpdateResidenceDto dto, Guid currentUserId);

    /// <summary>
    /// Supprimer une résidence (suppression logique)
    /// </summary>
    Task<bool> DeleteAsync(Guid id, Guid currentUserId);
}
