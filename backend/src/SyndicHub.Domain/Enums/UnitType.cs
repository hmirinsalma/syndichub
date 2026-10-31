namespace SyndicHub.Domain.Enums;

/// <summary>
/// Type de lot (appartement, local commercial, parking, cave)
/// </summary>
public enum UnitType
{
    /// <summary>
    /// Appartement résidentiel
    /// </summary>
    Apartment = 1,

    /// <summary>
    /// Local commercial (boutique, bureau)
    /// </summary>
    Commercial = 2,

    /// <summary>
    /// Place de parking
    /// </summary>
    Parking = 3,

    /// <summary>
    /// Cave ou débarras
    /// </summary>
    Storage = 4,

    /// <summary>
    /// Autre type de lot
    /// </summary>
    Other = 5
}
