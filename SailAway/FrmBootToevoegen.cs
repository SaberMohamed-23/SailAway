namespace SailAway;

public partial class FrmBootToevoegen : Form
{
    public FrmBootToevoegen()
    {
        InitializeComponent();
        Load += FrmBootToevoegen_Load;
        btnPrimary.Click += BtnPrimary_Click;
    }

    private void btnAnnuleren_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void FrmBootToevoegen_Load(object? sender, EventArgs e)
    {
        // load bootsoorten and locaties into comboboxes
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
        catch (Exception ex) { MessageBox.Show("Fout bij laden selectievelden: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }

    private void BtnPrimary_Click(object? sender, EventArgs e)
    {
        if (cmbType.SelectedItem is not ComboItem soort) { MessageBox.Show("Selecteer een bootsoort.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        if (cmbLocatie.SelectedItem is not ComboItem loc) { MessageBox.Show("Selecteer een locatie.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection(); conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO boten (naam, merk, bootsoort_id, locatie_id, capaciteit, bouwjaar, lengte, omschrijving, prijs_per_uur)
VALUES (@naam,@merk,@bootsoort,@locatie,@capaciteit,@bouwjaar,@lengte,@omschrijving,@prijs)";
            cmd.Parameters.AddWithValue("@naam", txtNaam.Text.Trim());
            cmd.Parameters.AddWithValue("@merk", string.IsNullOrWhiteSpace(txtMerk.Text) ? (object)DBNull.Value : txtMerk.Text.Trim());
            cmd.Parameters.AddWithValue("@bootsoort", soort.Id);
            cmd.Parameters.AddWithValue("@locatie", loc.Id);
            cmd.Parameters.AddWithValue("@capaciteit", (int)nudCapaciteit.Value);
            cmd.Parameters.AddWithValue("@bouwjaar", (int)nudBouwjaar.Value);
            cmd.Parameters.AddWithValue("@lengte", nudLengte.Value);
            cmd.Parameters.AddWithValue("@omschrijving", string.IsNullOrWhiteSpace(txtOmschrijving.Text) ? (object)DBNull.Value : txtOmschrijving.Text.Trim());
            cmd.Parameters.AddWithValue("@prijs", nudPrijs.Value);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Boot toegevoegd.", "Klaar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        catch (Exception ex) { MessageBox.Show("Fout bij toevoegen boot: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }

    private class ComboItem { public int Id; public string Name = string.Empty; public override string ToString() => Name; }

}
