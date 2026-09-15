namespace SailAway;

partial class FrmBoten
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        menuStrip1 = new MenuStrip();
        mnuHome = new ToolStripMenuItem();
        mnuBoten = new ToolStripMenuItem();
        mnuReserveringen = new ToolStripMenuItem();
        mnuAccount = new ToolStripMenuItem();
        menuStrip1.Items.AddRange(new ToolStripItem[] { mnuHome, mnuBoten, mnuReserveringen, mnuAccount });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(984, 24);
        menuStrip1.BackColor = Color.White;
        mnuHome.Text = "Home";
        mnuBoten.Text = "Boten";
        mnuReserveringen.Text = "Mijn reserveringen";
        mnuAccount.Text = "Account";
        lblTitel = new Label();
        lblTitel.AutoSize = true;
        lblTitel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblTitel.ForeColor = Color.FromArgb(52, 58, 70);
        lblTitel.Location = new Point(45, 52);
        lblTitel.Text = "Beschikbare boten";
        lblLocatie = new Label(); cmbLocatie = new ComboBox(); lblDatum = new Label(); dtpDatum = new DateTimePicker(); lblTijd = new Label(); dtpTijd = new DateTimePicker(); lblTypeBoot = new Label(); cmbTypeBoot = new ComboBox(); lblPersonen = new Label(); nudPersonen = new NumericUpDown(); btnZoeken = new Button();
        lblLocatie.Location = new Point(45, 120); lblLocatie.Text = "Locatie:"; cmbLocatie.Location = new Point(45, 145); cmbLocatie.Size = new Size(160, 25); cmbLocatie.DropDownStyle = ComboBoxStyle.DropDownList; cmbLocatie.Items.AddRange(new object[] { "'s-Hertogenbosch", "Oss", "Veghel" });
        lblDatum.Location = new Point(220, 120); lblDatum.Text = "Datum:"; dtpDatum.Location = new Point(220, 145); dtpDatum.Size = new Size(145,25); dtpDatum.Format = DateTimePickerFormat.Short;
        lblTijd.Location = new Point(380,120); lblTijd.Text = "Tijd:"; dtpTijd.Location = new Point(380,145); dtpTijd.Size = new Size(120,25); dtpTijd.Format = DateTimePickerFormat.Time; dtpTijd.ShowUpDown = true;
        lblTypeBoot.Location = new Point(515,120); lblTypeBoot.Text = "Type boot:"; cmbTypeBoot.Location = new Point(515,145); cmbTypeBoot.Size = new Size(145,25); cmbTypeBoot.DropDownStyle = ComboBoxStyle.DropDownList; cmbTypeBoot.Items.AddRange(new object[] { "Motorboot", "Zeilboot", "Kano" });
        lblPersonen.Location = new Point(675,120); lblPersonen.Text = "Aantal personen:"; nudPersonen.Location = new Point(675,145); nudPersonen.Minimum = 1; nudPersonen.Maximum = 20; nudPersonen.Value = 1;
        btnZoeken.Location = new Point(810,140); btnZoeken.Size = new Size(120,35); btnZoeken.Text = "Zoeken"; btnZoeken.BackColor = Color.FromArgb(181, 32, 46); btnZoeken.ForeColor = Color.White; btnZoeken.FlatStyle = FlatStyle.Flat;
        grpBoot1 = new GroupBox(); grpBoot1.Location = new Point(45,205); grpBoot1.Size = new Size(885,75); grpBoot1.Text = "Sea Star"; grpBoot1.BackColor = Color.FromArgb(242, 242, 242);
        lblBoot1 = new Label(); lblBoot1.Location = new Point(18,32); lblBoot1.AutoSize = true; lblBoot1.Text = "Motorboot  |  Veghel  |  6 personen  |  € 60 per uur";
        btnBoot1 = new Button(); btnBoot1.Location = new Point(745,24); btnBoot1.Size = new Size(110,32); btnBoot1.Text = "Bekijken"; btnBoot1.BackColor = Color.FromArgb(181, 32, 46); btnBoot1.ForeColor = Color.White; btnBoot1.FlatStyle = FlatStyle.Flat; btnBoot1.Click += btnBoot_Click; grpBoot1.Controls.AddRange(new Control[] { lblBoot1, btnBoot1 });
        grpBoot2 = new GroupBox(); grpBoot2.Location = new Point(45,300); grpBoot2.Size = new Size(885,75); grpBoot2.Text = "Blue Wave"; grpBoot2.BackColor = Color.FromArgb(242, 242, 242);
        lblBoot2 = new Label(); lblBoot2.Location = new Point(18,32); lblBoot2.AutoSize = true; lblBoot2.Text = "Zeilboot  |  Den Bosch  |  4 personen  |  € 45 per uur";
        btnBoot2 = new Button(); btnBoot2.Location = new Point(745,24); btnBoot2.Size = new Size(110,32); btnBoot2.Text = "Bekijken"; btnBoot2.BackColor = Color.FromArgb(181, 32, 46); btnBoot2.ForeColor = Color.White; btnBoot2.FlatStyle = FlatStyle.Flat; btnBoot2.Click += btnBoot_Click; grpBoot2.Controls.AddRange(new Control[] { lblBoot2, btnBoot2 });
        grpBoot3 = new GroupBox(); grpBoot3.Location = new Point(45,395); grpBoot3.Size = new Size(885,75); grpBoot3.Text = "River One"; grpBoot3.BackColor = Color.FromArgb(242, 242, 242);
        lblBoot3 = new Label(); lblBoot3.Location = new Point(18,32); lblBoot3.AutoSize = true; lblBoot3.Text = "Kano  |  Oss  |  2 personen  |  € 20 per uur";
        btnBoot3 = new Button(); btnBoot3.Location = new Point(745,24); btnBoot3.Size = new Size(110,32); btnBoot3.Text = "Bekijken"; btnBoot3.BackColor = Color.FromArgb(181, 32, 46); btnBoot3.ForeColor = Color.White; btnBoot3.FlatStyle = FlatStyle.Flat; btnBoot3.Click += btnBoot_Click; grpBoot3.Controls.AddRange(new Control[] { lblBoot3, btnBoot3 });
        Controls.AddRange(new Control[] { menuStrip1, lblTitel, lblLocatie, cmbLocatie, lblDatum, dtpDatum, lblTijd, dtpTijd, lblTypeBoot, cmbTypeBoot, lblPersonen, nudPersonen, btnZoeken, grpBoot1, grpBoot2, grpBoot3 }); MainMenuStrip = menuStrip1;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(984, 611);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Boten bekijken";
        ResumeLayout(false);
        PerformLayout();
    }

    private MenuStrip menuStrip1;
    private ToolStripMenuItem mnuHome;
    private ToolStripMenuItem mnuBoten;
    private ToolStripMenuItem mnuReserveringen;
    private ToolStripMenuItem mnuAccount;
    private Label lblTitel;
    private Label lblLocatie,lblDatum,lblTijd,lblTypeBoot,lblPersonen; private ComboBox cmbLocatie,cmbTypeBoot; private DateTimePicker dtpDatum,dtpTijd; private NumericUpDown nudPersonen; private Button btnZoeken; private GroupBox grpBoot1,grpBoot2,grpBoot3; private Label lblBoot1,lblBoot2,lblBoot3; private Button btnBoot1,btnBoot2,btnBoot3;

}
