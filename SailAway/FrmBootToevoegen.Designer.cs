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
        lbl_txtNaam = new Label();
        txtNaam = new TextBox();
        lbl_txtMerk = new Label();
        txtMerk = new TextBox();
        lbl_cmbType = new Label();
        cmbType = new ComboBox();
        lbl_nudCapaciteit = new Label();
        nudCapaciteit = new NumericUpDown();
        lbl_nudBouwjaar = new Label();
        nudBouwjaar = new NumericUpDown();
        lbl_nudLengte = new Label();
        nudLengte = new NumericUpDown();
        lbl_cmbLocatie = new Label();
        cmbLocatie = new ComboBox();
        lbl_nudPrijs = new Label();
        nudPrijs = new NumericUpDown();
        lbl_txtOmschrijving = new Label();
        txtOmschrijving = new TextBox();
        btnPrimary = new Button();
        btnAnnuleren = new Button();
        ((System.ComponentModel.ISupportInitialize)nudCapaciteit).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudBouwjaar).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudLengte).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudPrijs).BeginInit();
        SuspendLayout();
        // 
        // lblTitel
        // 
        lblTitel.AutoSize = true;
        lblTitel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblTitel.ForeColor = Color.FromArgb(52, 58, 70);
        lblTitel.Location = new Point(45, 52);
        lblTitel.Name = "lblTitel";
        lblTitel.Size = new Size(301, 50);
        lblTitel.TabIndex = 0;
        lblTitel.Text = "Boot toevoegen";
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
        // lbl_txtMerk
        // 
        lbl_txtMerk.Location = new Point(220, 167);
        lbl_txtMerk.Name = "lbl_txtMerk";
        lbl_txtMerk.Size = new Size(160, 25);
        lbl_txtMerk.TabIndex = 3;
        lbl_txtMerk.Text = "Merk:";
        // 
        // txtMerk
        // 
        txtMerk.Location = new Point(390, 167);
        txtMerk.Name = "txtMerk";
        txtMerk.Size = new Size(310, 30);
        txtMerk.TabIndex = 4;
        // 
        // lbl_cmbType
        // 
        lbl_cmbType.Location = new Point(220, 209);
        lbl_cmbType.Name = "lbl_cmbType";
        lbl_cmbType.Size = new Size(160, 25);
        lbl_cmbType.TabIndex = 5;
        lbl_cmbType.Text = "Type:";
        // 
        // cmbType
        // 
        cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbType.Items.AddRange(new object[] { "Motorboot", "Zeilboot", "Kano" });
        cmbType.Location = new Point(390, 209);
        cmbType.Name = "cmbType";
        cmbType.Size = new Size(310, 31);
        cmbType.TabIndex = 6;
        // 
        // lbl_nudCapaciteit
        // 
        lbl_nudCapaciteit.Location = new Point(220, 251);
        lbl_nudCapaciteit.Name = "lbl_nudCapaciteit";
        lbl_nudCapaciteit.Size = new Size(160, 25);
        lbl_nudCapaciteit.TabIndex = 7;
        lbl_nudCapaciteit.Text = "Capaciteit:";
        // 
        // nudCapaciteit
        // 
        nudCapaciteit.Location = new Point(390, 251);
        nudCapaciteit.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudCapaciteit.Name = "nudCapaciteit";
        nudCapaciteit.Size = new Size(150, 30);
        nudCapaciteit.TabIndex = 8;
        nudCapaciteit.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // lbl_nudBouwjaar
        // 
        lbl_nudBouwjaar.Location = new Point(220, 293);
        lbl_nudBouwjaar.Name = "lbl_nudBouwjaar";
        lbl_nudBouwjaar.Size = new Size(160, 25);
        lbl_nudBouwjaar.TabIndex = 9;
        lbl_nudBouwjaar.Text = "Bouwjaar:";
        // 
        // nudBouwjaar
        // 
        nudBouwjaar.Location = new Point(390, 293);
        nudBouwjaar.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
        nudBouwjaar.Minimum = new decimal(new int[] { 1900, 0, 0, 0 });
        nudBouwjaar.Name = "nudBouwjaar";
        nudBouwjaar.Size = new Size(150, 30);
        nudBouwjaar.TabIndex = 10;
        nudBouwjaar.Value = new decimal(new int[] { 2026, 0, 0, 0 });
        // 
        // lbl_nudLengte
        // 
        lbl_nudLengte.Location = new Point(220, 335);
        lbl_nudLengte.Name = "lbl_nudLengte";
        lbl_nudLengte.Size = new Size(160, 25);
        lbl_nudLengte.TabIndex = 11;
        lbl_nudLengte.Text = "Lengte:";
        // 
        // nudLengte
        // 
        nudLengte.DecimalPlaces = 2;
        nudLengte.Location = new Point(390, 335);
        nudLengte.Name = "nudLengte";
        nudLengte.Size = new Size(150, 30);
        nudLengte.TabIndex = 12;
        nudLengte.Value = new decimal(new int[] { 5, 0, 0, 0 });
        // 
        // lbl_cmbLocatie
        // 
        lbl_cmbLocatie.Location = new Point(220, 377);
        lbl_cmbLocatie.Name = "lbl_cmbLocatie";
        lbl_cmbLocatie.Size = new Size(160, 25);
        lbl_cmbLocatie.TabIndex = 13;
        lbl_cmbLocatie.Text = "Locatie:";
        // 
        // cmbLocatie
        // 
        cmbLocatie.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbLocatie.Items.AddRange(new object[] { "Veghel", "Oss", "'s-Hertogenbosch" });
        cmbLocatie.Location = new Point(390, 377);
        cmbLocatie.Name = "cmbLocatie";
        cmbLocatie.Size = new Size(310, 31);
        cmbLocatie.TabIndex = 14;
        // 
        // lbl_nudPrijs
        // 
        lbl_nudPrijs.Location = new Point(220, 419);
        lbl_nudPrijs.Name = "lbl_nudPrijs";
        lbl_nudPrijs.Size = new Size(160, 25);
        lbl_nudPrijs.TabIndex = 15;
        lbl_nudPrijs.Text = "Prijs per uur:";
        // 
        // nudPrijs
        // 
        nudPrijs.DecimalPlaces = 2;
        nudPrijs.Location = new Point(390, 419);
        nudPrijs.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        nudPrijs.Name = "nudPrijs";
        nudPrijs.Size = new Size(150, 30);
        nudPrijs.TabIndex = 16;
        nudPrijs.Value = new decimal(new int[] { 50, 0, 0, 0 });
        // 
        // lbl_txtOmschrijving
        // 
        lbl_txtOmschrijving.Location = new Point(220, 461);
        lbl_txtOmschrijving.Name = "lbl_txtOmschrijving";
        lbl_txtOmschrijving.Size = new Size(160, 25);
        lbl_txtOmschrijving.TabIndex = 17;
        lbl_txtOmschrijving.Text = "Omschrijving:";
        // 
        // txtOmschrijving
        // 
        txtOmschrijving.Location = new Point(390, 461);
        txtOmschrijving.Multiline = true;
        txtOmschrijving.Name = "txtOmschrijving";
        txtOmschrijving.Size = new Size(310, 75);
        txtOmschrijving.TabIndex = 18;
        // 
        // btnPrimary
        // 
        btnPrimary.BackColor = Color.FromArgb(181, 32, 46);
        btnPrimary.FlatStyle = FlatStyle.Flat;
        btnPrimary.ForeColor = Color.White;
        btnPrimary.Location = new Point(390, 581);
        btnPrimary.Name = "btnPrimary";
        btnPrimary.Size = new Size(150, 38);
        btnPrimary.TabIndex = 19;
        btnPrimary.Text = "Toevoegen";
        btnPrimary.UseVisualStyleBackColor = false;
        // 
        // btnAnnuleren
        // 
        btnAnnuleren.Location = new Point(550, 581);
        btnAnnuleren.Name = "btnAnnuleren";
        btnAnnuleren.Size = new Size(150, 38);
        btnAnnuleren.TabIndex = 20;
        btnAnnuleren.Text = "Annuleren";
        btnAnnuleren.Click += btnAnnuleren_Click;
        // 
        // FrmBootToevoegen
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        ClientSize = new Size(951, 640);
        Controls.Add(lblTitel);
        Controls.Add(lbl_txtNaam);
        Controls.Add(txtNaam);
        Controls.Add(lbl_txtMerk);
        Controls.Add(txtMerk);
        Controls.Add(lbl_cmbType);
        Controls.Add(cmbType);
        Controls.Add(lbl_nudCapaciteit);
        Controls.Add(nudCapaciteit);
        Controls.Add(lbl_nudBouwjaar);
        Controls.Add(nudBouwjaar);
        Controls.Add(lbl_nudLengte);
        Controls.Add(nudLengte);
        Controls.Add(lbl_cmbLocatie);
        Controls.Add(cmbLocatie);
        Controls.Add(lbl_nudPrijs);
        Controls.Add(nudPrijs);
        Controls.Add(lbl_txtOmschrijving);
        Controls.Add(txtOmschrijving);
        Controls.Add(btnPrimary);
        Controls.Add(btnAnnuleren);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimumSize = new Size(720, 560);
        Name = "FrmBootToevoegen";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Boot toevoegen";
        ((System.ComponentModel.ISupportInitialize)nudCapaciteit).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudBouwjaar).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudLengte).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudPrijs).EndInit();
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
