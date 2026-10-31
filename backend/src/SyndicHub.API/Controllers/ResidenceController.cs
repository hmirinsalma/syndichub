using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SyndicHub.Application.DTOs.Residence;
using SyndicHub.Application.Interfaces;
using SyndicHub.Shared.Models;

namespace SyndicHub.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize(Roles = "ADMIN,SYNDIC")]
public class ResidenceController : ControllerBase
{
    private readonly IResidenceService _residenceService;

    public ResidenceController(IResidenceService residenceService)
    {
        _residenceService = residenceService;
    }

    /// <summary>
    /// Créer une nouvelle résidence
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ApiResponse<ResidenceDto>>> Create([FromBody] CreateResidenceDto dto)
    {
        try
        {
            var currentUserId = GetCurrentUserId();
            var residence = await _residenceService.CreateAsync(dto, currentUserId);

            return Ok(new ApiResponse<ResidenceDto>
            {
                Success = true,
                Message = "Résidence créée avec succès",
                Data = residence,
                StatusCode = 201
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<ResidenceDto>
            {
                Success = false,
                Message = "Erreur lors de la création de la résidence",
                Errors = new List<string> { ex.Message },
                StatusCode = 400
            });
        }
    }

    /// <summary>
    /// Obtenir toutes les résidences
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ResidenceDto>>>> GetAll()
    {
        try
        {
            var currentUserId = GetCurrentUserId();
            var isAdmin = User.IsInRole("ADMIN");
            
            var residences = await _residenceService.GetAllAsync(currentUserId, isAdmin);

            return Ok(new ApiResponse<IEnumerable<ResidenceDto>>
            {
                Success = true,
                Message = $"{residences.Count()} résidence(s) trouvée(s)",
                Data = residences,
                StatusCode = 200
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<IEnumerable<ResidenceDto>>
            {
                Success = false,
                Message = "Erreur lors de la récupération des résidences",
                Errors = new List<string> { ex.Message },
                StatusCode = 400
            });
        }
    }

    /// <summary>
    /// Obtenir une résidence par ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<ResidenceDto>>> GetById(Guid id)
    {
        try
        {
            var currentUserId = GetCurrentUserId();
            var residence = await _residenceService.GetByIdAsync(id, currentUserId);

            if (residence == null)
            {
                return NotFound(new ApiResponse<ResidenceDto>
                {
                    Success = false,
                    Message = "Résidence introuvable",
                    StatusCode = 404
                });
            }

            return Ok(new ApiResponse<ResidenceDto>
            {
                Success = true,
                Message = "Résidence trouvée",
                Data = residence,
                StatusCode = 200
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<ResidenceDto>
            {
                Success = false,
                Message = "Erreur lors de la récupération de la résidence",
                Errors = new List<string> { ex.Message },
                StatusCode = 400
            });
        }
    }

    /// <summary>
    /// Mettre à jour une résidence
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<ResidenceDto>>> Update(Guid id, [FromBody] UpdateResidenceDto dto)
    {
        try
        {
            var currentUserId = GetCurrentUserId();
            var residence = await _residenceService.UpdateAsync(id, dto, currentUserId);

            return Ok(new ApiResponse<ResidenceDto>
            {
                Success = true,
                Message = "Résidence mise à jour avec succès",
                Data = residence,
                StatusCode = 200
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<ResidenceDto>
            {
                Success = false,
                Message = "Erreur lors de la mise à jour de la résidence",
                Errors = new List<string> { ex.Message },
                StatusCode = 400
            });
        }
    }

    /// <summary>
    /// Supprimer une résidence
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
    {
        try
        {
            var currentUserId = GetCurrentUserId();
            var deleted = await _residenceService.DeleteAsync(id, currentUserId);

            if (!deleted)
            {
                return NotFound(new ApiResponse<bool>
                {
                    Success = false,
                    Message = "Résidence introuvable",
                    StatusCode = 404
                });
            }

            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Message = "Résidence supprimée avec succès",
                Data = true,
                StatusCode = 200
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<bool>
            {
                Success = false,
                Message = "Erreur lors de la suppression de la résidence",
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
