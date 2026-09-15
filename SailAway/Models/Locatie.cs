namespace SailAway.Models;

public class Locatie
{
    public int LocatieId { get; set; }
    public string Naam { get; set; } = string.Empty;
    public string Adres { get; set; } = string.Empty;
    public string? Beschrijving { get; set; }

    public override string ToString() => Naam;
}
