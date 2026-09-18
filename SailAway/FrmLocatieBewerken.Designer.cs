namespace SailAway;

partial class FrmLocatieBewerken
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
        lbl_txtNaam = new Label();
        txtNaam = new TextBox();
        lbl_txtAdres = new Label();
        txtAdres = new TextBox();
        lbl_txtBeschrijving = new Label();
        txtBeschrijving = new TextBox();
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
        lblTitel.Size = new Size(327, 50);
        lblTitel.TabIndex = 0;
        lblTitel.Text = "Locatie bewerken";
        // 
        // lbl_txtNaam
        // 
        lbl_txtNaam.Location = new Point(220, 125);
        lbl_txtNaam.Name = "lbl_txtNaam";
        lbl_txtNaam.Size = new Size(160, 25);
        lbl_txtNaam.TabIndex = 1;
        lbl_txtNaam.Text = "Naam:";
        // 
        // txtNaam
        // 
        txtNaam.Location = new Point(390, 125);
        txtNaam.Name = "txtNaam";
        txtNaam.Size = new Size(310, 30);
        txtNaam.TabIndex = 2;
        // 
        // lbl_txtAdres
        // 
        lbl_txtAdres.Location = new Point(220, 167);
        lbl_txtAdres.Name = "lbl_txtAdres";
        lbl_txtAdres.Size = new Size(160, 25);
        lbl_txtAdres.TabIndex = 3;
        lbl_txtAdres.Text = "Adres:";
        // 
        // txtAdres
        // 
        txtAdres.Location = new Point(390, 167);
        txtAdres.Name = "txtAdres";
        txtAdres.Size = new Size(310, 30);
        txtAdres.TabIndex = 4;
        // 
        // lbl_txtBeschrijving
        // 
        lbl_txtBeschrijving.Location = new Point(220, 209);
        lbl_txtBeschrijving.Name = "lbl_txtBeschrijving";
        lbl_txtBeschrijving.Size = new Size(160, 25);
        lbl_txtBeschrijving.TabIndex = 5;
        lbl_txtBeschrijving.Text = "Beschrijving:";
        // 
        // txtBeschrijving
        // 
        txtBeschrijving.Location = new Point(390, 209);
        txtBeschrijving.Multiline = true;
        txtBeschrijving.Name = "txtBeschrijving";
        txtBeschrijving.Size = new Size(310, 75);
        txtBeschrijving.TabIndex = 6;
        // 
        // btnPrimary
        // 
        btnPrimary.BackColor = Color.FromArgb(181, 32, 46);
        btnPrimary.FlatStyle = FlatStyle.Flat;
        btnPrimary.ForeColor = Color.White;
        btnPrimary.Location = new Point(390, 329);
        btnPrimary.Name = "btnPrimary";
        btnPrimary.Size = new Size(150, 38);
        btnPrimary.TabIndex = 7;
        btnPrimary.Text = "Opslaan";
        btnPrimary.UseVisualStyleBackColor = false;
        // 
        // btnAnnuleren
        // 
        btnAnnuleren.Location = new Point(550, 329);
        btnAnnuleren.Name = "btnAnnuleren";
        btnAnnuleren.Size = new Size(150, 38);
        btnAnnuleren.TabIndex = 8;
        btnAnnuleren.Text = "Annuleren";
        btnAnnuleren.Click += btnAnnuleren_Click;
        // 
        // FrmLocatieBewerken
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        ClientSize = new Size(712, 520);
        Controls.Add(lblTitel);
        Controls.Add(lbl_txtNaam);
        Controls.Add(txtNaam);
        Controls.Add(lbl_txtAdres);
        Controls.Add(txtAdres);
        Controls.Add(lbl_txtBeschrijving);
        Controls.Add(txtBeschrijving);
        Controls.Add(btnPrimary);
        Controls.Add(btnAnnuleren);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimumSize = new Size(640, 480);
        Name = "FrmLocatieBewerken";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Locatie bewerken";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitel;
    private Label lbl_txtNaam; private TextBox txtNaam;
    private Label lbl_txtAdres; private TextBox txtAdres;
    private Label lbl_txtBeschrijving; private TextBox txtBeschrijving;
    private Button btnPrimary,btnAnnuleren;

}
