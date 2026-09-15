namespace SailAway;

public partial class FrmKlantenBeheer : Form
{
    public FrmKlantenBeheer()
    {
        InitializeComponent();
        Load += FrmKlantenBeheer_Load;
        btnZoeken.Click += BtnZoeken_Click;
        btnToevoegen.Click += BtnToevoegen_Click;
        btnBewerken.Click += BtnBewerken_Click;
        btnVerwijderen.Click += BtnVerwijderen_Click;
        dgv.SelectionChanged += Dgv_SelectionChanged;
    }

    // Designer expects these old-named handlers; forward to new implementations
    private void btnToevoegen_Click(object? s, EventArgs e) => BtnToevoegen_Click(s, e);
    private void btnBewerken_Click(object? s, EventArgs e) => BtnBewerken_Click(s, e);
    private void btnVerwijderen_Click(object? s, EventArgs e) => BtnVerwijderen_Click(s, e);

    private void FrmKlantenBeheer_Load(object? sender, EventArgs e)
    {
        LoadKlanten();
    }

    private void BtnToevoegen_Click(object? s, EventArgs e)
    {
        new FrmKlantToevoegen().ShowDialog();
        LoadKlanten();
    }

    private void BtnZoeken_Click(object? s, EventArgs e)
    {
        LoadKlanten(txtZoeken.Text.Trim());
    }

    private void BtnVerwijderen_Click(object? s, EventArgs e)
    {
        if (dgv.SelectedRows.Count == 0) { MessageBox.Show("Selecteer eerst een klant.", "Verwijderen", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        var row = dgv.SelectedRows[0];
        if (!(row.Tag is int klantId) || klantId <= 0) { MessageBox.Show("Onbekende klant geselecteerd.", "Verwijderen", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        var ok = MessageBox.Show("Weet u zeker dat u deze klant wilt verwijderen?", "Klant verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (ok != DialogResult.Yes) return;
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection(); conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM klanten WHERE klant_id = @id"; cmd.Parameters.AddWithValue("@id", klantId);
            cmd.ExecuteNonQuery();
            LoadKlanten();
        }
        catch (Exception ex) { MessageBox.Show("Fout bij verwijderen klant: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }

    private void Dgv_SelectionChanged(object? s, EventArgs e)
    {
        if (dgv.SelectedRows.Count == 0) { dgv2.Rows.Clear(); return; }
        var row = dgv.SelectedRows[0];
        if (row.Tag is int klantId) LoadLinkedReserveringen(klantId);
        else dgv2.Rows.Clear();
    }

    private void BtnBewerken_Click(object? s, EventArgs e)
    {
        if (dgv.SelectedRows.Count == 0) { MessageBox.Show("Selecteer eerst een klant.", "Bewerken", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        var row = dgv.SelectedRows[0];
        if (!(row.Tag is int klantId) || klantId <= 0) { MessageBox.Show("Onbekende klant geselecteerd.", "Bewerken", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        new FrmKlantBewerken(klantId).ShowDialog();
        LoadKlanten();
    }

    private void LoadKlanten(string zoek = "")
    {
        dgv.Rows.Clear();
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection(); conn.Open();
            using var cmd = conn.CreateCommand();
            if (string.IsNullOrWhiteSpace(zoek))
            {
                cmd.CommandText = "SELECT klant_id, voornaam, tussenvoegsel, achternaam, geboortedatum, telefoonnummer, email FROM klanten ORDER BY achternaam";
            }
            else
            {
                var kolom = cmbZoekenOp.SelectedItem?.ToString() ?? "Achternaam";
                if (kolom == "Achternaam") cmd.CommandText = "SELECT klant_id, voornaam, tussenvoegsel, achternaam, geboortedatum, telefoonnummer, email FROM klanten WHERE achternaam LIKE @zoek ORDER BY achternaam";
                else if (kolom == "Telefoonnummer") cmd.CommandText = "SELECT klant_id, voornaam, tussenvoegsel, achternaam, geboortedatum, telefoonnummer, email FROM klanten WHERE telefoonnummer LIKE @zoek ORDER BY achternaam";
                else cmd.CommandText = "SELECT klant_id, voornaam, tussenvoegsel, achternaam, geboortedatum, telefoonnummer, email FROM klanten WHERE email LIKE @zoek ORDER BY achternaam";
                cmd.Parameters.AddWithValue("@zoek", "%" + zoek + "%");
            }
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var r = new DataGridViewRow(); r.CreateCells(dgv);
                r.Cells[0].Value = reader.GetString("voornaam");
                r.Cells[1].Value = reader.IsDBNull(reader.GetOrdinal("tussenvoegsel")) ? string.Empty : reader.GetString("tussenvoegsel");
                r.Cells[2].Value = reader.GetString("achternaam");
                var dob = reader.IsDBNull(reader.GetOrdinal("geboortedatum")) ? (DateTime?)null : reader.GetDateTime("geboortedatum");
                r.Cells[3].Value = dob?.ToString("dd-MM-yyyy") ?? string.Empty;
                r.Cells[4].Value = reader.IsDBNull(reader.GetOrdinal("telefoonnummer")) ? string.Empty : reader.GetString("telefoonnummer");
                r.Cells[5].Value = reader.IsDBNull(reader.GetOrdinal("email")) ? string.Empty : reader.GetString("email");
                r.Tag = reader.GetInt32("klant_id");
                dgv.Rows.Add(r);
            }
        }
        catch (Exception ex) { MessageBox.Show("Fout bij laden klanten: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        dgv2.Rows.Clear();
    }

    private void LoadLinkedReserveringen(int klantId)
    {
        dgv2.Rows.Clear();
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection(); conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT r.reservering_id, b.naam as bootnaam, r.datum, r.begintijd, r.eindtijd, r.status FROM reserveringen r JOIN boten b ON r.boot_id = b.boot_id WHERE r.klant_id = @klant ORDER BY r.datum DESC";
            cmd.Parameters.AddWithValue("@klant", klantId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var datum = reader.GetDateTime("datum");
                var begintijd = reader.GetTimeSpan("begintijd");
                var eindtijd = reader.GetTimeSpan("eindtijd");
                var row = new DataGridViewRow(); row.CreateCells(dgv2);
                row.Cells[0].Value = reader.GetString("bootnaam");
                row.Cells[1].Value = datum.ToString("dd-MM-yyyy");
                row.Cells[2].Value = $"{TimeSpanToTime(begintijd)} - {TimeSpanToTime(eindtijd)}";
                row.Cells[3].Value = reader.GetString("status");
                row.Tag = reader.GetInt32("reservering_id");
                dgv2.Rows.Add(row);
            }
        }
        catch (Exception ex) { MessageBox.Show("Fout bij laden gekoppelde reserveringen: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }

    private string TimeSpanToTime(TimeSpan t) => DateTime.Today.Add(t).ToString("HH:mm");
    // (removed old stub) actual delete logic implemented in BtnVerwijderen_Click above

}
