namespace SailAway;

partial class FrmKlantBewerken
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
        lblTitel.Text = "Klant bewerken";
        lbl_txtVoornaam = new Label(); lbl_txtVoornaam.Location = new Point(220,125); lbl_txtVoornaam.Size = new Size(160,25); lbl_txtVoornaam.Text = "Voornaam:";
        txtVoornaam = new TextBox(); txtVoornaam.Location = new Point(390,125); txtVoornaam.Size = new Size(310,25);
        lbl_txtTussenvoegsel = new Label(); lbl_txtTussenvoegsel.Location = new Point(220,167); lbl_txtTussenvoegsel.Size = new Size(160,25); lbl_txtTussenvoegsel.Text = "Tussenvoegsel:";
        txtTussenvoegsel = new TextBox(); txtTussenvoegsel.Location = new Point(390,167); txtTussenvoegsel.Size = new Size(310,25);
        lbl_txtAchternaam = new Label(); lbl_txtAchternaam.Location = new Point(220,209); lbl_txtAchternaam.Size = new Size(160,25); lbl_txtAchternaam.Text = "Achternaam:";
        txtAchternaam = new TextBox(); txtAchternaam.Location = new Point(390,209); txtAchternaam.Size = new Size(310,25);
        lbl_dtpGeboortedatum = new Label(); lbl_dtpGeboortedatum.Location = new Point(220,251); lbl_dtpGeboortedatum.Size = new Size(160,25); lbl_dtpGeboortedatum.Text = "Geboortedatum:";
        dtpGeboortedatum = new DateTimePicker(); dtpGeboortedatum.Location = new Point(390,251); dtpGeboortedatum.Size = new Size(310,25); dtpGeboortedatum.Format = DateTimePickerFormat.Short;
        lbl_txtTelefoonnummer = new Label(); lbl_txtTelefoonnummer.Location = new Point(220,293); lbl_txtTelefoonnummer.Size = new Size(160,25); lbl_txtTelefoonnummer.Text = "Telefoonnummer:";
        txtTelefoonnummer = new TextBox(); txtTelefoonnummer.Location = new Point(390,293); txtTelefoonnummer.Size = new Size(310,25);
        lbl_txtEmail = new Label(); lbl_txtEmail.Location = new Point(220,335); lbl_txtEmail.Size = new Size(160,25); lbl_txtEmail.Text = "E-mailadres:";
        txtEmail = new TextBox(); txtEmail.Location = new Point(390,335); txtEmail.Size = new Size(310,25);
        btnPrimary = new Button(); btnPrimary.Location = new Point(390,392); btnPrimary.Size = new Size(150,38); btnPrimary.Text = "Opslaan"; btnPrimary.BackColor = Color.FromArgb(181, 32, 46); btnPrimary.ForeColor = Color.White; btnPrimary.FlatStyle = FlatStyle.Flat;
        btnAnnuleren = new Button(); btnAnnuleren.Location = new Point(550,392); btnAnnuleren.Size = new Size(150,38); btnAnnuleren.Text = "Annuleren";
        btnAnnuleren.Click += btnAnnuleren_Click;
        Controls.AddRange(new Control[] { lblTitel, lbl_txtVoornaam, txtVoornaam, lbl_txtTussenvoegsel, txtTussenvoegsel, lbl_txtAchternaam, txtAchternaam, lbl_dtpGeboortedatum, dtpGeboortedatum, lbl_txtTelefoonnummer, txtTelefoonnummer, lbl_txtEmail, txtEmail, btnPrimary, btnAnnuleren });

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(984, 611);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Klant bewerken";
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
    private Button btnPrimary,btnAnnuleren;

}
