namespace SailAway;

partial class FrmKlantenBeheer
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
        lblTitel.Text = "Klanten beheren";
        cmbZoekenOp = new ComboBox(); txtZoeken = new TextBox(); btnZoeken = new Button();
        cmbZoekenOp.Location = new Point(45,115); cmbZoekenOp.Size = new Size(180,25); cmbZoekenOp.DropDownStyle = ComboBoxStyle.DropDownList; cmbZoekenOp.Items.AddRange(new object[] { "Achternaam", "Telefoonnummer", "E-mailadres" });
        txtZoeken.Location = new Point(235,115); txtZoeken.Size = new Size(250,25); btnZoeken.Location = new Point(495,111); btnZoeken.Size = new Size(100,32); btnZoeken.Text = "Zoeken";
        dgv = new DataGridView(); dgv.Location = new Point(45,165); dgv.Size = new Size(760,220); dgv.ReadOnly = true; dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgv.MultiSelect = false; dgv.AllowUserToAddRows = false; dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; dgv.BackgroundColor = Color.White;
        dgv.Columns.Add("Voornaam", "Voornaam");
        dgv.Columns.Add("Tussenvoegsel", "Tussenvoegsel");
        dgv.Columns.Add("Achternaam", "Achternaam");
        dgv.Columns.Add("Geboortedatum", "Geboortedatum");
        dgv.Columns.Add("Telefoonnummer", "Telefoonnummer");
        dgv.Columns.Add("E-mailadres", "E-mailadres");
        dgv.Rows.Add("Sanne", "", "Jansen", "12-04-1998", "0612345678", "sanne@example.nl");
        btnToevoegen = new Button(); btnToevoegen.Location = new Point(825,165); btnToevoegen.Size = new Size(120,38); btnToevoegen.Text = "Toevoegen"; btnToevoegen.BackColor = Color.FromArgb(181, 32, 46); btnToevoegen.ForeColor = Color.White; btnToevoegen.FlatStyle = FlatStyle.Flat; btnToevoegen.Click += btnToevoegen_Click;
        btnBewerken = new Button(); btnBewerken.Location = new Point(825,220); btnBewerken.Size = new Size(120,38); btnBewerken.Text = "Bewerken"; btnBewerken.Click += btnBewerken_Click;
        btnVerwijderen = new Button(); btnVerwijderen.Location = new Point(825,275); btnVerwijderen.Size = new Size(120,38); btnVerwijderen.Text = "Verwijderen"; btnVerwijderen.Click += btnVerwijderen_Click;
        lblSub = new Label(); lblSub.Location = new Point(45,405); lblSub.AutoSize = true; lblSub.Font = new Font("Segoe UI", 12F, FontStyle.Bold); lblSub.Text = "Gekoppelde reserveringen";
        dgv2 = new DataGridView(); dgv2.Location = new Point(45,435); dgv2.Size = new Size(760,140); dgv2.ReadOnly = true; dgv2.AllowUserToAddRows = false; dgv2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; dgv2.Columns.Add("Boot","Boot"); dgv2.Columns.Add("Datum","Datum"); dgv2.Columns.Add("Tijd","Tijd"); dgv2.Columns.Add("Status","Status"); dgv2.Rows.Add("Sea Star","15-09-2026","13:00 - 15:00","Actief");
        Controls.AddRange(new Control[] { lblTitel, cmbZoekenOp, txtZoeken, btnZoeken, dgv, btnToevoegen, btnBewerken, btnVerwijderen, lblSub, dgv2 });

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        ClientSize = new Size(1100, 700);
        MinimumSize = new Size(1000, 650);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Klanten beheren";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitel;
    private ComboBox cmbZoekenOp; private TextBox txtZoeken; private Button btnZoeken;
    private DataGridView dgv;
    private Button btnToevoegen;
    private Button btnBewerken;
    private Button btnVerwijderen;
    private Label lblSub; private DataGridView dgv2;

}
