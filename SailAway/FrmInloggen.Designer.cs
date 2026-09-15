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
        lblTitel.AutoSize = true;
        lblTitel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblTitel.ForeColor = Color.FromArgb(52, 58, 70);
        lblTitel.Location = new Point(45, 52);
        lblTitel.Text = "Inloggen";
        lbl_txtEmail = new Label(); lbl_txtEmail.Location = new Point(220,125); lbl_txtEmail.Size = new Size(160,25); lbl_txtEmail.Text = "E-mailadres:";
        txtEmail = new TextBox(); txtEmail.Location = new Point(390,125); txtEmail.Size = new Size(310,25);
        lbl_txtWachtwoord = new Label(); lbl_txtWachtwoord.Location = new Point(220,167); lbl_txtWachtwoord.Size = new Size(160,25); lbl_txtWachtwoord.Text = "Wachtwoord:";
        txtWachtwoord = new TextBox(); txtWachtwoord.Location = new Point(390,167); txtWachtwoord.Size = new Size(310,25); txtWachtwoord.UseSystemPasswordChar = true;
        btnPrimary = new Button(); btnPrimary.Location = new Point(390,224); btnPrimary.Size = new Size(150,38); btnPrimary.Text = "Inloggen"; btnPrimary.BackColor = Color.FromArgb(181, 32, 46); btnPrimary.ForeColor = Color.White; btnPrimary.FlatStyle = FlatStyle.Flat;
        btnAnnuleren = new Button(); btnAnnuleren.Location = new Point(550,224); btnAnnuleren.Size = new Size(150,38); btnAnnuleren.Text = "Annuleren";
        btnAnnuleren.Click += btnAnnuleren_Click;
        Controls.AddRange(new Control[] { lblTitel, lbl_txtEmail, txtEmail, lbl_txtWachtwoord, txtWachtwoord, btnPrimary, btnAnnuleren });

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(984, 611);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
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
