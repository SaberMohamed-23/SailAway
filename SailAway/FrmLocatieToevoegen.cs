namespace SailAway;

public partial class FrmLocatieToevoegen : Form
{
    public FrmLocatieToevoegen()
    {
        InitializeComponent();
        btnPrimary.Click += BtnPrimary_Click;
    }

    private void btnAnnuleren_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void BtnPrimary_Click(object? sender, EventArgs e)
    {
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection(); conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO locaties (naam, adres, beschrijving) VALUES (@naam, @adres, @beschrijving)";
            cmd.Parameters.AddWithValue("@naam", txtNaam.Text.Trim());
            cmd.Parameters.AddWithValue("@adres", string.IsNullOrWhiteSpace(txtAdres.Text) ? (object)DBNull.Value : txtAdres.Text.Trim());
            cmd.Parameters.AddWithValue("@beschrijving", string.IsNullOrWhiteSpace(txtBeschrijving.Text) ? (object)DBNull.Value : txtBeschrijving.Text.Trim());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Locatie toegevoegd.", "Klaar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        catch (Exception ex) { MessageBox.Show("Fout bij toevoegen locatie: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }

}
