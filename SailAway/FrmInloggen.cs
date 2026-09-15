namespace SailAway;

public partial class FrmInloggen : Form
{
    public FrmInloggen()
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
        // Simple login logic: find gebruiker by email and password, then open form based on role.
        var email = txtEmail.Text.Trim();
        var wachtwoord = txtWachtwoord.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(wachtwoord))
        {
            MessageBox.Show("Vul e-mail en wachtwoord in.", "Inloggen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT gebruiker_id, rol, actief FROM gebruikers WHERE email = @email AND wachtwoord = @wachtwoord LIMIT 1";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@wachtwoord", wachtwoord);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Onjuiste inloggegevens.", "Inloggen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var rol = reader.GetString("rol");
            var actief = reader.GetBoolean("actief");

            if (!actief)
            {
                MessageBox.Show("Account is niet actief.", "Inloggen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simple role-based navigation
            if (rol == "Klant")
            {
                var frm = new FrmMijnReserveringen();
                frm.Show();
            }
            else
            {
                var frm = new FrmBeheerMenu();
                frm.Show();
            }

            Close();
        }
        catch (MySqlConnector.MySqlException ex)
        {
            MessageBox.Show("Databasefout bij inloggen: " + ex.Message, "Inloggen", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fout bij inloggen: " + ex.Message, "Inloggen", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}
