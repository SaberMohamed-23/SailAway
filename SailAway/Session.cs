namespace SailAway;

// Very small beginner-friendly session holder
public static class Session
{
    public static int GebruikerId { get; set; }
    public static int KlantId { get; set; }
    public static string Rol { get; set; } = string.Empty;
    public static bool IsIngelogd { get; set; }
}
