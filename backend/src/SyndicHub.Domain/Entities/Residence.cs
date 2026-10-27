namespace SyndicHub.Domain.Entities;

/// <summary>
/// Représente une résidence (copropriété)
/// </summary>
public class Residence
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Address { get; set; } = string.Empty;
    
    public string City { get; set; } = string.Empty;
    
    public string PostalCode { get; set; } = string.Empty;
    
    /// <summary>
    /// Nombre total de tantièmes de la résidence
    /// </summary>
    public int TotalShares { get; set; }
    
    /// <summary>
    /// Solde actuel de la caisse de la résidence (en MAD)
    /// </summary>
    public decimal CurrentBalance { get; set; } = 0;
    
    public bool IsDeleted { get; set; } = false;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public Guid CreatedBy { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public ICollection<Building> Buildings { get; set; } = new List<Building>();
    public ICollection<User> Users { get; set; } = new List<User>();
}
