namespace SailAway;

partial class FrmInloggen
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
        lbl_txtEmail = new Label();
        txtEmail = new TextBox();
        lbl_txtWachtwoord = new Label();
        txtWachtwoord = new TextBox();
        btnPrimary = new Button();
        btnAnnuleren = new Button();
        SuspendLayout();
        // 
        // lblTitel
        // 
        lblTitel.AutoSize = true;
        lblTitel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblTitel.ForeColor = Color.FromArgb(52, 58, 70);
        lblTitel.Location = new Point(45, 52);
        lblTitel.Name = "lblTitel";
        lblTitel.Size = new Size(178, 50);
        lblTitel.TabIndex = 0;
        lblTitel.Text = "Inloggen";
        // 
        // lbl_txtEmail
        // 
        lbl_txtEmail.Location = new Point(220, 125);
        lbl_txtEmail.Name = "lbl_txtEmail";
        lbl_txtEmail.Size = new Size(160, 25);
        lbl_txtEmail.TabIndex = 1;
        lbl_txtEmail.Text = "E-mailadres:";
        // 
        // txtEmail
        // 
        txtEmail.Location = new Point(390, 125);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(310, 30);
        txtEmail.TabIndex = 2;
        // 
        // lbl_txtWachtwoord
        // 
        lbl_txtWachtwoord.Location = new Point(220, 167);
        lbl_txtWachtwoord.Name = "lbl_txtWachtwoord";
        lbl_txtWachtwoord.Size = new Size(160, 25);
        lbl_txtWachtwoord.TabIndex = 3;
        lbl_txtWachtwoord.Text = "Wachtwoord:";
        // 
        // txtWachtwoord
        // 
        txtWachtwoord.Location = new Point(390, 167);
        txtWachtwoord.Name = "txtWachtwoord";
        txtWachtwoord.Size = new Size(310, 30);
        txtWachtwoord.TabIndex = 4;
        txtWachtwoord.UseSystemPasswordChar = true;
        // 
        // btnPrimary
        // 
        btnPrimary.BackColor = Color.FromArgb(181, 32, 46);
        btnPrimary.FlatStyle = FlatStyle.Flat;
        btnPrimary.ForeColor = Color.White;
        btnPrimary.Location = new Point(390, 224);
        btnPrimary.Name = "btnPrimary";
        btnPrimary.Size = new Size(150, 38);
        btnPrimary.TabIndex = 5;
        btnPrimary.Text = "Inloggen";
        btnPrimary.UseVisualStyleBackColor = false;
        // 
        // btnAnnuleren
        // 
        btnAnnuleren.Location = new Point(550, 224);
        btnAnnuleren.Name = "btnAnnuleren";
        btnAnnuleren.Size = new Size(150, 38);
        btnAnnuleren.TabIndex = 6;
        btnAnnuleren.Text = "Annuleren";
        btnAnnuleren.Click += btnAnnuleren_Click;
        // 
        // FrmInloggen
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        ClientSize = new Size(896, 520);
        Controls.Add(lblTitel);
        Controls.Add(lbl_txtEmail);
        Controls.Add(txtEmail);
        Controls.Add(lbl_txtWachtwoord);
        Controls.Add(txtWachtwoord);
        Controls.Add(btnPrimary);
        Controls.Add(btnAnnuleren);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimumSize = new Size(640, 480);
        Name = "FrmInloggen";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Inloggen";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitel;
    private Label lbl_txtEmail; private TextBox txtEmail;
    private Label lbl_txtWachtwoord; private TextBox txtWachtwoord;
    private Button btnPrimary,btnAnnuleren;

}
