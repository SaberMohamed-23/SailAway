namespace SailAway;

partial class FrmBootsoortToevoegen
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
        lblTitel.Text = "Bootsoort toevoegen";
        lbl_txtNaam = new Label(); lbl_txtNaam.Location = new Point(220,125); lbl_txtNaam.Size = new Size(160,25); lbl_txtNaam.Text = "Naam:";
        txtNaam = new TextBox(); txtNaam.Location = new Point(390,125); txtNaam.Size = new Size(310,25);
        lbl_txtBeschrijving = new Label(); lbl_txtBeschrijving.Location = new Point(220,167); lbl_txtBeschrijving.Size = new Size(160,25); lbl_txtBeschrijving.Text = "Beschrijving:";
        txtBeschrijving = new TextBox(); txtBeschrijving.Location = new Point(390,167); txtBeschrijving.Size = new Size(310,75); txtBeschrijving.Multiline = true;
        btnPrimary = new Button(); btnPrimary.Location = new Point(390,287); btnPrimary.Size = new Size(150,38); btnPrimary.Text = "Toevoegen"; btnPrimary.BackColor = Color.FromArgb(181, 32, 46); btnPrimary.ForeColor = Color.White; btnPrimary.FlatStyle = FlatStyle.Flat;
        btnAnnuleren = new Button(); btnAnnuleren.Location = new Point(550,287); btnAnnuleren.Size = new Size(150,38); btnAnnuleren.Text = "Annuleren";
        btnAnnuleren.Click += btnAnnuleren_Click;
        Controls.AddRange(new Control[] { lblTitel, lbl_txtNaam, txtNaam, lbl_txtBeschrijving, txtBeschrijving, btnPrimary, btnAnnuleren });

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(984, 611);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Bootsoort toevoegen";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitel;
    private Label lbl_txtNaam; private TextBox txtNaam;
    private Label lbl_txtBeschrijving; private TextBox txtBeschrijving;
    private Button btnPrimary,btnAnnuleren;

}
