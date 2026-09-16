namespace SailAway;

public partial class FrmMijnReserveringen : Form
{
    public FrmMijnReserveringen()
    {
        InitializeComponent();
        // Ensure the Load event handler is subscribed in case the designer did not wire it up
        this.Load += FrmMijnReserveringen_Load;
    }

    private void FrmMijnReserveringen_Load(object? sender, EventArgs e)
    {
        // load only reservations for logged-in klant
        LoadReserveringen();
    }

    private void LoadReserveringen()
    {
        dgv.Rows.Clear();
        if (!Session.IsIngelogd || Session.KlantId <= 0)
        {
            MessageBox.Show("Je bent niet ingelogd. Log in om je reserveringen te bekijken.", "Inloggen vereist", MessageBoxButtons.OK, MessageBoxIcon.Information);
            using var f = new FrmInloggen();
            f.ShowDialog();
            if (!Session.IsIngelogd) return;
        }

        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT r.reservering_id, b.naam AS bootnaam, l.naam AS locatie, r.datum, r.begintijd, r.eindtijd, r.aantal_personen, r.status
                                FROM reserveringen r
                                JOIN boten b ON r.boot_id = b.boot_id
                                JOIN locaties l ON b.locatie_id = l.locatie_id
                                WHERE r.klant_id = @klant_id
                                ORDER BY r.datum, r.begintijd";
            cmd.Parameters.AddWithValue("@klant_id", Session.KlantId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var row = new object[]
                {
                    reader.GetString("bootnaam"),
                    reader.GetString("locatie"),
                    reader.GetDateTime("datum").ToString("dd-MM-yyyy"),
                    reader.GetTimeSpan("begintijd").ToString(),
                    reader.GetTimeSpan("eindtijd").ToString(),
                    reader.GetString("status")
                };
                var r = dgv.Rows.Add(row);
                dgv.Rows[r].Tag = reader.GetInt32("reservering_id");
            }
        }
        catch (Exception ex) { MessageBox.Show("Fout bij laden reserveringen: " + ex.Message); }
    }

    private void btnWijzigen_Click(object? s, EventArgs e)
    {
        if (dgv.SelectedRows.Count == 0) { MessageBox.Show("Selecteer een reservering om te wijzigen.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        var id = dgv.SelectedRows[0].Tag as int?;
        if (id == null) return;
        using var f = new FrmReserveringBewerken(id.Value);
        f.ShowDialog();
        LoadReserveringen();
    }

    private void btnAnnulerenRes_Click(object? s, EventArgs e)
    {
        if (dgv.SelectedRows.Count == 0) { MessageBox.Show("Selecteer een reservering om te annuleren.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        var id = dgv.SelectedRows[0].Tag as int?;
        if (id == null) return;
        if (MessageBox.Show("Weet je zeker dat je deze reservering wilt annuleren?", "Bevestigen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE reserveringen SET status='Geannuleerd' WHERE reservering_id=@id";
            cmd.Parameters.AddWithValue("@id", id.Value);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Reservering geannuleerd.", "Klaar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadReserveringen();
        }
        catch (Exception ex) { MessageBox.Show("Fout bij annuleren: " + ex.Message); }
    }

    private void btnTerug_Click(object? s, EventArgs e) => Close();

}
