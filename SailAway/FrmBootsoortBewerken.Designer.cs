namespace SailAway;

partial class FrmBootsoortBewerken
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
        lblTitel.Size = new Size(378, 50);
        lblTitel.TabIndex = 0;
        lblTitel.Text = "Bootsoort bewerken";
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
        // lbl_txtBeschrijving
        // 
        lbl_txtBeschrijving.Location = new Point(220, 167);
        lbl_txtBeschrijving.Name = "lbl_txtBeschrijving";
        lbl_txtBeschrijving.Size = new Size(160, 25);
        lbl_txtBeschrijving.TabIndex = 3;
        lbl_txtBeschrijving.Text = "Beschrijving:";
        // 
        // txtBeschrijving
        // 
        txtBeschrijving.Location = new Point(390, 167);
        txtBeschrijving.Multiline = true;
        txtBeschrijving.Name = "txtBeschrijving";
        txtBeschrijving.Size = new Size(310, 75);
        txtBeschrijving.TabIndex = 4;
        // 
        // btnPrimary
        // 
        btnPrimary.BackColor = Color.FromArgb(181, 32, 46);
        btnPrimary.FlatStyle = FlatStyle.Flat;
        btnPrimary.ForeColor = Color.White;
        btnPrimary.Location = new Point(390, 287);
        btnPrimary.Name = "btnPrimary";
        btnPrimary.Size = new Size(150, 38);
        btnPrimary.TabIndex = 5;
        btnPrimary.Text = "Opslaan";
        btnPrimary.UseVisualStyleBackColor = false;
        // 
        // btnAnnuleren
        // 
        btnAnnuleren.Location = new Point(550, 287);
        btnAnnuleren.Name = "btnAnnuleren";
        btnAnnuleren.Size = new Size(150, 38);
        btnAnnuleren.TabIndex = 6;
        btnAnnuleren.Text = "Annuleren";
        btnAnnuleren.Click += btnAnnuleren_Click;
        // 
        // FrmBootsoortBewerken
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        ClientSize = new Size(806, 542);
        Controls.Add(lblTitel);
        Controls.Add(lbl_txtNaam);
        Controls.Add(txtNaam);
        Controls.Add(lbl_txtBeschrijving);
        Controls.Add(txtBeschrijving);
        Controls.Add(btnPrimary);
        Controls.Add(btnAnnuleren);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimumSize = new Size(640, 480);
        Name = "FrmBootsoortBewerken";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Bootsoort bewerken";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitel;
    private Label lbl_txtNaam; private TextBox txtNaam;
    private Label lbl_txtBeschrijving; private TextBox txtBeschrijving;
    private Button btnPrimary,btnAnnuleren;

}
