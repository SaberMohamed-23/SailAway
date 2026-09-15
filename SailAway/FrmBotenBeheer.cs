namespace SailAway;

public partial class FrmBotenBeheer : Form
{
    public FrmBotenBeheer()
    {
        InitializeComponent();
        Load += FrmBotenBeheer_Load;
        btnToevoegen.Click += BtnToevoegen_Click;
        btnBewerken.Click += BtnBewerken_Click;
        btnVerwijderen.Click += BtnVerwijderen_Click;
    }

    // Designer compatibility
    private void btnToevoegen_Click(object? s, EventArgs e) => BtnToevoegen_Click(s, e);
    private void btnBewerken_Click(object? s, EventArgs e) => BtnBewerken_Click(s, e);
    private void btnVerwijderen_Click(object? s, EventArgs e) => BtnVerwijderen_Click(s, e);

    private void FrmBotenBeheer_Load(object? sender, EventArgs e)
    {
        LoadBoten();
    }

    private void BtnToevoegen_Click(object? s, EventArgs e)
    {
        new FrmBootToevoegen().ShowDialog();
        LoadBoten();
    }

    private void BtnBewerken_Click(object? s, EventArgs e)
    {
        if (dgv.SelectedRows.Count == 0) { MessageBox.Show("Selecteer eerst een boot.", "Bewerken", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        var row = dgv.SelectedRows[0];
        if (!(row.Tag is int id) || id <= 0) { MessageBox.Show("Onbekende boot geselecteerd.", "Bewerken", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        new FrmBootBewerken(id).ShowDialog();
        LoadBoten();
    }

    private void BtnVerwijderen_Click(object? s, EventArgs e)
    {
        if (dgv.SelectedRows.Count == 0) { MessageBox.Show("Selecteer eerst een boot.", "Verwijderen", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        var row = dgv.SelectedRows[0];
        if (!(row.Tag is int id) || id <= 0) { MessageBox.Show("Onbekende boot geselecteerd.", "Verwijderen", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        var ok = MessageBox.Show("Weet u zeker dat u deze boot wilt verwijderen?", "Boot verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (ok != DialogResult.Yes) return;
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection(); conn.Open();
            using var cmd = conn.CreateCommand(); cmd.CommandText = "DELETE FROM boten WHERE boot_id = @id"; cmd.Parameters.AddWithValue("@id", id); cmd.ExecuteNonQuery();
            LoadBoten();
        }
        catch (Exception ex) { MessageBox.Show("Fout bij verwijderen boot: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }

    private void LoadBoten()
    {
        dgv.Rows.Clear();
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection(); conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT b.boot_id, b.naam, b.merk, bs.naam AS bootsoort, b.capaciteit, b.bouwjaar, b.lengte, l.naam AS locatie, b.prijs_per_uur
FROM boten b
JOIN bootsoorten bs ON b.bootsoort_id = bs.bootsoort_id
JOIN locaties l ON b.locatie_id = l.locatie_id
ORDER BY b.naam";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var r = new DataGridViewRow(); r.CreateCells(dgv);
                r.Cells[0].Value = reader.GetString(reader.GetOrdinal("naam"));
                r.Cells[1].Value = reader.IsDBNull(reader.GetOrdinal("merk")) ? string.Empty : reader.GetString(reader.GetOrdinal("merk"));
                r.Cells[2].Value = reader.GetString(reader.GetOrdinal("bootsoort"));
                r.Cells[3].Value = reader.GetInt32(reader.GetOrdinal("capaciteit"));
                r.Cells[4].Value = reader.IsDBNull(reader.GetOrdinal("bouwjaar")) ? string.Empty : reader.GetString(reader.GetOrdinal("bouwjaar"));
                r.Cells[5].Value = reader.IsDBNull(reader.GetOrdinal("lengte")) ? string.Empty : reader.GetString(reader.GetOrdinal("lengte"));
                r.Cells[6].Value = reader.GetString(reader.GetOrdinal("locatie"));
                r.Cells[7].Value = reader.IsDBNull(reader.GetOrdinal("prijs_per_uur")) ? string.Empty : reader.GetDecimal(reader.GetOrdinal("prijs_per_uur")).ToString("C");
                r.Tag = reader.GetInt32(reader.GetOrdinal("boot_id"));
                dgv.Rows.Add(r);
            }
        }
        catch (Exception ex) { MessageBox.Show("Fout bij laden boten: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }
}
