namespace SailAway;

public partial class FrmKlantBewerken : Form
{
    private int _klantId;

    public FrmKlantBewerken()
    {
        InitializeComponent();
        btnPrimary.Click += BtnPrimary_Click;
    }

    public FrmKlantBewerken(int klantId) : this()
    {
        _klantId = klantId;
        LoadKlant();
    }

    private void btnAnnuleren_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void BtnPrimary_Click(object? sender, EventArgs e)
    {
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE klanten SET voornaam=@voornaam, tussenvoegsel=@tussenvoegsel, achternaam=@achternaam, geboortedatum=@geboortedatum, telefoonnummer=@telefoonnummer, email=@email WHERE klant_id=@klant_id";
            cmd.Parameters.AddWithValue("@voornaam", txtVoornaam.Text.Trim());
            cmd.Parameters.AddWithValue("@tussenvoegsel", string.IsNullOrWhiteSpace(txtTussenvoegsel.Text) ? (object)DBNull.Value : txtTussenvoegsel.Text.Trim());
            cmd.Parameters.AddWithValue("@achternaam", txtAchternaam.Text.Trim());
            cmd.Parameters.AddWithValue("@geboortedatum", dtpGeboortedatum.Value.Date);
            cmd.Parameters.AddWithValue("@telefoonnummer", txtTelefoonnummer.Text.Trim());
            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@klant_id", _klantId);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Klant opgeslagen.", "Klant bewerken", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fout bij opslaan klant: " + ex.Message, "Klant bewerken", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadKlant()
    {
        if (_klantId <= 0) return;

        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT voornaam, tussenvoegsel, achternaam, geboortedatum, telefoonnummer, email FROM klanten WHERE klant_id = @klant_id LIMIT 1";
            cmd.Parameters.AddWithValue("@klant_id", _klantId);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtVoornaam.Text = reader.GetString("voornaam");
                txtTussenvoegsel.Text = reader.IsDBNull(reader.GetOrdinal("tussenvoegsel")) ? string.Empty : reader.GetString("tussenvoegsel");
                txtAchternaam.Text = reader.GetString("achternaam");
                dtpGeboortedatum.Value = reader.GetDateTime("geboortedatum");
                txtTelefoonnummer.Text = reader.GetString("telefoonnummer");
                txtEmail.Text = reader.GetString("email");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fout bij laden klant: " + ex.Message, "Klant bewerken", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}
