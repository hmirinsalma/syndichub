using Microsoft.EntityFrameworkCore;
using SyndicHub.Application.DTOs.Building;
using SyndicHub.Application.Interfaces;
using SyndicHub.Domain.Entities;
using SyndicHub.Infrastructure.Data;

namespace SyndicHub.Infrastructure.Services;

/// <summary>
/// Service métier pour gérer les immeubles
/// </summary>
public class BuildingService : IBuildingService
{
    private readonly ApplicationDbContext _context;

    public BuildingService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BuildingDto> CreateAsync(CreateBuildingDto dto, Guid currentUserId)
    {
        // Vérifier que la résidence existe
        var residence = await _context.Residences
            .FirstOrDefaultAsync(r => r.Id == dto.ResidenceId && !r.IsDeleted);

        if (residence == null)
            throw new Exception("Résidence introuvable");

        var building = new Building
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            FloorsCount = dto.FloorsCount,
            ResidenceId = dto.ResidenceId,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = currentUserId
        };

        _context.Buildings.Add(building);
        await _context.SaveChangesAsync();

        return await MapToDto(building);
    }

    public async Task<BuildingDto?> GetByIdAsync(Guid id, Guid currentUserId)
    {
        var building = await _context.Buildings
            .Include(b => b.Residence)
            .Include(b => b.Units)
            .FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

        if (building == null)
            return null;

        return await MapToDto(building);
    }

    public async Task<IEnumerable<BuildingDto>> GetByResidenceIdAsync(Guid residenceId, Guid currentUserId)
    {
        var buildings = await _context.Buildings
            .Include(b => b.Residence)
            .Include(b => b.Units)
            .Where(b => b.ResidenceId == residenceId && !b.IsDeleted)
            .ToListAsync();

        var dtos = new List<BuildingDto>();
        foreach (var building in buildings)
        {
            dtos.Add(await MapToDto(building));
        }

        return dtos;
    }

    public async Task<BuildingDto> UpdateAsync(Guid id, UpdateBuildingDto dto, Guid currentUserId)
    {
        var building = await _context.Buildings
            .FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

        if (building == null)
            throw new Exception("Immeuble introuvable");

        building.Name = dto.Name;
        building.Description = dto.Description;
        building.FloorsCount = dto.FloorsCount;
        building.UpdatedAt = DateTime.UtcNow;
        building.UpdatedBy = currentUserId;

        await _context.SaveChangesAsync();

        return await MapToDto(building);
    }

    public async Task<bool> DeleteAsync(Guid id, Guid currentUserId)
    {
        var building = await _context.Buildings
            .FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

        if (building == null)
            return false;

        // Suppression logique
        building.IsDeleted = true;
        building.UpdatedAt = DateTime.UtcNow;
        building.UpdatedBy = currentUserId;

        await _context.SaveChangesAsync();

        return true;
    }

    private async Task<BuildingDto> MapToDto(Building building)
    {
        var unitsCount = await _context.Units
            .CountAsync(u => u.BuildingId == building.Id && !u.IsDeleted);

        return new BuildingDto
        {
            Id = building.Id,
            Name = building.Name,
            Description = building.Description,
            FloorsCount = building.FloorsCount,
            ResidenceId = building.ResidenceId,
            ResidenceName = building.Residence?.Name,
            UnitsCount = unitsCount,
            CreatedAt = building.CreatedAt,
            UpdatedAt = building.UpdatedAt
        };
    }
}
