namespace SailAway;

partial class FrmRegistreren
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
        lbl_txtVoornaam = new Label();
        txtVoornaam = new TextBox();
        lbl_txtTussenvoegsel = new Label();
        txtTussenvoegsel = new TextBox();
        lbl_txtAchternaam = new Label();
        txtAchternaam = new TextBox();
        lbl_dtpGeboortedatum = new Label();
        dtpGeboortedatum = new DateTimePicker();
        lbl_txtTelefoonnummer = new Label();
        txtTelefoonnummer = new TextBox();
        lbl_txtEmail = new Label();
        txtEmail = new TextBox();
        lbl_txtWachtwoord = new Label();
        txtWachtwoord = new TextBox();
        lbl_txtWachtwoordHerhalen = new Label();
        txtWachtwoordHerhalen = new TextBox();
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
        lblTitel.Size = new Size(221, 50);
        lblTitel.TabIndex = 0;
        lblTitel.Text = "Registreren";
        // 
        // lbl_txtVoornaam
        // 
        lbl_txtVoornaam.Location = new Point(220, 125);
        lbl_txtVoornaam.Name = "lbl_txtVoornaam";
        lbl_txtVoornaam.Size = new Size(160, 25);
        lbl_txtVoornaam.TabIndex = 1;
        lbl_txtVoornaam.Text = "Voornaam:";
        // 
        // txtVoornaam
        // 
        txtVoornaam.Location = new Point(390, 125);
        txtVoornaam.Name = "txtVoornaam";
        txtVoornaam.Size = new Size(310, 30);
        txtVoornaam.TabIndex = 2;
        // 
        // lbl_txtTussenvoegsel
        // 
        lbl_txtTussenvoegsel.Location = new Point(220, 167);
        lbl_txtTussenvoegsel.Name = "lbl_txtTussenvoegsel";
        lbl_txtTussenvoegsel.Size = new Size(160, 25);
        lbl_txtTussenvoegsel.TabIndex = 3;
        lbl_txtTussenvoegsel.Text = "Tussenvoegsel:";
        // 
        // txtTussenvoegsel
        // 
        txtTussenvoegsel.Location = new Point(390, 167);
        txtTussenvoegsel.Name = "txtTussenvoegsel";
        txtTussenvoegsel.Size = new Size(310, 30);
        txtTussenvoegsel.TabIndex = 4;
        // 
        // lbl_txtAchternaam
        // 
        lbl_txtAchternaam.Location = new Point(220, 209);
        lbl_txtAchternaam.Name = "lbl_txtAchternaam";
        lbl_txtAchternaam.Size = new Size(160, 25);
        lbl_txtAchternaam.TabIndex = 5;
        lbl_txtAchternaam.Text = "Achternaam:";
        // 
        // txtAchternaam
        // 
        txtAchternaam.Location = new Point(390, 209);
        txtAchternaam.Name = "txtAchternaam";
        txtAchternaam.Size = new Size(310, 30);
        txtAchternaam.TabIndex = 6;
        // 
        // lbl_dtpGeboortedatum
        // 
        lbl_dtpGeboortedatum.Location = new Point(220, 251);
        lbl_dtpGeboortedatum.Name = "lbl_dtpGeboortedatum";
        lbl_dtpGeboortedatum.Size = new Size(160, 25);
        lbl_dtpGeboortedatum.TabIndex = 7;
        lbl_dtpGeboortedatum.Text = "Geboortedatum:";
        // 
        // dtpGeboortedatum
        // 
        dtpGeboortedatum.Format = DateTimePickerFormat.Short;
        dtpGeboortedatum.Location = new Point(390, 251);
        dtpGeboortedatum.Name = "dtpGeboortedatum";
        dtpGeboortedatum.Size = new Size(310, 30);
        dtpGeboortedatum.TabIndex = 8;
        // 
        // lbl_txtTelefoonnummer
        // 
        lbl_txtTelefoonnummer.Location = new Point(220, 293);
        lbl_txtTelefoonnummer.Name = "lbl_txtTelefoonnummer";
        lbl_txtTelefoonnummer.Size = new Size(160, 25);
        lbl_txtTelefoonnummer.TabIndex = 9;
        lbl_txtTelefoonnummer.Text = "Telefoonnummer:";
        // 
        // txtTelefoonnummer
        // 
        txtTelefoonnummer.Location = new Point(390, 293);
        txtTelefoonnummer.Name = "txtTelefoonnummer";
        txtTelefoonnummer.Size = new Size(310, 30);
        txtTelefoonnummer.TabIndex = 10;
        // 
        // lbl_txtEmail
        // 
        lbl_txtEmail.Location = new Point(220, 335);
        lbl_txtEmail.Name = "lbl_txtEmail";
        lbl_txtEmail.Size = new Size(160, 25);
        lbl_txtEmail.TabIndex = 11;
        lbl_txtEmail.Text = "E-mailadres:";
        // 
        // txtEmail
        // 
        txtEmail.Location = new Point(390, 335);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(310, 30);
        txtEmail.TabIndex = 12;
        // 
        // lbl_txtWachtwoord
        // 
        lbl_txtWachtwoord.Location = new Point(220, 377);
        lbl_txtWachtwoord.Name = "lbl_txtWachtwoord";
        lbl_txtWachtwoord.Size = new Size(160, 25);
        lbl_txtWachtwoord.TabIndex = 13;
        lbl_txtWachtwoord.Text = "Wachtwoord:";
        // 
        // txtWachtwoord
        // 
        txtWachtwoord.Location = new Point(390, 377);
        txtWachtwoord.Name = "txtWachtwoord";
        txtWachtwoord.Size = new Size(310, 30);
        txtWachtwoord.TabIndex = 14;
        txtWachtwoord.UseSystemPasswordChar = true;
        // 
        // lbl_txtWachtwoordHerhalen
        // 
        lbl_txtWachtwoordHerhalen.Location = new Point(186, 419);
        lbl_txtWachtwoordHerhalen.Name = "lbl_txtWachtwoordHerhalen";
        lbl_txtWachtwoordHerhalen.Size = new Size(194, 25);
        lbl_txtWachtwoordHerhalen.TabIndex = 15;
        lbl_txtWachtwoordHerhalen.Text = "Wachtwoord herhalen:";
        // 
        // txtWachtwoordHerhalen
        // 
        txtWachtwoordHerhalen.Location = new Point(390, 419);
        txtWachtwoordHerhalen.Name = "txtWachtwoordHerhalen";
        txtWachtwoordHerhalen.Size = new Size(310, 30);
        txtWachtwoordHerhalen.TabIndex = 16;
        txtWachtwoordHerhalen.UseSystemPasswordChar = true;
        // 
        // btnPrimary
        // 
        btnPrimary.BackColor = Color.FromArgb(181, 32, 46);
        btnPrimary.FlatStyle = FlatStyle.Flat;
        btnPrimary.ForeColor = Color.White;
        btnPrimary.Location = new Point(390, 476);
        btnPrimary.Name = "btnPrimary";
        btnPrimary.Size = new Size(150, 38);
        btnPrimary.TabIndex = 17;
        btnPrimary.Text = "Registreren";
        btnPrimary.UseVisualStyleBackColor = false;
        // 
        // btnAnnuleren
        // 
        btnAnnuleren.Location = new Point(550, 476);
        btnAnnuleren.Name = "btnAnnuleren";
        btnAnnuleren.Size = new Size(150, 38);
        btnAnnuleren.TabIndex = 18;
        btnAnnuleren.Text = "Annuleren";
        btnAnnuleren.Click += btnAnnuleren_Click;
        // 
        // FrmRegistreren
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        ClientSize = new Size(717, 520);
        Controls.Add(lblTitel);
        Controls.Add(lbl_txtVoornaam);
        Controls.Add(txtVoornaam);
        Controls.Add(lbl_txtTussenvoegsel);
        Controls.Add(txtTussenvoegsel);
        Controls.Add(lbl_txtAchternaam);
        Controls.Add(txtAchternaam);
        Controls.Add(lbl_dtpGeboortedatum);
        Controls.Add(dtpGeboortedatum);
        Controls.Add(lbl_txtTelefoonnummer);
        Controls.Add(txtTelefoonnummer);
        Controls.Add(lbl_txtEmail);
        Controls.Add(txtEmail);
        Controls.Add(lbl_txtWachtwoord);
        Controls.Add(txtWachtwoord);
        Controls.Add(lbl_txtWachtwoordHerhalen);
        Controls.Add(txtWachtwoordHerhalen);
        Controls.Add(btnPrimary);
        Controls.Add(btnAnnuleren);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimumSize = new Size(640, 480);
        Name = "FrmRegistreren";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Registreren";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitel;
    private Label lbl_txtVoornaam; private TextBox txtVoornaam;
    private Label lbl_txtTussenvoegsel; private TextBox txtTussenvoegsel;
    private Label lbl_txtAchternaam; private TextBox txtAchternaam;
    private Label lbl_dtpGeboortedatum; private DateTimePicker dtpGeboortedatum;
    private Label lbl_txtTelefoonnummer; private TextBox txtTelefoonnummer;
    private Label lbl_txtEmail; private TextBox txtEmail;
    private Label lbl_txtWachtwoord; private TextBox txtWachtwoord;
    private Label lbl_txtWachtwoordHerhalen; private TextBox txtWachtwoordHerhalen;
    private Button btnPrimary,btnAnnuleren;

}
