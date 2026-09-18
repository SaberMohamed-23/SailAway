namespace SailAway;

public partial class FrmBoten : Form
{
    public FrmBoten()
    {
        InitializeComponent();

        // Menu-acties koppelen
        mnuHome.Click += (s, e) => { var f = new FrmStart(); f.Show(); this.Close(); };
        mnuBoten.Click += (s, e) => { /* Al op deze pagina */ };
        mnuReserveringen.Click += (s, e) => { var f = new FrmMijnReserveringen(); f.Show(); this.Close(); };
        mnuAccount.Click += (s, e) => { var f = new FrmAccount(); f.Show(); this.Close(); };

        Load += FrmBoten_Load;
        btnZoeken.Click += BtnZoeken_Click;
        cmbSorteer.SelectedIndexChanged += (s, e) => LoadAvailableBoats();
    }

    private void FrmBoten_Load(object? sender, EventArgs e)
    {
        try
        {
            cmbLocatie.Items.Clear();
            cmbTypeBoot.Items.Clear();
            cmbSorteer.Items.Clear();

            // Vul sorteer opties
            cmbSorteer.Items.Add(new ComboItem { Id = 1, Name = "Naam (A-Z)" });
            cmbSorteer.Items.Add(new ComboItem { Id = 2, Name = "Prijs (Laag-Hoog)" });
            cmbSorteer.Items.Add(new ComboItem { Id = 3, Name = "Prijs (Hoog-Laag)" });
            cmbSorteer.Items.Add(new ComboItem { Id = 4, Name = "Capaciteit (Groot-Klein)" });
            cmbSorteer.SelectedIndex = 0;

            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();

            // Laad locaties
            cmd.CommandText = "SELECT locatie_id, naam FROM locaties ORDER BY naam";
            using var r = cmd.ExecuteReader();
            while (r.Read()) cmbLocatie.Items.Add(new ComboItem { Id = r.GetInt32("locatie_id"), Name = r.GetString("naam") });
            r.Close();

            // Laad bootsoorten
            cmbTypeBoot.Items.Add(new ComboItem { Id = 0, Name = "Alle" });
            cmd.CommandText = "SELECT bootsoort_id, naam FROM bootsoorten ORDER BY naam";
            using var r2 = cmd.ExecuteReader();
            while (r2.Read()) cmbTypeBoot.Items.Add(new ComboItem { Id = r2.GetInt32("bootsoort_id"), Name = r2.GetString("naam") });

            if (cmbLocatie.Items.Count > 0) cmbLocatie.SelectedIndex = 0;
            if (cmbTypeBoot.Items.Count > 0) cmbTypeBoot.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fout bij laden filters: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        LoadAvailableBoats();
    }

    private void BtnZoeken_Click(object? s, EventArgs e) => LoadAvailableBoats();

    private class ComboItem { public int Id; public string Name = string.Empty; public override string ToString() => Name; }

    private void LoadAvailableBoats()
    {
        var startY = 200; // Startpositie voor de lijst van boten
        var dyn = Controls.Cast<Control>().Where(c => c.Tag is string t && t == "dynamicBoat").ToList();
        foreach (var c in dyn) Controls.Remove(c);

        if (cmbLocatie.SelectedItem is not ComboItem locatie)
        {
            return;
        }

        int bootsoortId = 0;
        if (cmbTypeBoot.SelectedItem is ComboItem bsi) bootsoortId = bsi.Id;

        // Bepaal de sorteervolgorde
        string orderByClause = "ORDER BY b.naam";
        if (cmbSorteer.SelectedItem is ComboItem sortItem)
        {
            orderByClause = sortItem.Id switch
            {
                1 => "ORDER BY b.naam ASC",
                2 => "ORDER BY b.prijs_per_uur ASC",
                3 => "ORDER BY b.prijs_per_uur DESC",
                4 => "ORDER BY b.capaciteit DESC",
                _ => "ORDER BY b.naam ASC"
            };
        }

        try
        {
            using var conn = Database.DatabaseConnection.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();

            // Query zonder tijd/datum/personen filters
            cmd.CommandText = $@"SELECT b.boot_id, b.naam, bs.naam AS bootsoort, l.naam AS locatie, b.capaciteit, b.prijs_per_uur
FROM boten b
JOIN bootsoorten bs ON b.bootsoort_id = bs.bootsoort_id
JOIN locaties l ON b.locatie_id = l.locatie_id
WHERE b.locatie_id = @locatie 
AND (@bootsoortId = 0 OR b.bootsoort_id = @bootsoortId)
{orderByClause}";

            cmd.Parameters.AddWithValue("@locatie", locatie.Id);
            cmd.Parameters.AddWithValue("@bootsoortId", bootsoortId);

            using var reader = cmd.ExecuteReader();
            int index = 0;
            while (reader.Read())
            {
                var bootId = reader.GetInt32("boot_id");
                var naam = reader.GetString("naam");
                var bootsoort = reader.GetString("bootsoort");
                var locnaam = reader.GetString("locatie");
                var capaciteit = reader.GetInt32("capaciteit");
                var prijs = reader.IsDBNull(reader.GetOrdinal("prijs_per_uur")) ? 0m : reader.GetDecimal("prijs_per_uur");

                var grp = new GroupBox();
                grp.Text = naam;
                grp.Size = new Size(885, 75);
                grp.Location = new Point(45, startY + index * 85);
                grp.BackColor = Color.FromArgb(242, 242, 242);
                grp.Tag = "dynamicBoat";

                var lbl = new Label();
                lbl.Location = new Point(18, 32);
                lbl.AutoSize = true;
                lbl.Text = $"{bootsoort}   |   {locnaam}   |   {capaciteit} personen   |   {prijs:C} per uur";
                grp.Controls.Add(lbl);

                var btn = new Button();
                btn.Location = new Point(745, 24);
                btn.Size = new Size(110, 32);
                btn.Text = "Bekijken";
                btn.BackColor = Color.FromArgb(181, 32, 46);
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Tag = bootId;
                btn.Click += DynamicBekijken_Click;
                grp.Controls.Add(btn);

                Controls.Add(grp);
                index++;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fout bij laden boten: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DynamicBekijken_Click(object? sender, EventArgs e)
    {
        if (sender is Button b && b.Tag is int id)
        {
            using var frm = new FrmBootDetails(id);
            frm.ShowDialog();
        }
    }
}