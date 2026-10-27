namespace SyndicHub.Domain.Entities;

/// <summary>
/// Représente un lot (appartement, local, parking) dans un immeuble
/// </summary>
public class Unit
{
    public Guid Id { get; set; }
    
    public Guid BuildingId { get; set; }
    
    /// <summary>
    /// Numéro ou nom du lot (ex: "A12", "Parking 5")
    /// </summary>
    public string Number { get; set; } = string.Empty;
    
    /// <summary>
    /// Type: APARTMENT, SHOP, PARKING, STORAGE
    /// </summary>
    public string Type { get; set; } = string.Empty;
    
    public int Floor { get; set; }
    
    /// <summary>
    /// Surface en m²
    /// </summary>
    public decimal Area { get; set; }
    
    /// <summary>
    /// Nombre de tantièmes du lot
    /// </summary>
    public int Shares { get; set; }
    
    /// <summary>
    /// ID du résident propriétaire/locataire (peut être null si vacant)
    /// </summary>
    public Guid? ResidentId { get; set; }
    
    /// <summary>
    /// Solde actuel du lot (positif = crédit, négatif = dette)
    /// </summary>
    public decimal Balance { get; set; } = 0;
    
    public bool IsDeleted { get; set; } = false;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public Building Building { get; set; } = null!;
    public User? Resident { get; set; }
}
