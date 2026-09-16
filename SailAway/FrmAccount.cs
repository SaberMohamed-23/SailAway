namespace SailAway;

public partial class FrmAccount : Form
{
    public FrmAccount()
    {
        InitializeComponent();
        Load += FrmAccount_Load;
        btnPrimary.Click += BtnPrimary_Click;
    }

    private void btnAnnuleren_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void FrmAccount_Load(object? sender, EventArgs e)
    {
        if (!Session.IsIngelogd || Session.KlantId <= 0)
        {
            MessageBox.Show("Je bent niet ingelogd. Log in om je account te bekijken.", "Inloggen vereist", MessageBoxButtons.OK, MessageBoxIcon.Information);
            using var f = new FrmInloggen();
            f.ShowDialog();
            if (!Session.IsIngelogd || Session.KlantId <= 0) { Close(); return; }
        }

        // Load klant details
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT voornaam, tussenvoegsel, achternaam, geboortedatum, telefoonnummer, email FROM klanten WHERE klant_id = @id LIMIT 1";
            cmd.Parameters.AddWithValue("@id", Session.KlantId);
            using var r = cmd.ExecuteReader();
            if (r.Read())
            {
                txtVoornaam.Text = r.IsDBNull(r.GetOrdinal("voornaam")) ? string.Empty : r.GetString("voornaam");
                txtTussenvoegsel.Text = r.IsDBNull(r.GetOrdinal("tussenvoegsel")) ? string.Empty : r.GetString("tussenvoegsel");
                txtAchternaam.Text = r.IsDBNull(r.GetOrdinal("achternaam")) ? string.Empty : r.GetString("achternaam");
                dtpGeboortedatum.Value = r.IsDBNull(r.GetOrdinal("geboortedatum")) ? DateTime.Today : r.GetDateTime("geboortedatum");
                txtTelefoonnummer.Text = r.IsDBNull(r.GetOrdinal("telefoonnummer")) ? string.Empty : r.GetString("telefoonnummer");
                txtEmail.Text = r.IsDBNull(r.GetOrdinal("email")) ? string.Empty : r.GetString("email");
            }
        }
        catch (Exception ex) { MessageBox.Show("Fout bij laden account: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }

    private void BtnPrimary_Click(object? sender, EventArgs e)
    {
        // Validate required fields
        if (string.IsNullOrWhiteSpace(txtVoornaam.Text) || string.IsNullOrWhiteSpace(txtAchternaam.Text) || string.IsNullOrWhiteSpace(txtTelefoonnummer.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
        {
            MessageBox.Show("Vul alle verplichte velden in (voornaam, achternaam, telefoonnummer, e-mail).", "Validatie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE klanten SET voornaam=@voornaam, tussenvoegsel=@tussenvoegsel, achternaam=@achternaam, geboortedatum=@geboortedatum, telefoonnummer=@telefoonnummer, email=@email WHERE klant_id=@id";
            cmd.Parameters.AddWithValue("@voornaam", txtVoornaam.Text.Trim());
            cmd.Parameters.AddWithValue("@tussenvoegsel", string.IsNullOrWhiteSpace(txtTussenvoegsel.Text) ? (object)DBNull.Value : txtTussenvoegsel.Text.Trim());
            cmd.Parameters.AddWithValue("@achternaam", txtAchternaam.Text.Trim());
            cmd.Parameters.AddWithValue("@geboortedatum", dtpGeboortedatum.Value.Date);
            cmd.Parameters.AddWithValue("@telefoonnummer", txtTelefoonnummer.Text.Trim());
            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@id", Session.KlantId);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Accountgegevens opgeslagen.", "Klaar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (MySqlConnector.MySqlException ex)
        {
            MessageBox.Show("Databasefout bij opslaan account: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fout bij opslaan account: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}
