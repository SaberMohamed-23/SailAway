namespace SailAway;

public partial class FrmReserveringenBeheer : Form
{
    public FrmReserveringenBeheer()
    {
        InitializeComponent();
        Load += FrmReserveringenBeheer_Load;
    }

    private void FrmReserveringenBeheer_Load(object? sender, EventArgs e)
    {
        LoadReservations();
    }

    private void LoadReservations()
    {
        dgv.Rows.Clear();
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT r.reservering_id, k.voornaam, k.tussenvoegsel, k.achternaam, b.naam AS bootnaam, l.naam AS locatienaam, r.datum, r.begintijd, r.eindtijd, r.status FROM reserveringen r JOIN klanten k ON r.klant_id = k.klant_id JOIN boten b ON r.boot_id = b.boot_id JOIN locaties l ON b.locatie_id = l.locatie_id ORDER BY r.datum, r.begintijd";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var id = reader.GetInt32("reservering_id");
                var voornaam = reader.GetString("voornaam");
                var tussen = reader.IsDBNull(reader.GetOrdinal("tussenvoegsel")) ? string.Empty : reader.GetString("tussenvoegsel");
                var achternaam = reader.GetString("achternaam");
                var klantNaam = string.IsNullOrWhiteSpace(tussen) ? $"{voornaam} {achternaam}" : $"{voornaam} {tussen} {achternaam}";
                var bootNaam = reader.GetString("bootnaam");
                var locatieNaam = reader.GetString("locatienaam");
                var datum = reader.GetDateTime("datum");
                var begintijd = reader.GetTimeSpan("begintijd");
                var eindtijd = reader.GetTimeSpan("eindtijd");
                var status = reader.GetString("status");

                var rowIndex = dgv.Rows.Add(klantNaam, bootNaam, locatieNaam, datum.ToString("dd-MM-yyyy"), begintijd.ToString(@"hh\:mm"), eindtijd.ToString(@"hh\:mm"), status);
                dgv.Rows[rowIndex].Tag = id;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fout bij laden reserveringen: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnToevoegen_Click(object? s, EventArgs e)
    {
        using var frm = new FrmReserveringToevoegen();
        frm.ShowDialog();
        LoadReservations();
    }

    private void btnBewerken_Click(object? s, EventArgs e)
    {
        // Try to obtain reservation id from selected row (if real data is loaded into the grid with an id)
        if (dgv.SelectedRows.Count == 0)
        {
            MessageBox.Show("Selecteer eerst een reservering.", "Bewerken", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var row = dgv.SelectedRows[0];
        if (row.Tag is int id && id > 0)
        {
            using var frm = new FrmReserveringBewerken(id);
            frm.ShowDialog();
            LoadReservations();
        }
        else
        {
            // Fallback: open editor without id
            using var frm = new FrmReserveringBewerken();
            frm.ShowDialog();
            LoadReservations();
        }
    }
    private void btnVerwijderen_Click(object? s, EventArgs e)
    {
        if (dgv.SelectedRows.Count == 0)
        {
            MessageBox.Show("Selecteer eerst een reservering.", "Verwijderen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var row = dgv.SelectedRows[0];
        if (row.Tag is not int id || id <= 0)
        {
            MessageBox.Show("Kan reservering id niet vinden.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var confirm = MessageBox.Show("Weet u zeker dat u deze reservering wilt verwijderen?", "Reservering verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM reserveringen WHERE reservering_id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            LoadReservations();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fout bij verwijderen reservering: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}
