namespace SailAway;

partial class FrmReserveringWijzigen
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
        lblTitel.Text = "Reservering wijzigen";
        lbl_txtBoot = new Label(); lbl_txtBoot.Location = new Point(220,125); lbl_txtBoot.Size = new Size(160,25); lbl_txtBoot.Text = "Boot:";
        txtBoot = new TextBox(); txtBoot.Location = new Point(390,125); txtBoot.Size = new Size(310,25); txtBoot.Text = "Sea Star";
        lbl_cmbLocatie = new Label(); lbl_cmbLocatie.Location = new Point(220,167); lbl_cmbLocatie.Size = new Size(160,25); lbl_cmbLocatie.Text = "Locatie:";
        cmbLocatie = new ComboBox(); cmbLocatie.Location = new Point(390,167); cmbLocatie.Size = new Size(310,25); cmbLocatie.DropDownStyle = ComboBoxStyle.DropDownList; cmbLocatie.Items.AddRange(new object[] { "Veghel", "Oss", "'s-Hertogenbosch" });
        lbl_dtpDatum = new Label(); lbl_dtpDatum.Location = new Point(220,209); lbl_dtpDatum.Size = new Size(160,25); lbl_dtpDatum.Text = "Datum:";
        dtpDatum = new DateTimePicker(); dtpDatum.Location = new Point(390,209); dtpDatum.Size = new Size(310,25); dtpDatum.Format = DateTimePickerFormat.Short;
        lbl_dtpBegin = new Label(); lbl_dtpBegin.Location = new Point(220,251); lbl_dtpBegin.Size = new Size(160,25); lbl_dtpBegin.Text = "Begintijd:";
        dtpBegin = new DateTimePicker(); dtpBegin.Location = new Point(390,251); dtpBegin.Size = new Size(310,25); dtpBegin.Format = DateTimePickerFormat.Time; dtpBegin.ShowUpDown = true;
        lbl_dtpEind = new Label(); lbl_dtpEind.Location = new Point(220,293); lbl_dtpEind.Size = new Size(160,25); lbl_dtpEind.Text = "Eindtijd:";
        dtpEind = new DateTimePicker(); dtpEind.Location = new Point(390,293); dtpEind.Size = new Size(310,25); dtpEind.Format = DateTimePickerFormat.Time; dtpEind.ShowUpDown = true;
        lbl_nudPersonen = new Label(); lbl_nudPersonen.Location = new Point(220,335); lbl_nudPersonen.Size = new Size(160,25); lbl_nudPersonen.Text = "Aantal personen:";
        nudPersonen = new NumericUpDown(); nudPersonen.Location = new Point(390,335); nudPersonen.Size = new Size(150,25); nudPersonen.Minimum = 1; nudPersonen.Maximum = 20; nudPersonen.Value = 1;
        btnPrimary = new Button(); btnPrimary.Location = new Point(390,392); btnPrimary.Size = new Size(150,38); btnPrimary.Text = "Wijzigingen opslaan"; btnPrimary.BackColor = Color.FromArgb(181, 32, 46); btnPrimary.ForeColor = Color.White; btnPrimary.FlatStyle = FlatStyle.Flat;
        btnAnnuleren = new Button(); btnAnnuleren.Location = new Point(550,392); btnAnnuleren.Size = new Size(150,38); btnAnnuleren.Text = "Annuleren";
        btnAnnuleren.Click += btnAnnuleren_Click;
        Controls.AddRange(new Control[] { lblTitel, lbl_txtBoot, txtBoot, lbl_cmbLocatie, cmbLocatie, lbl_dtpDatum, dtpDatum, lbl_dtpBegin, dtpBegin, lbl_dtpEind, dtpEind, lbl_nudPersonen, nudPersonen, btnPrimary, btnAnnuleren });

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(984, 611);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Reservering wijzigen";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitel;
    private Label lbl_txtBoot; private TextBox txtBoot;
    private Label lbl_cmbLocatie; private ComboBox cmbLocatie;
    private Label lbl_dtpDatum; private DateTimePicker dtpDatum;
    private Label lbl_dtpBegin; private DateTimePicker dtpBegin;
    private Label lbl_dtpEind; private DateTimePicker dtpEind;
    private Label lbl_nudPersonen; private NumericUpDown nudPersonen;
    private Button btnPrimary,btnAnnuleren;

}
