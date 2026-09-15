namespace SailAway;

partial class FrmLocatiesBeheer
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitel = new Label();
        lblTitel.AutoSize = true;
        lblTitel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblTitel.ForeColor = Color.FromArgb(52, 58, 70);
        lblTitel.Location = new Point(45, 52);
        lblTitel.Text = "Locaties beheren";
        dgv = new DataGridView(); dgv.Location = new Point(45,115); dgv.Size = new Size(760,350); dgv.ReadOnly = true; dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgv.MultiSelect = false; dgv.AllowUserToAddRows = false; dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; dgv.BackgroundColor = Color.White;
        dgv.Columns.Add("Naam", "Naam");
        dgv.Columns.Add("Adres", "Adres");
        dgv.Columns.Add("Beschrijving", "Beschrijving");
        dgv.Rows.Add("Sail Away Veghel", "Havenstraat 1, Veghel", "Startlocatie Veghel");
        dgv.Rows.Add("Sail Away Oss", "Havenweg 10, Oss", "Startlocatie Oss");
        btnToevoegen = new Button(); btnToevoegen.Location = new Point(825,115); btnToevoegen.Size = new Size(120,38); btnToevoegen.Text = "Toevoegen"; btnToevoegen.BackColor = Color.FromArgb(181, 32, 46); btnToevoegen.ForeColor = Color.White; btnToevoegen.FlatStyle = FlatStyle.Flat; btnToevoegen.Click += btnToevoegen_Click;
        btnBewerken = new Button(); btnBewerken.Location = new Point(825,170); btnBewerken.Size = new Size(120,38); btnBewerken.Text = "Bewerken"; btnBewerken.Click += btnBewerken_Click;
        btnVerwijderen = new Button(); btnVerwijderen.Location = new Point(825,225); btnVerwijderen.Size = new Size(120,38); btnVerwijderen.Text = "Verwijderen"; btnVerwijderen.Click += btnVerwijderen_Click;
        Controls.AddRange(new Control[] { lblTitel, dgv, btnToevoegen, btnBewerken, btnVerwijderen });

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(984, 611);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Locaties beheren";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitel;
    private DataGridView dgv;
    private Button btnToevoegen;
    private Button btnBewerken;
    private Button btnVerwijderen;

}
