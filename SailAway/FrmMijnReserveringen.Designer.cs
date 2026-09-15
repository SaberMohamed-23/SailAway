namespace SailAway;

partial class FrmMijnReserveringen
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
        lblTitel.Text = "Mijn reserveringen";
        dgv = new DataGridView(); dgv.Location = new Point(45,115); dgv.Size = new Size(760,350); dgv.ReadOnly = true; dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgv.MultiSelect = false; dgv.AllowUserToAddRows = false; dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; dgv.BackgroundColor = Color.White;
        dgv.Columns.Add("Boot", "Boot");
        dgv.Columns.Add("Locatie", "Locatie");
        dgv.Columns.Add("Datum", "Datum");
        dgv.Columns.Add("Begintijd", "Begintijd");
        dgv.Columns.Add("Eindtijd", "Eindtijd");
        dgv.Columns.Add("Status", "Status");
        dgv.Rows.Add("Sea Star", "Veghel", "15-09-2026", "13:00", "15:00", "Actief");
        btnWijzigen = new Button(); btnWijzigen.Location = new Point(825,115); btnWijzigen.Size = new Size(120,38); btnWijzigen.Text = "Wijzigen"; btnWijzigen.BackColor = Color.FromArgb(181, 32, 46); btnWijzigen.ForeColor = Color.White; btnWijzigen.FlatStyle = FlatStyle.Flat; btnWijzigen.Click += btnWijzigen_Click;
        btnAnnulerenRes = new Button(); btnAnnulerenRes.Location = new Point(825,170); btnAnnulerenRes.Size = new Size(120,38); btnAnnulerenRes.Text = "Reservering annuleren"; btnAnnulerenRes.Click += btnAnnulerenRes_Click;
        btnTerug = new Button(); btnTerug.Location = new Point(825,225); btnTerug.Size = new Size(120,38); btnTerug.Text = "Terug"; btnTerug.Click += btnTerug_Click;
        Controls.AddRange(new Control[] { lblTitel, dgv, btnWijzigen, btnAnnulerenRes, btnTerug });

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(984, 611);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Mijn reserveringen";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitel;
    private DataGridView dgv;
    private Button btnWijzigen;
    private Button btnAnnulerenRes;
    private Button btnTerug;

}
