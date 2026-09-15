namespace SailAway;

public partial class FrmKlantToevoegen : Form
{
    public FrmKlantToevoegen()
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
        // Simple add klant without creating gebruiker (for admin use).
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO klanten (voornaam, tussenvoegsel, achternaam, geboortedatum, telefoonnummer, email) VALUES (@voornaam, @tussenvoegsel, @achternaam, @geboortedatum, @telefoonnummer, @email);";
            cmd.Parameters.AddWithValue("@voornaam", txtVoornaam.Text.Trim());
            cmd.Parameters.AddWithValue("@tussenvoegsel", string.IsNullOrWhiteSpace(txtTussenvoegsel.Text) ? (object)DBNull.Value : txtTussenvoegsel.Text.Trim());
            cmd.Parameters.AddWithValue("@achternaam", txtAchternaam.Text.Trim());
            cmd.Parameters.AddWithValue("@geboortedatum", dtpGeboortedatum.Value.Date);
            cmd.Parameters.AddWithValue("@telefoonnummer", txtTelefoonnummer.Text.Trim());
            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
            cmd.ExecuteNonQuery();

            MessageBox.Show("Klant toegevoegd.", "Klant toevoegen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fout bij toevoegen klant: " + ex.Message, "Klant toevoegen", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}
