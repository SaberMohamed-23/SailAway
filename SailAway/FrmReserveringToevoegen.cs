namespace SailAway;

public partial class FrmReserveringToevoegen : Form
{
    // optional property to pre-select a boot when opened programmatically
    public int SelectedBootId { get; set; }

    public FrmReserveringToevoegen()
    {
        InitializeComponent();
        Load += FrmReserveringToevoegen_Load;
        btnPrimary.Click += BtnPrimary_Click;
        cmbLocatie.SelectedIndexChanged += CmbLocatie_SelectedIndexChanged;
        // programmatically add NumericUpDown for aantal personen (keep Designer files unchanged)
        var lblAantal = new Label();
        lblAantal.Location = new Point(220, 355);
        lblAantal.Size = new Size(160, 25);
        lblAantal.Text = "Aantal personen:";
        lblAantal.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        Controls.Add(lblAantal);

        var nud = new NumericUpDown();
        nud.Name = "nudAantalPersonen";
        nud.Location = new Point(390, 355);
        nud.Size = new Size(150, 25);
        nud.Minimum = 1;
        nud.Maximum = 20;
        nud.Value = 1;
        nud.TabIndex = 100;
        nud.ValueChanged += (s, e) => { /* no-op default */ };
        Controls.Add(nud);
        // update nud maximum when selected boat changes
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

    private void btnAnnuleren_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private class ComboItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public override string ToString() => Name;
    }

    private void FrmReserveringToevoegen_Load(object? sender, EventArgs e)
    {
        LoadLocations();
        LoadKlanten();
        // If a SelectedBootId was provided, try to select correct locatie and boot
        if (SelectedBootId > 0)
        {
            try
            {
                using var conn = Database.DatabaseConnection.GetConnection(); conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT locatie_id FROM boten WHERE boot_id = @id LIMIT 1";
                cmd.Parameters.AddWithValue("@id", SelectedBootId);
                var val = cmd.ExecuteScalar();
                if (val != null && val != DBNull.Value)
                {
                    var locId = Convert.ToInt32(val);
                    for (int i = 0; i < cmbLocatie.Items.Count; i++)
                    {
                        if (cmbLocatie.Items[i] is ComboItem it && it.Id == locId)
                        {
                            cmbLocatie.SelectedIndex = i;
                            break;
                        }
                    }
                    // LoadBoatsForLocation will select the first boat; select the provided one
                    LoadBoatsForLocation(locId);
                    for (int i = 0; i < cmbBoot.Items.Count; i++) if (cmbBoot.Items[i] is ComboItem it2 && it2.Id == SelectedBootId) { cmbBoot.SelectedIndex = i; break; }
                }
            }
            catch { }
        }
        // If user is logged in and is a klant, pre-select and lock klant
        if (Session.IsIngelogd && Session.KlantId > 0)
        {
            for (int i = 0; i < cmbKlant.Items.Count; i++)
            {
                if (cmbKlant.Items[i] is ComboItem it && it.Id == Session.KlantId)
                {
                    cmbKlant.SelectedIndex = i;
                    break;
                }
            }
            cmbKlant.Enabled = false;
        }
        cmbStatus.SelectedIndex = 0; // default
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
            while (reader.Read())
            {
                cmbLocatie.Items.Add(new ComboItem { Id = reader.GetInt32("locatie_id"), Name = reader.GetString("naam") });
            }
            if (cmbLocatie.Items.Count > 0) cmbLocatie.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fout bij laden locaties: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
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
        catch (Exception ex)
        {
            MessageBox.Show("Fout bij laden klanten: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CmbLocatie_SelectedIndexChanged(object? sender, EventArgs e)
    {
        var selected = cmbLocatie.SelectedItem as ComboItem;
        if (selected != null)
            LoadBoatsForLocation(selected.Id);
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
            while (reader.Read())
            {
                cmbBoot.Items.Add(new ComboItem { Id = reader.GetInt32("boot_id"), Name = reader.GetString("naam"), Capacity = reader.GetInt32("capaciteit") });
            }
            if (cmbBoot.Items.Count > 0) cmbBoot.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fout bij laden boten: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnPrimary_Click(object? sender, EventArgs e)
    {
        // Validate selections
        if (cmbKlant.SelectedItem is not ComboItem klant) { MessageBox.Show("Selecteer een klant.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        if (cmbBoot.SelectedItem is not ComboItem boot) { MessageBox.Show("Selecteer een boot.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

        var datum = dtpDatum.Value.Date;
        var begintijd = dtpBegin.Value.TimeOfDay;
        var eindtijd = dtpEind.Value.TimeOfDay;
        if (eindtijd <= begintijd) { MessageBox.Show("Eindtijd moet later zijn dan begintijd.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

        // Read aantal personen from NumericUpDown
        var nudControl = Controls.Find("nudAantalPersonen", true).FirstOrDefault() as NumericUpDown;
        if (nudControl == null) { MessageBox.Show("Aantal personen control niet gevonden.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        var aantal = (int)nudControl.Value;

        // Check capacity
        if (aantal > boot.Capacity) { MessageBox.Show($"Aantal personen ({aantal}) is groter dan de capaciteit van de boot ({boot.Capacity}).", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

        // If user is logged in, use Session.KlantId as the klant
        if (Session.IsIngelogd && Session.KlantId > 0)
        {
            // override selected klant with session klant
            klant = new ComboItem { Id = Session.KlantId, Name = klant.Name, Capacity = klant.Capacity };
        }

        // Check overlapping reservations
        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT 1 FROM reserveringen r WHERE r.boot_id = @boot_id AND r.datum = @datum AND r.status <> 'Geannuleerd' AND @begintijd < r.eindtijd AND @eindtijd > r.begintijd LIMIT 1";
            cmd.Parameters.AddWithValue("@boot_id", boot.Id);
            cmd.Parameters.AddWithValue("@datum", datum);
            cmd.Parameters.AddWithValue("@begintijd", begintijd);
            cmd.Parameters.AddWithValue("@eindtijd", eindtijd);
            var exists = cmd.ExecuteScalar() != null;
            if (exists) { MessageBox.Show("Deze boot is op dit tijdstip al gereserveerd.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // Insert reservation
            cmd.Parameters.Clear();
            cmd.CommandText = @"INSERT INTO reserveringen (klant_id, boot_id, datum, begintijd, eindtijd, aantal_personen, status) VALUES (@klant_id, @boot_id, @datum, @begintijd, @eindtijd, @aantal, @status)";
            cmd.Parameters.AddWithValue("@klant_id", klant.Id);
            cmd.Parameters.AddWithValue("@boot_id", boot.Id);
            cmd.Parameters.AddWithValue("@datum", datum);
            cmd.Parameters.AddWithValue("@begintijd", begintijd);
            cmd.Parameters.AddWithValue("@eindtijd", eindtijd);
            cmd.Parameters.AddWithValue("@aantal", aantal);
            cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem?.ToString() ?? "Actief");
            cmd.ExecuteNonQuery();

            MessageBox.Show("Reservering toegevoegd.", "Klaar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fout bij opslaan reservering: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}
