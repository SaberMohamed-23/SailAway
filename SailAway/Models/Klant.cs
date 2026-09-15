namespace SailAway.Models;

public class Klant
{
    public int? GebruikerId { get; set; }
    public int KlantId { get; set; }
    public string Voornaam { get; set; } = string.Empty;
    public string? Tussenvoegsel { get; set; }
    public string Achternaam { get; set; } = string.Empty;
    public DateTime Geboortedatum { get; set; }
    public string Telefoonnummer { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string VolledigeNaam
    {
        get
        {
            if (string.IsNullOrWhiteSpace(Tussenvoegsel))
                return $"{Voornaam} {Achternaam}";

            return $"{Voornaam} {Tussenvoegsel} {Achternaam}";
        }
    }

    public override string ToString() => VolledigeNaam;
}
