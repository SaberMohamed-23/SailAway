namespace SailAway;

public partial class FrmLocatiesBeheer : Form
{
    public FrmLocatiesBeheer()
    {
        InitializeComponent();
        Load += FrmLocatiesBeheer_Load;
        btnToevoegen.Click += BtnToevoegen_Click;
        btnBewerken.Click += BtnBewerken_Click;
        btnVerwijderen.Click += BtnVerwijderen_Click;
    }

    private void FrmLocatiesBeheer_Load(object? sender, EventArgs e) => LoadLocaties();

    private void BtnToevoegen_Click(object? s, EventArgs e) { new FrmLocatieToevoegen().ShowDialog(); LoadLocaties(); }

    private void BtnBewerken_Click(object? s, EventArgs e)
    {
        if (dgv.SelectedRows.Count == 0) { MessageBox.Show("Selecteer eerst een locatie.", "Bewerken", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        var row = dgv.SelectedRows[0]; if (!(row.Tag is int id) || id <= 0) { MessageBox.Show("Onbekende locatie geselecteerd.", "Bewerken", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        new FrmLocatieBewerken(id).ShowDialog(); LoadLocaties();
    }

    private void BtnVerwijderen_Click(object? s, EventArgs e)
    {
        if (dgv.SelectedRows.Count == 0) { MessageBox.Show("Selecteer eerst een locatie.", "Verwijderen", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        var row = dgv.SelectedRows[0]; if (!(row.Tag is int id) || id <= 0) { MessageBox.Show("Onbekende locatie geselecteerd.", "Verwijderen", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        var ok = MessageBox.Show("Weet u zeker dat u deze locatie wilt verwijderen?", "Locatie verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); if (ok != DialogResult.Yes) return;
        try { using var conn = Database.DatabaseConnection.GetConnection(); conn.Open(); using var cmd = conn.CreateCommand(); cmd.CommandText = "DELETE FROM locaties WHERE locatie_id = @id"; cmd.Parameters.AddWithValue("@id", id); cmd.ExecuteNonQuery(); LoadLocaties(); }
        catch (Exception ex) { MessageBox.Show("Fout bij verwijderen locatie: " + ex.Message); }
    }

    private void LoadLocaties()
    {
        dgv.Rows.Clear();
        try { using var conn = Database.DatabaseConnection.GetConnection(); conn.Open(); using var cmd = conn.CreateCommand(); cmd.CommandText = "SELECT locatie_id, naam, adres, beschrijving FROM locaties ORDER BY naam"; using var r = cmd.ExecuteReader(); while (r.Read()) { var row = new DataGridViewRow(); row.CreateCells(dgv); row.Cells[0].Value = r.GetString("naam"); row.Cells[1].Value = r.IsDBNull(r.GetOrdinal("adres")) ? string.Empty : r.GetString("adres"); row.Cells[2].Value = r.IsDBNull(r.GetOrdinal("beschrijving")) ? string.Empty : r.GetString("beschrijving"); row.Tag = r.GetInt32("locatie_id"); dgv.Rows.Add(row); } }
        catch (Exception ex) { MessageBox.Show("Fout bij laden locaties: " + ex.Message); }
    }

}
