namespace SyndicHub.Domain.Entities;

/// <summary>
/// Représente un immeuble dans une résidence
/// </summary>
public class Building
{
    public Guid Id { get; set; }
    
    public Guid ResidenceId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public int FloorCount { get; set; }
    
    public bool IsDeleted { get; set; } = false;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public Residence Residence { get; set; } = null!;
    public ICollection<Unit> Units { get; set; } = new List<Unit>();
}
