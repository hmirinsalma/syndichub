using Microsoft.EntityFrameworkCore;
using SyndicHub.Application.DTOs.Residence;
using SyndicHub.Application.Interfaces;
using SyndicHub.Domain.Entities;
using SyndicHub.Infrastructure.Data;

namespace SyndicHub.Infrastructure.Services;

/// <summary>
/// Service métier pour gérer les résidences
/// </summary>
public class ResidenceService : IResidenceService
{
    private readonly ApplicationDbContext _context;

    public ResidenceService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResidenceDto> CreateAsync(CreateResidenceDto dto, Guid currentUserId)
    {
        // Si SyndicId non fourni, utiliser l'utilisateur connecté
        var syndicId = dto.SyndicId ?? currentUserId;

        // Vérifier que le syndic existe
        var syndic = await _context.Users.FindAsync(syndicId);
        if (syndic == null)
            throw new Exception("Syndic introuvable");

        var residence = new Residence
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Address = dto.Address,
            City = dto.City,
            PostalCode = dto.PostalCode,
            Phone = dto.Phone,
            Email = dto.Email,
            SyndicId = syndicId,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = currentUserId
        };

        _context.Residences.Add(residence);
        await _context.SaveChangesAsync();

        return await MapToDto(residence);
    }

    public async Task<ResidenceDto?> GetByIdAsync(Guid id, Guid currentUserId)
    {
        var residence = await _context.Residences
            .Include(r => r.Syndic)
            .Include(r => r.Buildings)
            .ThenInclude(b => b.Units)
            .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);

        if (residence == null)
            return null;

        return await MapToDto(residence);
    }

    public async Task<IEnumerable<ResidenceDto>> GetAllAsync(Guid currentUserId, bool isAdmin)
    {
        var query = _context.Residences
            .Include(r => r.Syndic)
            .Include(r => r.Buildings)
            .ThenInclude(b => b.Units)
            .Where(r => !r.IsDeleted);

        // Si pas ADMIN, filtrer par syndic
        if (!isAdmin)
        {
            query = query.Where(r => r.SyndicId == currentUserId);
        }

        var residences = await query.ToListAsync();

        var dtos = new List<ResidenceDto>();
        foreach (var residence in residences)
        {
            dtos.Add(await MapToDto(residence));
        }

        return dtos;
    }

    public async Task<ResidenceDto> UpdateAsync(Guid id, UpdateResidenceDto dto, Guid currentUserId)
    {
        var residence = await _context.Residences
            .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);

        if (residence == null)
            throw new Exception("Résidence introuvable");

        residence.Name = dto.Name;
        residence.Address = dto.Address;
        residence.City = dto.City;
        residence.PostalCode = dto.PostalCode;
        residence.Phone = dto.Phone;
        residence.Email = dto.Email;
        residence.UpdatedAt = DateTime.UtcNow;
        residence.UpdatedBy = currentUserId;

        await _context.SaveChangesAsync();

        return await MapToDto(residence);
    }

    public async Task<bool> DeleteAsync(Guid id, Guid currentUserId)
    {
        var residence = await _context.Residences
            .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);

        if (residence == null)
            return false;

        // Suppression logique
        residence.IsDeleted = true;
        residence.UpdatedAt = DateTime.UtcNow;
        residence.UpdatedBy = currentUserId;

        await _context.SaveChangesAsync();

        return true;
    }

    private async Task<ResidenceDto> MapToDto(Residence residence)
    {
        var buildingsCount = await _context.Buildings
            .CountAsync(b => b.ResidenceId == residence.Id && !b.IsDeleted);

        var unitsCount = await _context.Units
            .Include(u => u.Building)
            .CountAsync(u => u.Building.ResidenceId == residence.Id && !u.IsDeleted);

        return new ResidenceDto
        {
            Id = residence.Id,
            Name = residence.Name,
            Address = residence.Address,
            City = residence.City,
            PostalCode = residence.PostalCode,
            Phone = residence.Phone,
            Email = residence.Email,
            SyndicId = residence.SyndicId,
            SyndicName = residence.Syndic != null 
                ? $"{residence.Syndic.FirstName} {residence.Syndic.LastName}" 
                : null,
            BuildingsCount = buildingsCount,
            UnitsCount = unitsCount,
            CreatedAt = residence.CreatedAt,
            UpdatedAt = residence.UpdatedAt
        };
    }
}
