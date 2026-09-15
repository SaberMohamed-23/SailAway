namespace SailAway.Models;

public class Bootsoort
{
    public int BootsoortId { get; set; }
    public string Naam { get; set; } = string.Empty;
    public string? Beschrijving { get; set; }

    public override string ToString() => Naam;
}
