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
        btnKlanten = new Button();
        btnBoten = new Button();
        btnReserveringen = new Button();
        btnBootsoorten = new Button();
        btnLocaties = new Button();
        btnUitloggen = new Button();
        SuspendLayout();
        // 
        // lblTitel
        // 
        lblTitel.AutoSize = true;
        lblTitel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblTitel.ForeColor = Color.FromArgb(52, 58, 70);
        lblTitel.Location = new Point(45, 52);
        lblTitel.Name = "lblTitel";
        lblTitel.Size = new Size(353, 50);
        lblTitel.TabIndex = 0;
        lblTitel.Text = "SAILAWAY BEHEER";
        // 
        // btnKlanten
        // 
        btnKlanten.BackColor = Color.FromArgb(181, 32, 46);
        btnKlanten.FlatStyle = FlatStyle.Flat;
        btnKlanten.ForeColor = Color.White;
        btnKlanten.Location = new Point(370, 130);
        btnKlanten.Name = "btnKlanten";
        btnKlanten.Size = new Size(240, 42);
        btnKlanten.TabIndex = 1;
        btnKlanten.Text = "Klanten beheren";
        btnKlanten.UseVisualStyleBackColor = false;
        btnKlanten.Click += btnKlanten_Click;
        // 
        // btnBoten
        // 
        btnBoten.BackColor = Color.FromArgb(181, 32, 46);
        btnBoten.FlatStyle = FlatStyle.Flat;
        btnBoten.ForeColor = Color.White;
        btnBoten.Location = new Point(370, 190);
        btnBoten.Name = "btnBoten";
        btnBoten.Size = new Size(240, 42);
        btnBoten.TabIndex = 2;
        btnBoten.Text = "Boten beheren";
        btnBoten.UseVisualStyleBackColor = false;
        btnBoten.Click += btnBoten_Click;
        // 
        // btnReserveringen
        // 
        btnReserveringen.BackColor = Color.FromArgb(181, 32, 46);
        btnReserveringen.FlatStyle = FlatStyle.Flat;
        btnReserveringen.ForeColor = Color.White;
        btnReserveringen.Location = new Point(370, 250);
        btnReserveringen.Name = "btnReserveringen";
        btnReserveringen.Size = new Size(240, 42);
        btnReserveringen.TabIndex = 3;
        btnReserveringen.Text = "Reserveringen beheren";
        btnReserveringen.UseVisualStyleBackColor = false;
        btnReserveringen.Click += btnReserveringen_Click;
        // 
        // btnBootsoorten
        // 
        btnBootsoorten.BackColor = Color.FromArgb(181, 32, 46);
        btnBootsoorten.FlatStyle = FlatStyle.Flat;
        btnBootsoorten.ForeColor = Color.White;
        btnBootsoorten.Location = new Point(370, 310);
        btnBootsoorten.Name = "btnBootsoorten";
        btnBootsoorten.Size = new Size(240, 42);
        btnBootsoorten.TabIndex = 4;
        btnBootsoorten.Text = "Bootsoorten beheren";
        btnBootsoorten.UseVisualStyleBackColor = false;
        btnBootsoorten.Click += btnBootsoorten_Click;
        // 
        // btnLocaties
        // 
        btnLocaties.BackColor = Color.FromArgb(181, 32, 46);
        btnLocaties.FlatStyle = FlatStyle.Flat;
        btnLocaties.ForeColor = Color.White;
        btnLocaties.Location = new Point(370, 370);
        btnLocaties.Name = "btnLocaties";
        btnLocaties.Size = new Size(240, 42);
        btnLocaties.TabIndex = 5;
        btnLocaties.Text = "Locaties beheren";
        btnLocaties.UseVisualStyleBackColor = false;
        btnLocaties.Click += btnLocaties_Click;
        // 
        // btnUitloggen
        // 
        btnUitloggen.Location = new Point(370, 430);
        btnUitloggen.Name = "btnUitloggen";
        btnUitloggen.Size = new Size(240, 42);
        btnUitloggen.TabIndex = 6;
        btnUitloggen.Text = "Uitloggen";
        btnUitloggen.Click += btnUitloggen_Click;
        // 
        // FrmBeheerMenu
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        ClientSize = new Size(982, 603);
        Controls.Add(lblTitel);
        Controls.Add(btnKlanten);
        Controls.Add(btnBoten);
        Controls.Add(btnReserveringen);
        Controls.Add(btnBootsoorten);
        Controls.Add(btnLocaties);
        Controls.Add(btnUitloggen);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimumSize = new Size(1000, 650);
        Name = "FrmBeheerMenu";
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
