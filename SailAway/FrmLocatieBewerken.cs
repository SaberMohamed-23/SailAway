namespace SailAway;

public partial class FrmLocatieBewerken : Form
{
    public FrmLocatieBewerken()
    {
        InitializeComponent();
    }

    private void btnAnnuleren_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private int _id;
    public FrmLocatieBewerken(int id) : this()
    {
        _id = id; LoadLocatie();
    }

    private void LoadLocatie()
    {
        if (_id <= 0) return;
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection(); conn.Open();
            using var cmd = conn.CreateCommand(); cmd.CommandText = "SELECT naam, adres, beschrijving FROM locaties WHERE locatie_id = @id LIMIT 1"; cmd.Parameters.AddWithValue("@id", _id);
            using var r = cmd.ExecuteReader(); if (r.Read()) { txtNaam.Text = r.GetString("naam"); txtAdres.Text = r.IsDBNull(r.GetOrdinal("adres")) ? string.Empty : r.GetString("adres"); txtBeschrijving.Text = r.IsDBNull(r.GetOrdinal("beschrijving")) ? string.Empty : r.GetString("beschrijving"); }
        }
        catch (Exception ex) { MessageBox.Show("Fout bij laden locatie: " + ex.Message); }
    }

    private void BtnPrimary_Click(object? sender, EventArgs e)
    {
        if (_id <= 0) return;
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection(); conn.Open();
            using var cmd = conn.CreateCommand(); cmd.CommandText = "UPDATE locaties SET naam=@naam, adres=@adres, beschrijving=@beschrijving WHERE locatie_id=@id";
            cmd.Parameters.AddWithValue("@naam", txtNaam.Text.Trim()); cmd.Parameters.AddWithValue("@adres", string.IsNullOrWhiteSpace(txtAdres.Text) ? (object)DBNull.Value : txtAdres.Text.Trim()); cmd.Parameters.AddWithValue("@beschrijving", string.IsNullOrWhiteSpace(txtBeschrijving.Text) ? (object)DBNull.Value : txtBeschrijving.Text.Trim()); cmd.Parameters.AddWithValue("@id", _id);
            cmd.ExecuteNonQuery(); MessageBox.Show("Locatie opgeslagen.", "Klaar", MessageBoxButtons.OK, MessageBoxIcon.Information); Close();
        }
        catch (Exception ex) { MessageBox.Show("Fout bij opslaan locatie: " + ex.Message); }
    }

}
