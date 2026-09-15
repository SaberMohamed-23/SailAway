namespace SailAway;

public partial class FrmRegistreren : Form
{
    public FrmRegistreren()
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
        // Simple registration: create gebruiker then klant and link them.
        if (txtWachtwoord.Text != txtWachtwoordHerhalen.Text)
        {
            MessageBox.Show("Wachtwoorden komen niet overeen.", "Registreren", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();

            using var tran = conn.BeginTransaction();

            using (var cmd = conn.CreateCommand())
            {
                cmd.Transaction = tran;
                cmd.CommandText = "INSERT INTO gebruikers (email, wachtwoord, rol, actief) VALUES (@email, @wachtwoord, 'Klant', true);";
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@wachtwoord", txtWachtwoord.Text);
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT LAST_INSERT_ID();";
                var gebruikerId = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO klanten (gebruiker_id, voornaam, tussenvoegsel, achternaam, geboortedatum, telefoonnummer, email) VALUES (@gebruiker_id, @voornaam, @tussenvoegsel, @achternaam, @geboortedatum, @telefoonnummer, @email);";
                cmd.Parameters.AddWithValue("@gebruiker_id", gebruikerId);
                cmd.Parameters.AddWithValue("@voornaam", txtVoornaam.Text.Trim());
                cmd.Parameters.AddWithValue("@tussenvoegsel", string.IsNullOrWhiteSpace(txtTussenvoegsel.Text) ? (object)DBNull.Value : txtTussenvoegsel.Text.Trim());
                cmd.Parameters.AddWithValue("@achternaam", txtAchternaam.Text.Trim());
                cmd.Parameters.AddWithValue("@geboortedatum", dtpGeboortedatum.Value.Date);
                cmd.Parameters.AddWithValue("@telefoonnummer", txtTelefoonnummer.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.ExecuteNonQuery();
            }

            tran.Commit();

            MessageBox.Show("Registratie gelukt. Je kunt nu inloggen.", "Registreren", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fout bij registreren: " + ex.Message, "Registreren", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}
