using Microsoft.AspNetCore.Mvc;
using SyndicHub.Application.DTOs.Auth;
using SyndicHub.Application.Interfaces;
using SyndicHub.Shared.Models;

namespace SyndicHub.API.Controllers;

/// <summary>
/// Contrôleur pour l'authentification (inscription, connexion)
/// </summary>
[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    /// <summary>
    /// Inscription d'un nouvel utilisateur
    /// </summary>
    [HttpPost("register")]
    public async Task<ActionResult<ApiResponse<AuthResponse>>> Register([FromBody] RegisterRequest request)
    {
        try
        {
            var result = await _authService.RegisterAsync(request);
            
            _logger.LogInformation("Nouvel utilisateur inscrit: {Email}", request.Email);
            
            return Ok(new ApiResponse<AuthResponse>
            {
                Success = true,
                Message = "Inscription réussie",
                Data = result,
                StatusCode = 200,
                Timestamp = DateTime.UtcNow
            });
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning("Échec d'inscription: {Message}", ex.Message);
            
            return BadRequest(new ApiResponse<AuthResponse>
            {
                Success = false,
                Message = ex.Message,
                Errors = new List<string> { ex.Message },
                StatusCode = 400,
                Timestamp = DateTime.UtcNow
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de l'inscription");
            
            return StatusCode(500, new ApiResponse<AuthResponse>
            {
                Success = false,
                Message = "Une erreur est survenue lors de l'inscription",
                Errors = new List<string> { ex.Message },
                StatusCode = 500,
                Timestamp = DateTime.UtcNow
            });
        }
    }

    /// <summary>
    /// Connexion d'un utilisateur existant
    /// </summary>
    [HttpPost("login")]
    public async Task<ActionResult<ApiResponse<AuthResponse>>> Login([FromBody] LoginRequest request)
    {
        try
        {
            var result = await _authService.LoginAsync(request);
            
            _logger.LogInformation("Utilisateur connecté: {Email}", request.Email);
            
            return Ok(new ApiResponse<AuthResponse>
            {
                Success = true,
                Message = "Connexion réussie",
                Data = result,
                StatusCode = 200,
                Timestamp = DateTime.UtcNow
            });
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogWarning("Échec de connexion pour: {Email}", request.Email);
            
            return Unauthorized(new ApiResponse<AuthResponse>
            {
                Success = false,
                Message = ex.Message,
                Errors = new List<string> { ex.Message },
                StatusCode = 401,
                Timestamp = DateTime.UtcNow
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de la connexion");
            
            return StatusCode(500, new ApiResponse<AuthResponse>
            {
                Success = false,
                Message = "Une erreur est survenue lors de la connexion",
                Errors = new List<string> { ex.Message },
                StatusCode = 500,
                Timestamp = DateTime.UtcNow
            });
        }
    }
}
