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
        lblLogo = new Label();
        lblWelkom = new Label();
        lblBeschrijving = new Label();
        btnBotenBekijken = new Button();
        btnInloggen = new Button();
        btnRegistreren = new Button();
        panel1 = new Panel();
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.BackColor = Color.White;
        menuStrip1.ImageScalingSize = new Size(20, 20);
        menuStrip1.Items.AddRange(new ToolStripItem[] { mnuHome, mnuBoten, mnuReserveringen, mnuAccount });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(982, 28);
        menuStrip1.TabIndex = 0;
        // 
        // mnuHome
        // 
        mnuHome.Name = "mnuHome";
        mnuHome.Size = new Size(64, 24);
        mnuHome.Text = "Home";
        // 
        // mnuBoten
        // 
        mnuBoten.Name = "mnuBoten";
        mnuBoten.Size = new Size(62, 24);
        mnuBoten.Text = "Boten";
        // 
        // mnuReserveringen
        // 
        mnuReserveringen.Name = "mnuReserveringen";
        mnuReserveringen.Size = new Size(145, 24);
        mnuReserveringen.Text = "Mijn reserveringen";
        // 
        // mnuAccount
        // 
        mnuAccount.Name = "mnuAccount";
        mnuAccount.Size = new Size(77, 24);
        mnuAccount.Text = "Account";
        // 
        // lblLogo
        // 
        lblLogo.AutoSize = true;
        lblLogo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        lblLogo.ForeColor = Color.FromArgb(181, 32, 46);
        lblLogo.Location = new Point(395, 95);
        lblLogo.Name = "lblLogo";
        lblLogo.Size = new Size(222, 54);
        lblLogo.TabIndex = 1;
        lblLogo.Text = "SAILAWAY";
        // 
        // lblWelkom
        // 
        lblWelkom.AutoSize = true;
        lblWelkom.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblWelkom.ForeColor = Color.FromArgb(52, 58, 70);
        lblWelkom.Location = new Point(356, 175);
        lblWelkom.Name = "lblWelkom";
        lblWelkom.Size = new Size(315, 41);
        lblWelkom.TabIndex = 2;
        lblWelkom.Text = "Welkom bij SailAway";
        // 
        // lblBeschrijving
        // 
        lblBeschrijving.AutoSize = true;
        lblBeschrijving.Location = new Point(369, 220);
        lblBeschrijving.Name = "lblBeschrijving";
        lblBeschrijving.Size = new Size(310, 23);
        lblBeschrijving.TabIndex = 3;
        lblBeschrijving.Text = "Vind en reserveer eenvoudig jouw boot";
        // 
        // btnBotenBekijken
        // 
        btnBotenBekijken.BackColor = Color.FromArgb(181, 32, 46);
        btnBotenBekijken.FlatStyle = FlatStyle.Flat;
        btnBotenBekijken.ForeColor = Color.White;
        btnBotenBekijken.Location = new Point(392, 285);
        btnBotenBekijken.Name = "btnBotenBekijken";
        btnBotenBekijken.Size = new Size(200, 42);
        btnBotenBekijken.TabIndex = 4;
        btnBotenBekijken.Text = "Boten bekijken";
        btnBotenBekijken.UseVisualStyleBackColor = false;
        btnBotenBekijken.Click += btnBotenBekijken_Click;
        // 
        // btnInloggen
        // 
        btnInloggen.Location = new Point(392, 345);
        btnInloggen.Name = "btnInloggen";
        btnInloggen.Size = new Size(95, 38);
        btnInloggen.TabIndex = 5;
        btnInloggen.Text = "Inloggen";
        btnInloggen.Click += btnInloggen_Click;
        // 
        // btnRegistreren
        // 
        btnRegistreren.Location = new Point(497, 345);
        btnRegistreren.Name = "btnRegistreren";
        btnRegistreren.Size = new Size(120, 38);
        btnRegistreren.TabIndex = 6;
        btnRegistreren.Text = "Registreren";
        btnRegistreren.Click += btnRegistreren_Click;
        // 
        // panel1
        // 
        panel1.Dock = DockStyle.Bottom;
        panel1.Location = new Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(982, 700);
        panel1.TabIndex = 7;
        panel1.Paint += panel1_Paint_1;
        // 
        // FrmStart
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        ClientSize = new Size(982, 700);
        Controls.Add(panel1);
        Controls.Add(menuStrip1);
        Controls.Add(lblLogo);
        Controls.Add(lblWelkom);
        Controls.Add(lblBeschrijving);
        Controls.Add(btnBotenBekijken);
        Controls.Add(btnInloggen);
        Controls.Add(btnRegistreren);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MainMenuStrip = menuStrip1;
        MaximizeBox = false;
        MinimumSize = new Size(1000, 650);
        Name = "FrmStart";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "SailAway Botenverhuur";
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private MenuStrip menuStrip1;
    private ToolStripMenuItem mnuHome;
    private ToolStripMenuItem mnuBoten;
    private ToolStripMenuItem mnuReserveringen;
    private ToolStripMenuItem mnuAccount;
    private Label lblLogo; private Label lblWelkom; private Label lblBeschrijving; private Button btnBotenBekijken; private Button btnInloggen; private Button btnRegistreren;
    private Panel panel1;
}
