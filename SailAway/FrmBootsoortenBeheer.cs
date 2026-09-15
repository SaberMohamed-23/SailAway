namespace SailAway;

public partial class FrmBootsoortenBeheer : Form
{
    public FrmBootsoortenBeheer()
    {
        InitializeComponent();
        Load += FrmBootsoortenBeheer_Load;
        btnToevoegen.Click += BtnToevoegen_Click;
        btnBewerken.Click += BtnBewerken_Click;
        btnVerwijderen.Click += BtnVerwijderen_Click;
    }

    private void FrmBootsoortenBeheer_Load(object? sender, EventArgs e)
    {
        LoadBootsoorten();
    }

    private void BtnToevoegen_Click(object? s, EventArgs e)
    {
        new FrmBootsoortToevoegen().ShowDialog();
        LoadBootsoorten();
    }

    private void BtnBewerken_Click(object? s, EventArgs e)
    {
        if (dgv.SelectedRows.Count == 0) { MessageBox.Show("Selecteer eerst een bootsoort.", "Bewerken", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        var row = dgv.SelectedRows[0];
        if (!(row.Tag is int id) || id <= 0) { MessageBox.Show("Onbekende bootsoort geselecteerd.", "Bewerken", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        new FrmBootsoortBewerken(id).ShowDialog();
        LoadBootsoorten();
    }

    private void BtnVerwijderen_Click(object? s, EventArgs e)
    {
        if (dgv.SelectedRows.Count == 0) { MessageBox.Show("Selecteer eerst een bootsoort.", "Verwijderen", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        var row = dgv.SelectedRows[0];
        if (!(row.Tag is int id) || id <= 0) { MessageBox.Show("Onbekende bootsoort geselecteerd.", "Verwijderen", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        var ok = MessageBox.Show("Weet u zeker dat u deze bootsoort wilt verwijderen?", "Bootsoort verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (ok != DialogResult.Yes) return;
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection(); conn.Open();
            using var cmd = conn.CreateCommand(); cmd.CommandText = "DELETE FROM bootsoorten WHERE bootsoort_id = @id"; cmd.Parameters.AddWithValue("@id", id); cmd.ExecuteNonQuery();
            LoadBootsoorten();
        }
        catch (Exception ex) { MessageBox.Show("Fout bij verwijderen bootsoort: " + ex.Message); }
    }

    private void LoadBootsoorten()
    {
        dgv.Rows.Clear();
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection(); conn.Open();
            using var cmd = conn.CreateCommand(); cmd.CommandText = "SELECT bootsoort_id, naam, beschrijving FROM bootsoorten ORDER BY naam";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var r = new DataGridViewRow(); r.CreateCells(dgv);
                r.Cells[0].Value = reader.GetString("naam");
                r.Cells[1].Value = reader.IsDBNull(reader.GetOrdinal("beschrijving")) ? string.Empty : reader.GetString("beschrijving");
                r.Tag = reader.GetInt32("bootsoort_id");
                dgv.Rows.Add(r);
            }
        }
        catch (Exception ex) { MessageBox.Show("Fout bij laden bootsoorten: " + ex.Message); }
    }

}
