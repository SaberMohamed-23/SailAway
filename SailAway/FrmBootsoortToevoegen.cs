namespace SailAway;

public partial class FrmBootsoortToevoegen : Form
{
    public FrmBootsoortToevoegen()
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
            cmd.CommandText = "INSERT INTO bootsoorten (naam, beschrijving) VALUES (@naam, @beschrijving)";
            cmd.Parameters.AddWithValue("@naam", txtNaam.Text.Trim());
            cmd.Parameters.AddWithValue("@beschrijving", string.IsNullOrWhiteSpace(txtBeschrijving.Text) ? (object)DBNull.Value : txtBeschrijving.Text.Trim());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Bootsoort toegevoegd.", "Klaar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        catch (Exception ex) { MessageBox.Show("Fout bij toevoegen bootsoort: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }

}
