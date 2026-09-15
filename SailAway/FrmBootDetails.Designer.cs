namespace SailAway;

partial class FrmBootDetails
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
        lblTitel.Text = "Sea Star";
        picBoot = new PictureBox(); picBoot.Location = new Point(60,130); picBoot.Size = new Size(300,230); picBoot.BorderStyle = BorderStyle.FixedSingle; picBoot.BackColor = Color.FromArgb(242, 242, 242);
        lblAfbeelding = new Label(); lblAfbeelding.AutoSize = true; lblAfbeelding.Location = new Point(155,235); lblAfbeelding.Text = "Afbeelding boot"; picBoot.Controls.Add(lblAfbeelding);
        lblInfo = new Label(); lblInfo.Location = new Point(420,130); lblInfo.Size = new Size(440,220); lblInfo.Text = "Type:        Motorboot\n\nLocatie:     Veghel\n\nCapaciteit:  6 personen\n\nBouwjaar:    2021\n\nLengte:      7,5 meter\n\nPrijs:       € 60 per uur";
        lblOmschrijvingTitel = new Label(); lblOmschrijvingTitel.Location = new Point(420,365); lblOmschrijvingTitel.AutoSize = true; lblOmschrijvingTitel.Font = new Font("Segoe UI",10F,FontStyle.Bold); lblOmschrijvingTitel.Text = "Omschrijving:";
        txtOmschrijving = new TextBox(); txtOmschrijving.Location = new Point(420,390); txtOmschrijving.Size = new Size(380,75); txtOmschrijving.Multiline = true; txtOmschrijving.ReadOnly = true; txtOmschrijving.Text = "Comfortabele motorboot voor een ontspannen dag op het water.";
        btnReserveren = new Button(); btnReserveren.Location = new Point(420,490); btnReserveren.Size = new Size(150,40); btnReserveren.Text = "Reserveren"; btnReserveren.BackColor = Color.FromArgb(181, 32, 46); btnReserveren.ForeColor = Color.White; btnReserveren.FlatStyle = FlatStyle.Flat; btnReserveren.Click += btnReserveren_Click;
        btnTerug = new Button(); btnTerug.Location = new Point(585,490); btnTerug.Size = new Size(110,40); btnTerug.Text = "Terug";
        btnTerug.Click += btnTerug_Click;
        Controls.AddRange(new Control[] { menuStrip1, lblTitel, picBoot, lblInfo, lblOmschrijvingTitel, txtOmschrijving, btnReserveren, btnTerug }); MainMenuStrip = menuStrip1;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(984, 611);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Boot bekijken";
        ResumeLayout(false);
        PerformLayout();
    }

    private MenuStrip menuStrip1;
    private ToolStripMenuItem mnuHome;
    private ToolStripMenuItem mnuBoten;
    private ToolStripMenuItem mnuReserveringen;
    private ToolStripMenuItem mnuAccount;
    private Label lblTitel;
    private PictureBox picBoot; private Label lblAfbeelding,lblInfo,lblOmschrijvingTitel; private TextBox txtOmschrijving; private Button btnReserveren,btnTerug;

}
