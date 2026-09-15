namespace SailAway.Models;

public class Gebruiker
{
    public int GebruikerId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Wachtwoord { get; set; } = string.Empty;
    public string Rol { get; set; } = "Klant"; // 'Klant','Medewerker','Beheerder','Leidinggevende'
    public bool Actief { get; set; } = true;

    public override string ToString() => Email;
}
