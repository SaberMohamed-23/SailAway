namespace SailAway;

partial class FrmReserveringToevoegen
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
        lblTitel.Text = "Reservering toevoegen";
        lbl_cmbKlant = new Label(); lbl_cmbKlant.Location = new Point(220,125); lbl_cmbKlant.Size = new Size(160,25); lbl_cmbKlant.Text = "Klant:";
        cmbKlant = new ComboBox(); cmbKlant.Location = new Point(390,125); cmbKlant.Size = new Size(310,25); cmbKlant.DropDownStyle = ComboBoxStyle.DropDownList; cmbKlant.Items.AddRange(new object[] { "Sanne Jansen", "Omar Ali" });
        lbl_cmbBoot = new Label(); lbl_cmbBoot.Location = new Point(220,167); lbl_cmbBoot.Size = new Size(160,25); lbl_cmbBoot.Text = "Boot:";
        cmbBoot = new ComboBox(); cmbBoot.Location = new Point(390,167); cmbBoot.Size = new Size(310,25); cmbBoot.DropDownStyle = ComboBoxStyle.DropDownList; cmbBoot.Items.AddRange(new object[] { "Sea Star", "Blue Wave", "River One" });
        lbl_cmbLocatie = new Label(); lbl_cmbLocatie.Location = new Point(220,209); lbl_cmbLocatie.Size = new Size(160,25); lbl_cmbLocatie.Text = "Locatie:";
        cmbLocatie = new ComboBox(); cmbLocatie.Location = new Point(390,209); cmbLocatie.Size = new Size(310,25); cmbLocatie.DropDownStyle = ComboBoxStyle.DropDownList; cmbLocatie.Items.AddRange(new object[] { "Veghel", "Oss", "'s-Hertogenbosch" });
        lbl_dtpDatum = new Label(); lbl_dtpDatum.Location = new Point(220,251); lbl_dtpDatum.Size = new Size(160,25); lbl_dtpDatum.Text = "Datum:";
        dtpDatum = new DateTimePicker(); dtpDatum.Location = new Point(390,251); dtpDatum.Size = new Size(310,25); dtpDatum.Format = DateTimePickerFormat.Short;
        lbl_dtpBegin = new Label(); lbl_dtpBegin.Location = new Point(220,293); lbl_dtpBegin.Size = new Size(160,25); lbl_dtpBegin.Text = "Begintijd:";
        dtpBegin = new DateTimePicker(); dtpBegin.Location = new Point(390,293); dtpBegin.Size = new Size(310,25); dtpBegin.Format = DateTimePickerFormat.Time; dtpBegin.ShowUpDown = true;
        lbl_dtpEind = new Label(); lbl_dtpEind.Location = new Point(220,335); lbl_dtpEind.Size = new Size(160,25); lbl_dtpEind.Text = "Eindtijd:";
        dtpEind = new DateTimePicker(); dtpEind.Location = new Point(390,335); dtpEind.Size = new Size(310,25); dtpEind.Format = DateTimePickerFormat.Time; dtpEind.ShowUpDown = true;
        lbl_cmbStatus = new Label(); lbl_cmbStatus.Location = new Point(220,377); lbl_cmbStatus.Size = new Size(160,25); lbl_cmbStatus.Text = "Status:";
        cmbStatus = new ComboBox(); cmbStatus.Location = new Point(390,377); cmbStatus.Size = new Size(310,25); cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList; cmbStatus.Items.AddRange(new object[] { "Actief", "Geannuleerd", "Voltooid" });
        btnPrimary = new Button(); btnPrimary.Location = new Point(390,434); btnPrimary.Size = new Size(150,38); btnPrimary.Text = "Toevoegen"; btnPrimary.BackColor = Color.FromArgb(181, 32, 46); btnPrimary.ForeColor = Color.White; btnPrimary.FlatStyle = FlatStyle.Flat;
        btnAnnuleren = new Button(); btnAnnuleren.Location = new Point(550,434); btnAnnuleren.Size = new Size(150,38); btnAnnuleren.Text = "Annuleren";
        btnAnnuleren.Click += btnAnnuleren_Click;
        Controls.AddRange(new Control[] { lblTitel, lbl_cmbKlant, cmbKlant, lbl_cmbBoot, cmbBoot, lbl_cmbLocatie, cmbLocatie, lbl_dtpDatum, dtpDatum, lbl_dtpBegin, dtpBegin, lbl_dtpEind, dtpEind, lbl_cmbStatus, cmbStatus, btnPrimary, btnAnnuleren });

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        ClientSize = new Size(900, 640);
        MinimumSize = new Size(800, 600);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Reservering toevoegen";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitel;
    private Label lbl_cmbKlant; private ComboBox cmbKlant;
    private Label lbl_cmbBoot; private ComboBox cmbBoot;
    private Label lbl_cmbLocatie; private ComboBox cmbLocatie;
    private Label lbl_dtpDatum; private DateTimePicker dtpDatum;
    private Label lbl_dtpBegin; private DateTimePicker dtpBegin;
    private Label lbl_dtpEind; private DateTimePicker dtpEind;
    private Label lbl_cmbStatus; private ComboBox cmbStatus;
    private Button btnPrimary,btnAnnuleren;

}
