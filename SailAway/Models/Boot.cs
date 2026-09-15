namespace SailAway.Models;

public class Boot
{
    public int BootId { get; set; }
    public string Naam { get; set; } = string.Empty;
    public string Merk { get; set; } = string.Empty;
    public int BootsoortId { get; set; }
    public int Capaciteit { get; set; }
    public int Bouwjaar { get; set; }
    public decimal Lengte { get; set; }
    public string? Omschrijving { get; set; }
    public decimal PrijsPerUur { get; set; }
    public int LocatieId { get; set; }

    public override string ToString() => Naam;
}
