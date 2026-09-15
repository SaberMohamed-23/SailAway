namespace SailAway;

public partial class FrmReserveringBewerken : Form
{
    private int _reserveringId;

    public FrmReserveringBewerken()
    {
        InitializeComponent();
        Load += FrmReserveringBewerken_Load;
        btnPrimary.Click += BtnPrimary_Click;
        cmbLocatie.SelectedIndexChanged += CmbLocatie_SelectedIndexChanged;
        // add NumericUpDown for aantal personen programmatically
        var lblAantal = new Label();
        lblAantal.Location = new Point(220, 377);
        lblAantal.Size = new Size(160, 25);
        lblAantal.Text = "Aantal personen:";
        lblAantal.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        Controls.Add(lblAantal);

        var nud = new NumericUpDown();
        nud.Name = "nudAantalPersonen";
        nud.Location = new Point(390, 377);
        nud.Size = new Size(150, 25);
        nud.Minimum = 1;
        nud.Maximum = 20;
        nud.Value = 1;
        nud.TabIndex = 100;
        Controls.Add(nud);
        cmbBoot.SelectedIndexChanged += (s, e) =>
        {
            var selectedBoot = cmbBoot.SelectedItem as ComboItem;
            if (selectedBoot == null) return;
            var control = Controls.Find("nudAantalPersonen", true).FirstOrDefault() as NumericUpDown;
            if (control == null) return;
            var prev = control.Value;
            control.Maximum = Math.Max(1, selectedBoot.Capacity);
            if (prev > control.Maximum) control.Value = control.Maximum;
        };
    }

    public FrmReserveringBewerken(int reserveringId) : this()
    {
        _reserveringId = reserveringId;
    }

    private void FrmReserveringBewerken_Load(object? sender, EventArgs e)
    {
        LoadLocations();
        LoadKlanten();
        if (_reserveringId > 0) LoadReservering();
    }

    private class ComboItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public override string ToString() => Name;
    }

    private void LoadLocations()
    {
        cmbLocatie.Items.Clear();
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT locatie_id, naam FROM locaties ORDER BY naam";
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) cmbLocatie.Items.Add(new ComboItem { Id = reader.GetInt32("locatie_id"), Name = reader.GetString("naam") });
            if (cmbLocatie.Items.Count > 0) cmbLocatie.SelectedIndex = 0;
        }
        catch (Exception ex) { MessageBox.Show("Fout bij laden locaties: " + ex.Message); }
    }

    private void LoadKlanten()
    {
        cmbKlant.Items.Clear();
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT klant_id, voornaam, tussenvoegsel, achternaam FROM klanten ORDER BY achternaam";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var naam = reader.GetString("voornaam");
                var tv = reader.IsDBNull(reader.GetOrdinal("tussenvoegsel")) ? string.Empty : reader.GetString("tussenvoegsel");
                var achternaam = reader.GetString("achternaam");
                cmbKlant.Items.Add(new ComboItem { Id = reader.GetInt32("klant_id"), Name = string.IsNullOrWhiteSpace(tv) ? $"{naam} {achternaam}" : $"{naam} {tv} {achternaam}" });
            }
            if (cmbKlant.Items.Count > 0) cmbKlant.SelectedIndex = 0;
        }
        catch (Exception ex) { MessageBox.Show("Fout bij laden klanten: " + ex.Message); }
    }

    private void CmbLocatie_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (cmbLocatie.SelectedItem is not ComboItem sel) return;
        LoadBoatsForLocation(sel.Id);
    }

    private void LoadBoatsForLocation(int locatieId)
    {
        cmbBoot.Items.Clear();
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT boot_id, naam, capaciteit FROM boten WHERE locatie_id = @locatie_id ORDER BY naam";
            cmd.Parameters.AddWithValue("@locatie_id", locatieId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) cmbBoot.Items.Add(new ComboItem { Id = reader.GetInt32("boot_id"), Name = reader.GetString("naam"), Capacity = reader.GetInt32("capaciteit") });
            if (cmbBoot.Items.Count > 0) cmbBoot.SelectedIndex = 0;
        }
        catch (Exception ex) { MessageBox.Show("Fout bij laden boten: " + ex.Message); }
    }

    private void LoadReservering()
    {
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            // Join to get locatie via boot
            cmd.CommandText = "SELECT r.klant_id, r.boot_id, r.datum, r.begintijd, r.eindtijd, r.aantal_personen, r.status, b.locatie_id FROM reserveringen r JOIN boten b ON r.boot_id = b.boot_id WHERE r.reservering_id = @id LIMIT 1";
            cmd.Parameters.AddWithValue("@id", _reserveringId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var klantId = reader.GetInt32("klant_id");
                var bootId = reader.GetInt32("boot_id");
                var datum = reader.GetDateTime("datum");
                var begintijd = reader.GetTimeSpan("begintijd");
                var eindtijd = reader.GetTimeSpan("eindtijd");
                var aantal = reader.GetInt32("aantal_personen");
                var status = reader.GetString("status");
                var locatieId = reader.GetInt32("locatie_id");

                // select locatie
                for (int i = 0; i < cmbLocatie.Items.Count; i++)
                {
                    if (cmbLocatie.Items[i] is ComboItem it && it.Id == locatieId) { cmbLocatie.SelectedIndex = i; break; }
                }

                // load boats for that locatie and select the boot
                LoadBoatsForLocation(locatieId);
                for (int i = 0; i < cmbBoot.Items.Count; i++) if (cmbBoot.Items[i] is ComboItem it2 && it2.Id == bootId) { cmbBoot.SelectedIndex = i; break; }

                // select klant
                for (int i = 0; i < cmbKlant.Items.Count; i++) if (cmbKlant.Items[i] is ComboItem it3 && it3.Id == klantId) { cmbKlant.SelectedIndex = i; break; }

                dtpDatum.Value = datum;
                dtpBegin.Value = DateTime.Today.Add(begintijd);
                dtpEind.Value = DateTime.Today.Add(eindtijd);
                cmbStatus.SelectedItem = status;
                // set aantal personen into NumericUpDown if present
                var control = Controls.Find("nudAantalPersonen", true).FirstOrDefault() as NumericUpDown;
                if (control != null)
                {
                    control.Maximum = Math.Max(1, cmbBoot.SelectedItem is ComboItem b ? b.Capacity : 20);
                    control.Value = Math.Min(control.Maximum, Math.Max(control.Minimum, aantal));
                }
            }
        }
        catch (Exception ex) { MessageBox.Show("Fout bij laden reservering: " + ex.Message); }
    }

    private void BtnPrimary_Click(object? sender, EventArgs e)
    {
        if (cmbKlant.SelectedItem is not ComboItem klant) { MessageBox.Show("Selecteer een klant.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        if (cmbBoot.SelectedItem is not ComboItem boot) { MessageBox.Show("Selecteer een boot.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

        var datum = dtpDatum.Value.Date;
        var begintijd = dtpBegin.Value.TimeOfDay;
        var eindtijd = dtpEind.Value.TimeOfDay;
        if (eindtijd <= begintijd) { MessageBox.Show("Eindtijd moet later zijn dan begintijd.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        // read aantal from NumericUpDown
        var nudControl = Controls.Find("nudAantalPersonen", true).FirstOrDefault() as NumericUpDown;
        if (nudControl == null) { MessageBox.Show("Aantal personen control niet gevonden.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        var aantal = (int)nudControl.Value;
        if (aantal > boot.Capacity) { MessageBox.Show($"Aantal personen ({aantal}) is groter dan de capaciteit van de boot ({boot.Capacity}).", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();

            // Check overlapping active reservations excluding current one
            cmd.CommandText = @"SELECT 1 FROM reserveringen r WHERE r.boot_id = @boot_id AND r.datum = @datum AND r.status <> 'Geannuleerd' AND r.reservering_id <> @id AND @begintijd < r.eindtijd AND @eindtijd > r.begintijd LIMIT 1";
            cmd.Parameters.AddWithValue("@boot_id", boot.Id);
            cmd.Parameters.AddWithValue("@datum", datum);
            cmd.Parameters.AddWithValue("@begintijd", begintijd);
            cmd.Parameters.AddWithValue("@eindtijd", eindtijd);
            cmd.Parameters.AddWithValue("@id", _reserveringId);
            var exists = cmd.ExecuteScalar() != null;
            if (exists) { MessageBox.Show("Deze boot is op dit tijdstip al gereserveerd.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            cmd.Parameters.Clear();
            cmd.CommandText = @"UPDATE reserveringen SET klant_id=@klant_id, boot_id=@boot_id, datum=@datum, begintijd=@begintijd, eindtijd=@eindtijd, aantal_personen=@aantal, status=@status WHERE reservering_id=@id";
            cmd.Parameters.AddWithValue("@klant_id", klant.Id);
            cmd.Parameters.AddWithValue("@boot_id", boot.Id);
            cmd.Parameters.AddWithValue("@datum", datum);
            cmd.Parameters.AddWithValue("@begintijd", begintijd);
            cmd.Parameters.AddWithValue("@eindtijd", eindtijd);
            cmd.Parameters.AddWithValue("@aantal", aantal);
            cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem?.ToString() ?? "Actief");
            cmd.Parameters.AddWithValue("@id", _reserveringId);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Reservering opgeslagen.", "Klaar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        catch (Exception ex) { MessageBox.Show("Fout bij opslaan reservering: " + ex.Message); }
    }

    private void btnAnnuleren_Click(object? sender, EventArgs e)
    {
        Close();
    }

}
