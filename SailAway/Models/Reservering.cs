namespace SailAway.Models;

public class Reservering
{
    public int ReserveringId { get; set; }
    public int KlantId { get; set; }
    public int BootId { get; set; }
    public int LocatieId { get; set; }
    public DateTime Datum { get; set; }
    public TimeSpan Begintijd { get; set; }
    public TimeSpan Eindtijd { get; set; }
    public int AantalPersonen { get; set; }
    public string Status { get; set; } = "Actief";
}
