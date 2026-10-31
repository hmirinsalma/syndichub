using Microsoft.EntityFrameworkCore;
using SyndicHub.Application.DTOs.Unit;
using SyndicHub.Application.Interfaces;
using SyndicHub.Domain.Entities;
using SyndicHub.Infrastructure.Data;

namespace SyndicHub.Infrastructure.Services;

/// <summary>
/// Service métier pour gérer les lots
/// </summary>
public class UnitService : IUnitService
{
    private readonly ApplicationDbContext _context;

    public UnitService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UnitDto> CreateAsync(CreateUnitDto dto, Guid currentUserId)
    {
        // Vérifier que l'immeuble existe
        var building = await _context.Buildings
            .Include(b => b.Residence)
            .FirstOrDefaultAsync(b => b.Id == dto.BuildingId && !b.IsDeleted);

        if (building == null)
            throw new Exception("Immeuble introuvable");

        // Vérifier que le numéro de lot n'existe pas déjà dans cet immeuble
        var existingUnit = await _context.Units
            .AnyAsync(u => u.BuildingId == dto.BuildingId && 
                          u.UnitNumber == dto.UnitNumber && 
                          !u.IsDeleted);

        if (existingUnit)
            throw new Exception($"Le lot {dto.UnitNumber} existe déjà dans cet immeuble");

        var unit = new Domain.Entities.Unit
        {
            Id = Guid.NewGuid(),
            UnitNumber = dto.UnitNumber,
            Type = dto.Type,
            Floor = dto.Floor,
            Surface = dto.Surface,
            Shares = dto.Shares,
            BuildingId = dto.BuildingId,
            ResidentId = dto.ResidentId,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = currentUserId
        };

        _context.Units.Add(unit);
        await _context.SaveChangesAsync();

        return await MapToDto(unit);
    }

    public async Task<UnitDto?> GetByIdAsync(Guid id, Guid currentUserId)
    {
        var unit = await _context.Units
            .Include(u => u.Building)
            .ThenInclude(b => b.Residence)
            .Include(u => u.Resident)
            .FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);

        if (unit == null)
            return null;

        return await MapToDto(unit);
    }

    public async Task<IEnumerable<UnitDto>> GetByBuildingIdAsync(Guid buildingId, Guid currentUserId)
    {
        var units = await _context.Units
            .Include(u => u.Building)
            .ThenInclude(b => b.Residence)
            .Include(u => u.Resident)
            .Where(u => u.BuildingId == buildingId && !u.IsDeleted)
            .ToListAsync();

        var dtos = new List<UnitDto>();
        foreach (var unit in units)
        {
            dtos.Add(await MapToDto(unit));
        }

        return dtos;
    }

    public async Task<IEnumerable<UnitDto>> GetByResidenceIdAsync(Guid residenceId, Guid currentUserId)
    {
        var units = await _context.Units
            .Include(u => u.Building)
            .ThenInclude(b => b.Residence)
            .Include(u => u.Resident)
            .Where(u => u.Building.ResidenceId == residenceId && !u.IsDeleted)
            .ToListAsync();

        var dtos = new List<UnitDto>();
        foreach (var unit in units)
        {
            dtos.Add(await MapToDto(unit));
        }

        return dtos;
    }

    public async Task<UnitDto> UpdateAsync(Guid id, UpdateUnitDto dto, Guid currentUserId)
    {
        var unit = await _context.Units
            .FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);

        if (unit == null)
            throw new Exception("Lot introuvable");

        // Vérifier que le nouveau numéro n'existe pas déjà
        var existingUnit = await _context.Units
            .AnyAsync(u => u.BuildingId == unit.BuildingId && 
                          u.UnitNumber == dto.UnitNumber && 
                          u.Id != id && 
                          !u.IsDeleted);

        if (existingUnit)
            throw new Exception($"Le lot {dto.UnitNumber} existe déjà dans cet immeuble");

        unit.UnitNumber = dto.UnitNumber;
        unit.Type = dto.Type;
        unit.Floor = dto.Floor;
        unit.Surface = dto.Surface;
        unit.Shares = dto.Shares;
        unit.ResidentId = dto.ResidentId;
        unit.UpdatedAt = DateTime.UtcNow;
        unit.UpdatedBy = currentUserId;

        await _context.SaveChangesAsync();

        return await MapToDto(unit);
    }

    public async Task<bool> DeleteAsync(Guid id, Guid currentUserId)
    {
        var unit = await _context.Units
            .FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);

        if (unit == null)
            return false;

        // Suppression logique
        unit.IsDeleted = true;
        unit.UpdatedAt = DateTime.UtcNow;
        unit.UpdatedBy = currentUserId;

        await _context.SaveChangesAsync();

        return true;
    }

    private async Task<UnitDto> MapToDto(Domain.Entities.Unit unit)
    {
        // Charger les relations si elles ne sont pas déjà chargées
        if (unit.Building == null)
        {
            await _context.Entry(unit)
                .Reference(u => u.Building)
                .Query()
                .Include(b => b.Residence)
                .LoadAsync();
        }
        else if (unit.Building.Residence == null)
        {
            await _context.Entry(unit.Building)
                .Reference(b => b.Residence)
                .LoadAsync();
        }

        if (unit.ResidentId.HasValue && unit.Resident == null)
        {
            await _context.Entry(unit)
                .Reference(u => u.Resident)
                .LoadAsync();
        }

        return new UnitDto
        {
            Id = unit.Id,
            UnitNumber = unit.UnitNumber,
            Type = unit.Type,
            TypeDisplay = unit.Type.ToString(),
            Floor = unit.Floor,
            Surface = unit.Surface,
            Shares = unit.Shares,
            BuildingId = unit.BuildingId,
            BuildingName = unit.Building?.Name,
            ResidenceId = unit.Building?.ResidenceId ?? Guid.Empty,
            ResidenceName = unit.Building?.Residence?.Name,
            ResidentId = unit.ResidentId,
            ResidentName = unit.Resident != null 
                ? $"{unit.Resident.FirstName} {unit.Resident.LastName}" 
                : null,
            CreatedAt = unit.CreatedAt,
            UpdatedAt = unit.UpdatedAt
        };
    }
}
