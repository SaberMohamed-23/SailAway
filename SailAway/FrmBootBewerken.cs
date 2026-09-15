namespace SailAway;

public partial class FrmBootBewerken : Form
{
    public FrmBootBewerken()
    {
        InitializeComponent();
        Load += FrmBootBewerken_Load;
        btnPrimary.Click += BtnPrimary_Click;
    }

    private void btnAnnuleren_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private int _bootId;
    public FrmBootBewerken(int bootId) : this()
    {
        _bootId = bootId;
        LoadBoot();
    }

    private void FrmBootBewerken_Load(object? sender, EventArgs e)
    {
        // load bootsoorten and locaties
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection(); conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT bootsoort_id, naam FROM bootsoorten ORDER BY naam";
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) cmbType.Items.Add(new ComboItem { Id = reader.GetInt32("bootsoort_id"), Name = reader.GetString("naam") });
            if (cmbType.Items.Count > 0) cmbType.SelectedIndex = 0;
            reader.Close();
            cmd.CommandText = "SELECT locatie_id, naam FROM locaties ORDER BY naam";
            using var reader2 = cmd.ExecuteReader();
            while (reader2.Read()) cmbLocatie.Items.Add(new ComboItem { Id = reader2.GetInt32("locatie_id"), Name = reader2.GetString("naam") });
            if (cmbLocatie.Items.Count > 0) cmbLocatie.SelectedIndex = 0;
        }
        catch (Exception ex) { MessageBox.Show("Fout bij laden selectievelden: " + ex.Message); }
    }

    private void LoadBoot()
    {
        if (_bootId <= 0) return;
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection(); conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT naam, merk, bootsoort_id, locatie_id, capaciteit, bouwjaar, lengte, omschrijving, prijs_per_uur FROM boten WHERE boot_id = @id LIMIT 1";
            cmd.Parameters.AddWithValue("@id", _bootId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtNaam.Text = reader.GetString("naam");
                txtMerk.Text = reader.IsDBNull(reader.GetOrdinal("merk")) ? string.Empty : reader.GetString("merk");
                var bsId = reader.GetInt32("bootsoort_id");
                var locId = reader.GetInt32("locatie_id");
                nudCapaciteit.Value = reader.GetInt32("capaciteit");
                nudBouwjaar.Value = reader.IsDBNull(reader.GetOrdinal("bouwjaar")) ? nudBouwjaar.Minimum : reader.GetInt32("bouwjaar");
                nudLengte.Value = reader.IsDBNull(reader.GetOrdinal("lengte")) ? nudLengte.Minimum : reader.GetDecimal("lengte");
                txtOmschrijving.Text = reader.IsDBNull(reader.GetOrdinal("omschrijving")) ? string.Empty : reader.GetString("omschrijving");
                nudPrijs.Value = reader.IsDBNull(reader.GetOrdinal("prijs_per_uur")) ? nudPrijs.Minimum : reader.GetDecimal("prijs_per_uur");
                // select combobox items after they are loaded (they may be empty if called before load)
                for (int i = 0; i < cmbType.Items.Count; i++) if (cmbType.Items[i] is ComboItem it && it.Id == bsId) { cmbType.SelectedIndex = i; break; }
                for (int i = 0; i < cmbLocatie.Items.Count; i++) if (cmbLocatie.Items[i] is ComboItem it && it.Id == locId) { cmbLocatie.SelectedIndex = i; break; }
            }
        }
        catch (Exception ex) { MessageBox.Show("Fout bij laden boot: " + ex.Message); }
    }

    private void BtnPrimary_Click(object? sender, EventArgs e)
    {
        if (cmbType.SelectedItem is not ComboItem soort) { MessageBox.Show("Selecteer een bootsoort.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        if (cmbLocatie.SelectedItem is not ComboItem loc) { MessageBox.Show("Selecteer een locatie.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection(); conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE boten SET naam=@naam, merk=@merk, bootsoort_id=@bootsoort, locatie_id=@locatie, capaciteit=@capaciteit, bouwjaar=@bouwjaar, lengte=@lengte, omschrijving=@omschrijving, prijs_per_uur=@prijs WHERE boot_id=@id";
            cmd.Parameters.AddWithValue("@naam", txtNaam.Text.Trim());
            cmd.Parameters.AddWithValue("@merk", string.IsNullOrWhiteSpace(txtMerk.Text) ? (object)DBNull.Value : txtMerk.Text.Trim());
            cmd.Parameters.AddWithValue("@bootsoort", soort.Id);
            cmd.Parameters.AddWithValue("@locatie", loc.Id);
            cmd.Parameters.AddWithValue("@capaciteit", (int)nudCapaciteit.Value);
            cmd.Parameters.AddWithValue("@bouwjaar", (int)nudBouwjaar.Value);
            cmd.Parameters.AddWithValue("@lengte", nudLengte.Value);
            cmd.Parameters.AddWithValue("@omschrijving", string.IsNullOrWhiteSpace(txtOmschrijving.Text) ? (object)DBNull.Value : txtOmschrijving.Text.Trim());
            cmd.Parameters.AddWithValue("@prijs", nudPrijs.Value);
            cmd.Parameters.AddWithValue("@id", _bootId);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Boot opgeslagen.", "Klaar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        catch (Exception ex) { MessageBox.Show("Fout bij opslaan boot: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }

    private class ComboItem { public int Id; public string Name = string.Empty; public override string ToString() => Name; }

}
