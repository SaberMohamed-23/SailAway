using System.Net.Mail;

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
        // Gegevens uit de invoervelden halen
        string email = txtEmail.Text.Trim();
        string telefoonnummer = txtTelefoonnummer.Text.Trim();
        string wachtwoord = txtWachtwoord.Text;
        string wachtwoordHerhalen = txtWachtwoordHerhalen.Text;

        // ----------------------------
        // 1. Controleren of velden zijn ingevuld
        // ----------------------------

        if (string.IsNullOrWhiteSpace(txtVoornaam.Text) ||
            string.IsNullOrWhiteSpace(txtAchternaam.Text) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(telefoonnummer) ||
            string.IsNullOrWhiteSpace(wachtwoord) ||
            string.IsNullOrWhiteSpace(wachtwoordHerhalen))
        {
            MessageBox.Show(
                "Vul alle verplichte gegevens in.",
                "Registreren",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        // ----------------------------
        // 2. E-mailadres controleren
        // ----------------------------

        try
        {
            MailAddress mailAdres = new MailAddress(email);

            if (mailAdres.Address != email)
            {
                MessageBox.Show(
                    "Vul een geldig e-mailadres in.",
                    "Registreren",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
        }
        catch
        {
            MessageBox.Show(
                "Vul een geldig e-mailadres in.",
                "Registreren",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        // ----------------------------
        // 3. Telefoonnummer controleren
        // ----------------------------

        if (telefoonnummer.Length != 10 ||
            !telefoonnummer.All(char.IsDigit) ||
            !telefoonnummer.StartsWith("06"))
        {
            MessageBox.Show(
                "Vul een geldig telefoonnummer in.\nBijvoorbeeld: 0612345678",
                "Registreren",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        // ----------------------------
        // 4. Wachtwoorden controleren
        // ----------------------------

        if (wachtwoord != wachtwoordHerhalen)
        {
            MessageBox.Show(
                "Wachtwoorden komen niet overeen.",
                "Registreren",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();

            // ----------------------------
            // 5. Controleren of e-mail al bestaat
            // ----------------------------

            using (var checkCmd = conn.CreateCommand())
            {
                checkCmd.CommandText = @"
                    SELECT COUNT(*)
                    FROM gebruikers
                    WHERE email = @email;
                ";

                checkCmd.Parameters.AddWithValue("@email", email);

                long aantal = Convert.ToInt64(checkCmd.ExecuteScalar());

                if (aantal > 0)
                {
                    MessageBox.Show(
                        "Dit e-mailadres is al in gebruik.",
                        "Registreren",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            // ----------------------------
            // 6. Gebruiker + klant opslaan
            // ----------------------------

            using var tran = conn.BeginTransaction();

            using (var cmd = conn.CreateCommand())
            {
                cmd.Transaction = tran;

                // Gebruiker aanmaken
                cmd.CommandText = @"
                    INSERT INTO gebruikers
                    (email, wachtwoord, rol, actief)
                    VALUES
                    (@email, @wachtwoord, 'Klant', true);
                ";

                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@wachtwoord", wachtwoord);

                cmd.ExecuteNonQuery();

                // ID van de nieuwe gebruiker ophalen
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT LAST_INSERT_ID();";

                int gebruikerId = Convert.ToInt32(cmd.ExecuteScalar());

                // Klant aanmaken
                cmd.Parameters.Clear();

                cmd.CommandText = @"
                    INSERT INTO klanten
                    (
                        gebruiker_id,
                        voornaam,
                        tussenvoegsel,
                        achternaam,
                        geboortedatum,
                        telefoonnummer,
                        email
                    )
                    VALUES
                    (
                        @gebruiker_id,
                        @voornaam,
                        @tussenvoegsel,
                        @achternaam,
                        @geboortedatum,
                        @telefoonnummer,
                        @email
                    );
                ";

                cmd.Parameters.AddWithValue("@gebruiker_id", gebruikerId);
                cmd.Parameters.AddWithValue("@voornaam", txtVoornaam.Text.Trim());

                cmd.Parameters.AddWithValue(
                    "@tussenvoegsel",
                    string.IsNullOrWhiteSpace(txtTussenvoegsel.Text)
                        ? (object)DBNull.Value
                        : txtTussenvoegsel.Text.Trim()
                );

                cmd.Parameters.AddWithValue("@achternaam", txtAchternaam.Text.Trim());
                cmd.Parameters.AddWithValue("@geboortedatum", dtpGeboortedatum.Value.Date);
                cmd.Parameters.AddWithValue("@telefoonnummer", telefoonnummer);
                cmd.Parameters.AddWithValue("@email", email);

                cmd.ExecuteNonQuery();
            }

            // Alles is goed opgeslagen
            tran.Commit();

            MessageBox.Show(
                "Registratie gelukt. Je kunt nu inloggen.",
                "Registreren",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Fout bij registreren: " + ex.Message,
                "Registreren",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}