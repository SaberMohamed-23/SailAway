namespace SailAway;

partial class FrmBootToevoegen
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
        lblTitel.Text = "Boot toevoegen";
        lbl_txtNaam = new Label(); lbl_txtNaam.Location = new Point(220,125); lbl_txtNaam.Size = new Size(160,25); lbl_txtNaam.Text = "Naam:";
        txtNaam = new TextBox(); txtNaam.Location = new Point(390,125); txtNaam.Size = new Size(310,25);
        lbl_txtMerk = new Label(); lbl_txtMerk.Location = new Point(220,167); lbl_txtMerk.Size = new Size(160,25); lbl_txtMerk.Text = "Merk:";
        txtMerk = new TextBox(); txtMerk.Location = new Point(390,167); txtMerk.Size = new Size(310,25);
        lbl_cmbType = new Label(); lbl_cmbType.Location = new Point(220,209); lbl_cmbType.Size = new Size(160,25); lbl_cmbType.Text = "Type:";
        cmbType = new ComboBox(); cmbType.Location = new Point(390,209); cmbType.Size = new Size(310,25); cmbType.DropDownStyle = ComboBoxStyle.DropDownList; cmbType.Items.AddRange(new object[] { "Motorboot", "Zeilboot", "Kano" });
        lbl_nudCapaciteit = new Label(); lbl_nudCapaciteit.Location = new Point(220,251); lbl_nudCapaciteit.Size = new Size(160,25); lbl_nudCapaciteit.Text = "Capaciteit:";
        nudCapaciteit = new NumericUpDown(); nudCapaciteit.Location = new Point(390,251); nudCapaciteit.Size = new Size(150,25); nudCapaciteit.Minimum = 1; nudCapaciteit.Maximum = 100; nudCapaciteit.Value = 1;
        lbl_nudBouwjaar = new Label(); lbl_nudBouwjaar.Location = new Point(220,293); lbl_nudBouwjaar.Size = new Size(160,25); lbl_nudBouwjaar.Text = "Bouwjaar:";
        nudBouwjaar = new NumericUpDown(); nudBouwjaar.Location = new Point(390,293); nudBouwjaar.Size = new Size(150,25); nudBouwjaar.Minimum = 1900; nudBouwjaar.Maximum = 2100; nudBouwjaar.Value = 2026;
        lbl_nudLengte = new Label(); lbl_nudLengte.Location = new Point(220,335); lbl_nudLengte.Size = new Size(160,25); lbl_nudLengte.Text = "Lengte:";
        nudLengte = new NumericUpDown(); nudLengte.Location = new Point(390,335); nudLengte.Size = new Size(150,25); nudLengte.Minimum = 0; nudLengte.Maximum = 100; nudLengte.Value = 5; nudLengte.DecimalPlaces = 2;
        lbl_cmbLocatie = new Label(); lbl_cmbLocatie.Location = new Point(220,377); lbl_cmbLocatie.Size = new Size(160,25); lbl_cmbLocatie.Text = "Locatie:";
        cmbLocatie = new ComboBox(); cmbLocatie.Location = new Point(390,377); cmbLocatie.Size = new Size(310,25); cmbLocatie.DropDownStyle = ComboBoxStyle.DropDownList; cmbLocatie.Items.AddRange(new object[] { "Veghel", "Oss", "'s-Hertogenbosch" });
        lbl_nudPrijs = new Label(); lbl_nudPrijs.Location = new Point(220,419); lbl_nudPrijs.Size = new Size(160,25); lbl_nudPrijs.Text = "Prijs per uur:";
        nudPrijs = new NumericUpDown(); nudPrijs.Location = new Point(390,419); nudPrijs.Size = new Size(150,25); nudPrijs.Minimum = 0; nudPrijs.Maximum = 10000; nudPrijs.Value = 50; nudPrijs.DecimalPlaces = 2;
        lbl_txtOmschrijving = new Label(); lbl_txtOmschrijving.Location = new Point(220,461); lbl_txtOmschrijving.Size = new Size(160,25); lbl_txtOmschrijving.Text = "Omschrijving:";
        txtOmschrijving = new TextBox(); txtOmschrijving.Location = new Point(390,461); txtOmschrijving.Size = new Size(310,75); txtOmschrijving.Multiline = true;
        btnPrimary = new Button(); btnPrimary.Location = new Point(390,581); btnPrimary.Size = new Size(150,38); btnPrimary.Text = "Toevoegen"; btnPrimary.BackColor = Color.FromArgb(181, 32, 46); btnPrimary.ForeColor = Color.White; btnPrimary.FlatStyle = FlatStyle.Flat;
        btnAnnuleren = new Button(); btnAnnuleren.Location = new Point(550,581); btnAnnuleren.Size = new Size(150,38); btnAnnuleren.Text = "Annuleren";
        btnAnnuleren.Click += btnAnnuleren_Click;
        Controls.AddRange(new Control[] { lblTitel, lbl_txtNaam, txtNaam, lbl_txtMerk, txtMerk, lbl_cmbType, cmbType, lbl_nudCapaciteit, nudCapaciteit, lbl_nudBouwjaar, nudBouwjaar, lbl_nudLengte, nudLengte, lbl_cmbLocatie, cmbLocatie, lbl_nudPrijs, nudPrijs, lbl_txtOmschrijving, txtOmschrijving, btnPrimary, btnAnnuleren });

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(984, 611);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Boot toevoegen";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitel;
    private Label lbl_txtNaam; private TextBox txtNaam;
    private Label lbl_txtMerk; private TextBox txtMerk;
    private Label lbl_cmbType; private ComboBox cmbType;
    private Label lbl_nudCapaciteit; private NumericUpDown nudCapaciteit;
    private Label lbl_nudBouwjaar; private NumericUpDown nudBouwjaar;
    private Label lbl_nudLengte; private NumericUpDown nudLengte;
    private Label lbl_cmbLocatie; private ComboBox cmbLocatie;
    private Label lbl_nudPrijs; private NumericUpDown nudPrijs;
    private Label lbl_txtOmschrijving; private TextBox txtOmschrijving;
    private Button btnPrimary,btnAnnuleren;

}
