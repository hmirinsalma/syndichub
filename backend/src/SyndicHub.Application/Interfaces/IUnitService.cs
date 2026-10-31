using SyndicHub.Application.DTOs.Unit;

namespace SyndicHub.Application.Interfaces;

/// <summary>
/// Service métier pour la gestion des lots
/// </summary>
public interface IUnitService
{
    /// <summary>
    /// Créer un nouveau lot
    /// </summary>
    Task<UnitDto> CreateAsync(CreateUnitDto dto, Guid currentUserId);

    /// <summary>
    /// Obtenir un lot par son ID
    /// </summary>
    Task<UnitDto?> GetByIdAsync(Guid id, Guid currentUserId);

    /// <summary>
    /// Obtenir tous les lots d'un immeuble
    /// </summary>
    Task<IEnumerable<UnitDto>> GetByBuildingIdAsync(Guid buildingId, Guid currentUserId);

    /// <summary>
    /// Obtenir tous les lots d'une résidence
    /// </summary>
    Task<IEnumerable<UnitDto>> GetByResidenceIdAsync(Guid residenceId, Guid currentUserId);

    /// <summary>
    /// Mettre à jour un lot
    /// </summary>
    Task<UnitDto> UpdateAsync(Guid id, UpdateUnitDto dto, Guid currentUserId);

    /// <summary>
    /// Supprimer un lot (suppression logique)
    /// </summary>
    Task<bool> DeleteAsync(Guid id, Guid currentUserId);
}
