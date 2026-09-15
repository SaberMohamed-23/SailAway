namespace SailAway;

partial class FrmStart
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
        lblLogo = new Label();
        lblWelkom = new Label();
        lblBeschrijving = new Label();
        btnBotenBekijken = new Button();
        btnInloggen = new Button();
        btnRegistreren = new Button();
        lblLogo.AutoSize = true; lblLogo.Font = new Font("Segoe UI", 24F, FontStyle.Bold); lblLogo.ForeColor = Color.FromArgb(181, 32, 46); lblLogo.Location = new Point(395, 95); lblLogo.Text = "SAILAWAY";
        lblWelkom.AutoSize = true; lblWelkom.Font = new Font("Segoe UI", 18F, FontStyle.Bold); lblWelkom.ForeColor = Color.FromArgb(52, 58, 70); lblWelkom.Location = new Point(356, 175); lblWelkom.Text = "Welkom bij SailAway";
        lblBeschrijving.AutoSize = true; lblBeschrijving.Location = new Point(369, 220); lblBeschrijving.Text = "Vind en reserveer eenvoudig jouw boot";
        btnBotenBekijken.Location = new Point(392, 285); btnBotenBekijken.Size = new Size(200, 42); btnBotenBekijken.Text = "Boten bekijken"; btnBotenBekijken.BackColor = Color.FromArgb(181, 32, 46); btnBotenBekijken.ForeColor = Color.White; btnBotenBekijken.FlatStyle = FlatStyle.Flat; btnBotenBekijken.Click += btnBotenBekijken_Click;
        btnInloggen.Location = new Point(392, 345); btnInloggen.Size = new Size(95, 38); btnInloggen.Text = "Inloggen"; btnInloggen.Click += btnInloggen_Click;
        btnRegistreren.Location = new Point(497, 345); btnRegistreren.Size = new Size(95, 38); btnRegistreren.Text = "Registreren"; btnRegistreren.Click += btnRegistreren_Click;
        Controls.AddRange(new Control[] { menuStrip1, lblLogo, lblWelkom, lblBeschrijving, btnBotenBekijken, btnInloggen, btnRegistreren });
        MainMenuStrip = menuStrip1;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(984, 611);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "SailAway Botenverhuur";
        ResumeLayout(false);
        PerformLayout();
    }

    private MenuStrip menuStrip1;
    private ToolStripMenuItem mnuHome;
    private ToolStripMenuItem mnuBoten;
    private ToolStripMenuItem mnuReserveringen;
    private ToolStripMenuItem mnuAccount;
    private Label lblLogo; private Label lblWelkom; private Label lblBeschrijving; private Button btnBotenBekijken; private Button btnInloggen; private Button btnRegistreren;

}
