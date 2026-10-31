using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SyndicHub.Application.DTOs.Unit;
using SyndicHub.Application.Interfaces;
using SyndicHub.Shared.Models;

namespace SyndicHub.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize(Roles = "ADMIN,SYNDIC")]
public class UnitController : ControllerBase
{
    private readonly IUnitService _unitService;

    public UnitController(IUnitService unitService)
    {
        _unitService = unitService;
    }

    /// <summary>
    /// Créer un nouveau lot
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ApiResponse<UnitDto>>> Create([FromBody] CreateUnitDto dto)
    {
        try
        {
            var currentUserId = GetCurrentUserId();
            var unit = await _unitService.CreateAsync(dto, currentUserId);

            return Ok(new ApiResponse<UnitDto>
            {
                Success = true,
                Message = "Lot créé avec succès",
                Data = unit,
                StatusCode = 201
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<UnitDto>
            {
                Success = false,
                Message = "Erreur lors de la création du lot",
                Errors = new List<string> { ex.Message },
                StatusCode = 400
            });
        }
    }

    /// <summary>
    /// Obtenir tous les lots d'un immeuble
    /// </summary>
    [HttpGet("building/{buildingId}")]
    public async Task<ActionResult<ApiResponse<IEnumerable<UnitDto>>>> GetByBuildingId(Guid buildingId)
    {
        try
        {
            var currentUserId = GetCurrentUserId();
            var units = await _unitService.GetByBuildingIdAsync(buildingId, currentUserId);

            return Ok(new ApiResponse<IEnumerable<UnitDto>>
            {
                Success = true,
                Message = $"{units.Count()} lot(s) trouvé(s)",
                Data = units,
                StatusCode = 200
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<IEnumerable<UnitDto>>
            {
                Success = false,
                Message = "Erreur lors de la récupération des lots",
                Errors = new List<string> { ex.Message },
                StatusCode = 400
            });
        }
    }

    /// <summary>
    /// Obtenir tous les lots d'une résidence
    /// </summary>
    [HttpGet("residence/{residenceId}")]
    public async Task<ActionResult<ApiResponse<IEnumerable<UnitDto>>>> GetByResidenceId(Guid residenceId)
    {
        try
        {
            var currentUserId = GetCurrentUserId();
            var units = await _unitService.GetByResidenceIdAsync(residenceId, currentUserId);

            return Ok(new ApiResponse<IEnumerable<UnitDto>>
            {
                Success = true,
                Message = $"{units.Count()} lot(s) trouvé(s)",
                Data = units,
                StatusCode = 200
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<IEnumerable<UnitDto>>
            {
                Success = false,
                Message = "Erreur lors de la récupération des lots",
                Errors = new List<string> { ex.Message },
                StatusCode = 400
            });
        }
    }

    /// <summary>
    /// Obtenir un lot par ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<UnitDto>>> GetById(Guid id)
    {
        try
        {
            var currentUserId = GetCurrentUserId();
            var unit = await _unitService.GetByIdAsync(id, currentUserId);

            if (unit == null)
            {
                return NotFound(new ApiResponse<UnitDto>
                {
                    Success = false,
                    Message = "Lot introuvable",
                    StatusCode = 404
                });
            }

            return Ok(new ApiResponse<UnitDto>
            {
                Success = true,
                Message = "Lot trouvé",
                Data = unit,
                StatusCode = 200
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<UnitDto>
            {
                Success = false,
                Message = "Erreur lors de la récupération du lot",
                Errors = new List<string> { ex.Message },
                StatusCode = 400
            });
        }
    }

    /// <summary>
    /// Mettre à jour un lot
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<UnitDto>>> Update(Guid id, [FromBody] UpdateUnitDto dto)
    {
        try
        {
            var currentUserId = GetCurrentUserId();
            var unit = await _unitService.UpdateAsync(id, dto, currentUserId);

            return Ok(new ApiResponse<UnitDto>
            {
                Success = true,
                Message = "Lot mis à jour avec succès",
                Data = unit,
                StatusCode = 200
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<UnitDto>
            {
                Success = false,
                Message = "Erreur lors de la mise à jour du lot",
                Errors = new List<string> { ex.Message },
                StatusCode = 400
            });
        }
    }

    /// <summary>
    /// Supprimer un lot
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
    {
        try
        {
            var currentUserId = GetCurrentUserId();
            var deleted = await _unitService.DeleteAsync(id, currentUserId);

            if (!deleted)
            {
                return NotFound(new ApiResponse<bool>
                {
                    Success = false,
                    Message = "Lot introuvable",
                    StatusCode = 404
                });
            }

            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Message = "Lot supprimé avec succès",
                Data = true,
                StatusCode = 200
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<bool>
            {
                Success = false,
                Message = "Erreur lors de la suppression du lot",
                Errors = new List<string> { ex.Message },
                StatusCode = 400
            });
        }
    }

    private Guid GetCurrentUserId()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
        {
            throw new UnauthorizedAccessException("Utilisateur non authentifié");
        }
        return userId;
    }
}
