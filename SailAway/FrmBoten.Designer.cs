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
        this.menuStrip1 = new MenuStrip();
        this.mnuHome = new ToolStripMenuItem();
        this.mnuBoten = new ToolStripMenuItem();
        this.mnuReserveringen = new ToolStripMenuItem();
        this.mnuAccount = new ToolStripMenuItem();

        this.lblTitel = new Label();

        this.lblLocatie = new Label();
        this.cmbLocatie = new ComboBox();

        this.lblTypeBoot = new Label();
        this.cmbTypeBoot = new ComboBox();

        this.lblSorteer = new Label();
        this.cmbSorteer = new ComboBox();

        this.btnZoeken = new Button();

        this.SuspendLayout();

        // 
        // menuStrip1
        // 
        this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.mnuHome, this.mnuBoten, this.mnuReserveringen, this.mnuAccount });
        this.menuStrip1.Location = new Point(0, 0);
        this.menuStrip1.Name = "menuStrip1";
        this.menuStrip1.Size = new Size(984, 24);
        this.menuStrip1.BackColor = Color.White;

        this.mnuHome.Text = "Home";
        this.mnuBoten.Text = "Boten";
        this.mnuReserveringen.Text = "Mijn reserveringen";
        this.mnuAccount.Text = "Account";

        // 
        // lblTitel
        // 
        this.lblTitel.AutoSize = true;
        this.lblTitel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        this.lblTitel.ForeColor = Color.FromArgb(52, 58, 70);
        this.lblTitel.Location = new Point(45, 52);
        this.lblTitel.Text = "Beschikbare boten";

        // 
        // Filters & Controls
        // 
        this.lblLocatie.Location = new Point(45, 120);
        this.lblLocatie.AutoSize = true;
        this.lblLocatie.Text = "Locatie:";

        this.cmbLocatie.Location = new Point(45, 145);
        this.cmbLocatie.Size = new Size(200, 25);
        this.cmbLocatie.DropDownStyle = ComboBoxStyle.DropDownList;

        this.lblTypeBoot.Location = new Point(270, 120);
        this.lblTypeBoot.AutoSize = true;
        this.lblTypeBoot.Text = "Type boot:";

        this.cmbTypeBoot.Location = new Point(270, 145);
        this.cmbTypeBoot.Size = new Size(200, 25);
        this.cmbTypeBoot.DropDownStyle = ComboBoxStyle.DropDownList;

        this.lblSorteer.Location = new Point(495, 120);
        this.lblSorteer.AutoSize = true;
        this.lblSorteer.Text = "Sorteren op:";

        this.cmbSorteer.Location = new Point(495, 145);
        this.cmbSorteer.Size = new Size(200, 25);
        this.cmbSorteer.DropDownStyle = ComboBoxStyle.DropDownList;

        // Zoek knop
        this.btnZoeken.Location = new Point(720, 140);
        this.btnZoeken.Size = new Size(120, 32);
        this.btnZoeken.Text = "Zoeken";
        this.btnZoeken.BackColor = Color.FromArgb(181, 32, 46);
        this.btnZoeken.ForeColor = Color.White;
        this.btnZoeken.FlatStyle = FlatStyle.Flat;

        // 
        // Form Settings
        // 
        this.Controls.AddRange(new Control[] {
            this.menuStrip1, this.lblTitel,
            this.lblLocatie, this.cmbLocatie,
            this.lblTypeBoot, this.cmbTypeBoot,
            this.lblSorteer, this.cmbSorteer,
            this.btnZoeken
        });

        this.MainMenuStrip = this.menuStrip1;

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = Color.White;
        this.ClientSize = new Size(984, 611);
        this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        this.FormBorderStyle = FormBorderStyle.FixedSingle; // Gecorrigeerd!
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Boten bekijken";

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private MenuStrip menuStrip1;
    private ToolStripMenuItem mnuHome;
    private ToolStripMenuItem mnuBoten;
    private ToolStripMenuItem mnuReserveringen;
    private ToolStripMenuItem mnuAccount;

    private Label lblTitel;
    private Label lblLocatie;
    private ComboBox cmbLocatie;
    private Label lblTypeBoot;
    private ComboBox cmbTypeBoot;
    private Label lblSorteer;
    private ComboBox cmbSorteer;
    private Button btnZoeken;
}