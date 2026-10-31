using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SyndicHub.Application.DTOs.Building;
using SyndicHub.Application.Interfaces;
using SyndicHub.Shared.Models;

namespace SyndicHub.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize(Roles = "ADMIN,SYNDIC")]
public class BuildingController : ControllerBase
{
    private readonly IBuildingService _buildingService;

    public BuildingController(IBuildingService buildingService)
    {
        _buildingService = buildingService;
    }

    /// <summary>
    /// Créer un nouvel immeuble
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ApiResponse<BuildingDto>>> Create([FromBody] CreateBuildingDto dto)
    {
        try
        {
            var currentUserId = GetCurrentUserId();
            var building = await _buildingService.CreateAsync(dto, currentUserId);

            return Ok(new ApiResponse<BuildingDto>
            {
                Success = true,
                Message = "Immeuble créé avec succès",
                Data = building,
                StatusCode = 201
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<BuildingDto>
            {
                Success = false,
                Message = "Erreur lors de la création de l'immeuble",
                Errors = new List<string> { ex.Message },
                StatusCode = 400
            });
        }
    }

    /// <summary>
    /// Obtenir tous les immeubles d'une résidence
    /// </summary>
    [HttpGet("residence/{residenceId}")]
    public async Task<ActionResult<ApiResponse<IEnumerable<BuildingDto>>>> GetByResidenceId(Guid residenceId)
    {
        try
        {
            var currentUserId = GetCurrentUserId();
            var buildings = await _buildingService.GetByResidenceIdAsync(residenceId, currentUserId);

            return Ok(new ApiResponse<IEnumerable<BuildingDto>>
            {
                Success = true,
                Message = $"{buildings.Count()} immeuble(s) trouvé(s)",
                Data = buildings,
                StatusCode = 200
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<IEnumerable<BuildingDto>>
            {
                Success = false,
                Message = "Erreur lors de la récupération des immeubles",
                Errors = new List<string> { ex.Message },
                StatusCode = 400
            });
        }
    }

    /// <summary>
    /// Obtenir un immeuble par ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<BuildingDto>>> GetById(Guid id)
    {
        try
        {
            var currentUserId = GetCurrentUserId();
            var building = await _buildingService.GetByIdAsync(id, currentUserId);

            if (building == null)
            {
                return NotFound(new ApiResponse<BuildingDto>
                {
                    Success = false,
                    Message = "Immeuble introuvable",
                    StatusCode = 404
                });
            }

            return Ok(new ApiResponse<BuildingDto>
            {
                Success = true,
                Message = "Immeuble trouvé",
                Data = building,
                StatusCode = 200
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<BuildingDto>
            {
                Success = false,
                Message = "Erreur lors de la récupération de l'immeuble",
                Errors = new List<string> { ex.Message },
                StatusCode = 400
            });
        }
    }

    /// <summary>
    /// Mettre à jour un immeuble
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<BuildingDto>>> Update(Guid id, [FromBody] UpdateBuildingDto dto)
    {
        try
        {
            var currentUserId = GetCurrentUserId();
            var building = await _buildingService.UpdateAsync(id, dto, currentUserId);

            return Ok(new ApiResponse<BuildingDto>
            {
                Success = true,
                Message = "Immeuble mis à jour avec succès",
                Data = building,
                StatusCode = 200
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<BuildingDto>
            {
                Success = false,
                Message = "Erreur lors de la mise à jour de l'immeuble",
                Errors = new List<string> { ex.Message },
                StatusCode = 400
            });
        }
    }

    /// <summary>
    /// Supprimer un immeuble
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
    {
        try
        {
            var currentUserId = GetCurrentUserId();
            var deleted = await _buildingService.DeleteAsync(id, currentUserId);

            if (!deleted)
            {
                return NotFound(new ApiResponse<bool>
                {
                    Success = false,
                    Message = "Immeuble introuvable",
                    StatusCode = 404
                });
            }

            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Message = "Immeuble supprimé avec succès",
                Data = true,
                StatusCode = 200
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<bool>
            {
                Success = false,
                Message = "Erreur lors de la suppression de l'immeuble",
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
