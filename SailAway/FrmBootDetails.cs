namespace SailAway;

public partial class FrmBootDetails : Form
{
    private int _bootId;
    public FrmBootDetails()
    {
        InitializeComponent();
    }

    public FrmBootDetails(int bootId) : this()
    {
        _bootId = bootId;
        Load += FrmBootDetails_Load;
    }

    private void btnReserveren_Click(object? sender, EventArgs e) => new FrmReserveringMaken().ShowDialog();

    private void btnTerug_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void FrmBootDetails_Load(object? sender, EventArgs e)
    {
        if (_bootId <= 0) return;
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection(); conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT b.naam, bs.naam AS bootsoort, l.naam AS locatie, b.capaciteit, b.bouwjaar, b.lengte, b.omschrijving, b.prijs_per_uur FROM boten b JOIN bootsoorten bs ON b.bootsoort_id = bs.bootsoort_id JOIN locaties l ON b.locatie_id = l.locatie_id WHERE b.boot_id = @id LIMIT 1";
            cmd.Parameters.AddWithValue("@id", _bootId);
            using var r = cmd.ExecuteReader();
            if (r.Read())
            {
                lblTitel.Text = r.GetString("naam");
                var info = $"Type:        {r.GetString("bootsoort")}\n\nLocatie:     {r.GetString("locatie")}\n\nCapaciteit:  {r.GetInt32("capaciteit")} personen\n\nBouwjaar:    { (r.IsDBNull(r.GetOrdinal("bouwjaar")) ? string.Empty : r.GetString("bouwjaar")) }\n\nLengte:      { (r.IsDBNull(r.GetOrdinal("lengte")) ? string.Empty : r.GetString("lengte")) }\n\nPrijs:       { (r.IsDBNull(r.GetOrdinal("prijs_per_uur")) ? 0m : r.GetDecimal("prijs_per_uur")).ToString("C") } per uur";
                lblInfo.Text = info;
                txtOmschrijving.Text = r.IsDBNull(r.GetOrdinal("omschrijving")) ? string.Empty : r.GetString("omschrijving");
            }
        }
        catch (Exception ex) { MessageBox.Show("Fout bij laden boot details: " + ex.Message); }
    }

}
