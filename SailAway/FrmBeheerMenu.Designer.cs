namespace SailAway;

partial class FrmBeheerMenu
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
        lblTitel.Text = "SAILAWAY BEHEER";
        btnKlanten = new Button(); btnKlanten.Location = new Point(370,130); btnKlanten.Size = new Size(240,42); btnKlanten.Text = "Klanten beheren"; btnKlanten.BackColor = Color.FromArgb(181, 32, 46); btnKlanten.ForeColor = Color.White; btnKlanten.FlatStyle = FlatStyle.Flat;
        btnKlanten.Click += btnKlanten_Click;
        btnBoten = new Button(); btnBoten.Location = new Point(370,190); btnBoten.Size = new Size(240,42); btnBoten.Text = "Boten beheren"; btnBoten.BackColor = Color.FromArgb(181, 32, 46); btnBoten.ForeColor = Color.White; btnBoten.FlatStyle = FlatStyle.Flat;
        btnBoten.Click += btnBoten_Click;
        btnReserveringen = new Button(); btnReserveringen.Location = new Point(370,250); btnReserveringen.Size = new Size(240,42); btnReserveringen.Text = "Reserveringen beheren"; btnReserveringen.BackColor = Color.FromArgb(181, 32, 46); btnReserveringen.ForeColor = Color.White; btnReserveringen.FlatStyle = FlatStyle.Flat;
        btnReserveringen.Click += btnReserveringen_Click;
        btnBootsoorten = new Button(); btnBootsoorten.Location = new Point(370,310); btnBootsoorten.Size = new Size(240,42); btnBootsoorten.Text = "Bootsoorten beheren"; btnBootsoorten.BackColor = Color.FromArgb(181, 32, 46); btnBootsoorten.ForeColor = Color.White; btnBootsoorten.FlatStyle = FlatStyle.Flat;
        btnBootsoorten.Click += btnBootsoorten_Click;
        btnLocaties = new Button(); btnLocaties.Location = new Point(370,370); btnLocaties.Size = new Size(240,42); btnLocaties.Text = "Locaties beheren"; btnLocaties.BackColor = Color.FromArgb(181, 32, 46); btnLocaties.ForeColor = Color.White; btnLocaties.FlatStyle = FlatStyle.Flat;
        btnLocaties.Click += btnLocaties_Click;
        btnUitloggen = new Button(); btnUitloggen.Location = new Point(370,430); btnUitloggen.Size = new Size(240,42); btnUitloggen.Text = "Uitloggen";
        btnUitloggen.Click += btnUitloggen_Click;
        Controls.AddRange(new Control[] { lblTitel, btnKlanten, btnBoten, btnReserveringen, btnBootsoorten, btnLocaties, btnUitloggen });

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(984, 611);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "SailAway Beheer";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitel;
    private Button btnKlanten;
    private Button btnBoten;
    private Button btnReserveringen;
    private Button btnBootsoorten;
    private Button btnLocaties;
    private Button btnUitloggen;

}
