using SyndicHub.Application.DTOs.Building;

namespace SyndicHub.Application.Interfaces;

/// <summary>
/// Service métier pour la gestion des immeubles
/// </summary>
public interface IBuildingService
{
    /// <summary>
    /// Créer un nouvel immeuble
    /// </summary>
    Task<BuildingDto> CreateAsync(CreateBuildingDto dto, Guid currentUserId);

    /// <summary>
    /// Obtenir un immeuble par son ID
    /// </summary>
    Task<BuildingDto?> GetByIdAsync(Guid id, Guid currentUserId);

    /// <summary>
    /// Obtenir tous les immeubles d'une résidence
    /// </summary>
    Task<IEnumerable<BuildingDto>> GetByResidenceIdAsync(Guid residenceId, Guid currentUserId);

    /// <summary>
    /// Mettre à jour un immeuble
    /// </summary>
    Task<BuildingDto> UpdateAsync(Guid id, UpdateBuildingDto dto, Guid currentUserId);

    /// <summary>
    /// Supprimer un immeuble (suppression logique)
    /// </summary>
    Task<bool> DeleteAsync(Guid id, Guid currentUserId);
}
