namespace SailAway;

public partial class FrmBootsoortBewerken : Form
{
    public FrmBootsoortBewerken()
    {
        InitializeComponent();
        btnPrimary.Click += BtnPrimary_Click;
    }

    private void btnAnnuleren_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private int _id;
    public FrmBootsoortBewerken(int id) : this()
    {
        _id = id; LoadBootsoort();
    }

    private void LoadBootsoort()
    {
        if (_id <= 0) return;
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection(); conn.Open();
            using var cmd = conn.CreateCommand(); cmd.CommandText = "SELECT naam, beschrijving FROM bootsoorten WHERE bootsoort_id = @id LIMIT 1"; cmd.Parameters.AddWithValue("@id", _id);
            using var r = cmd.ExecuteReader(); if (r.Read()) { txtNaam.Text = r.GetString("naam"); txtBeschrijving.Text = r.IsDBNull(r.GetOrdinal("beschrijving")) ? string.Empty : r.GetString("beschrijving"); }
        }
        catch (Exception ex) { MessageBox.Show("Fout bij laden bootsoort: " + ex.Message); }
    }

    private void BtnPrimary_Click(object? sender, EventArgs e)
    {
        if (_id <= 0) return;
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection(); conn.Open();
            using var cmd = conn.CreateCommand(); cmd.CommandText = "UPDATE bootsoorten SET naam=@naam, beschrijving=@beschrijving WHERE bootsoort_id=@id";
            cmd.Parameters.AddWithValue("@naam", txtNaam.Text.Trim()); cmd.Parameters.AddWithValue("@beschrijving", string.IsNullOrWhiteSpace(txtBeschrijving.Text) ? (object)DBNull.Value : txtBeschrijving.Text.Trim()); cmd.Parameters.AddWithValue("@id", _id); cmd.ExecuteNonQuery();
            MessageBox.Show("Bootsoort opgeslagen.", "Klaar", MessageBoxButtons.OK, MessageBoxIcon.Information); Close();
        }
        catch (Exception ex) { MessageBox.Show("Fout bij opslaan bootsoort: " + ex.Message); }
    }

}
