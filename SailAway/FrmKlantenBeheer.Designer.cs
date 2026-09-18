namespace SailAway;

partial class FrmKlantenBeheer
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
        cmbZoekenOp = new ComboBox();
        txtZoeken = new TextBox();
        btnZoeken = new Button();
        dgv = new DataGridView();
        btnToevoegen = new Button();
        btnBewerken = new Button();
        btnVerwijderen = new Button();
        lblSub = new Label();
        dgv2 = new DataGridView();
        dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgv2).BeginInit();
        SuspendLayout();
        // 
        // lblTitel
        // 
        lblTitel.AutoSize = true;
        lblTitel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblTitel.ForeColor = Color.FromArgb(52, 58, 70);
        lblTitel.Location = new Point(45, 52);
        lblTitel.Name = "lblTitel";
        lblTitel.Size = new Size(307, 50);
        lblTitel.TabIndex = 0;
        lblTitel.Text = "Klanten beheren";
        // 
        // cmbZoekenOp
        // 
        cmbZoekenOp.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbZoekenOp.Items.AddRange(new object[] { "Achternaam", "Telefoonnummer", "E-mailadres" });
        cmbZoekenOp.Location = new Point(45, 115);
        cmbZoekenOp.Name = "cmbZoekenOp";
        cmbZoekenOp.Size = new Size(180, 31);
        cmbZoekenOp.TabIndex = 1;
        // 
        // txtZoeken
        // 
        txtZoeken.Location = new Point(235, 115);
        txtZoeken.Name = "txtZoeken";
        txtZoeken.Size = new Size(250, 30);
        txtZoeken.TabIndex = 2;
        // 
        // btnZoeken
        // 
        btnZoeken.Location = new Point(495, 111);
        btnZoeken.Name = "btnZoeken";
        btnZoeken.Size = new Size(100, 32);
        btnZoeken.TabIndex = 3;
        btnZoeken.Text = "Zoeken";
        // 
        // dgv
        // 
        dgv.AllowUserToAddRows = false;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.BackgroundColor = Color.White;
        dgv.ColumnHeadersHeight = 29;
        dgv.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
        dgv.Location = new Point(45, 165);
        dgv.MultiSelect = false;
        dgv.Name = "dgv";
        dgv.ReadOnly = true;
        dgv.RowHeadersWidth = 51;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.Size = new Size(760, 220);
        dgv.TabIndex = 4;
        // 
        // btnToevoegen
        // 
        btnToevoegen.BackColor = Color.FromArgb(181, 32, 46);
        btnToevoegen.FlatStyle = FlatStyle.Flat;
        btnToevoegen.ForeColor = Color.White;
        btnToevoegen.Location = new Point(825, 165);
        btnToevoegen.Name = "btnToevoegen";
        btnToevoegen.Size = new Size(120, 38);
        btnToevoegen.TabIndex = 5;
        btnToevoegen.Text = "Toevoegen";
        btnToevoegen.UseVisualStyleBackColor = false;
        btnToevoegen.Click += btnToevoegen_Click;
        // 
        // btnBewerken
        // 
        btnBewerken.Location = new Point(825, 220);
        btnBewerken.Name = "btnBewerken";
        btnBewerken.Size = new Size(120, 38);
        btnBewerken.TabIndex = 6;
        btnBewerken.Text = "Bewerken";
        btnBewerken.Click += btnBewerken_Click;
        // 
        // btnVerwijderen
        // 
        btnVerwijderen.Location = new Point(825, 275);
        btnVerwijderen.Name = "btnVerwijderen";
        btnVerwijderen.Size = new Size(120, 38);
        btnVerwijderen.TabIndex = 7;
        btnVerwijderen.Text = "Verwijderen";
        btnVerwijderen.Click += btnVerwijderen_Click;
        // 
        // lblSub
        // 
        lblSub.AutoSize = true;
        lblSub.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblSub.Location = new Point(45, 405);
        lblSub.Name = "lblSub";
        lblSub.Size = new Size(261, 28);
        lblSub.TabIndex = 8;
        lblSub.Text = "Gekoppelde reserveringen";
        // 
        // dgv2
        // 
        dgv2.AllowUserToAddRows = false;
        dgv2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv2.ColumnHeadersHeight = 29;
        dgv2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10 });
        dgv2.Location = new Point(45, 435);
        dgv2.Name = "dgv2";
        dgv2.ReadOnly = true;
        dgv2.RowHeadersWidth = 51;
        dgv2.Size = new Size(760, 140);
        dgv2.TabIndex = 9;
        // 
        // dataGridViewTextBoxColumn1
        // 
        dataGridViewTextBoxColumn1.HeaderText = "Voornaam";
        dataGridViewTextBoxColumn1.MinimumWidth = 6;
        dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        dataGridViewTextBoxColumn1.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn2
        // 
        dataGridViewTextBoxColumn2.HeaderText = "Tussenvoegsel";
        dataGridViewTextBoxColumn2.MinimumWidth = 6;
        dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        dataGridViewTextBoxColumn2.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn3
        // 
        dataGridViewTextBoxColumn3.HeaderText = "Achternaam";
        dataGridViewTextBoxColumn3.MinimumWidth = 6;
        dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
        dataGridViewTextBoxColumn3.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn4
        // 
        dataGridViewTextBoxColumn4.HeaderText = "Geboortedatum";
        dataGridViewTextBoxColumn4.MinimumWidth = 6;
        dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
        dataGridViewTextBoxColumn4.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn5
        // 
        dataGridViewTextBoxColumn5.HeaderText = "Telefoonnummer";
        dataGridViewTextBoxColumn5.MinimumWidth = 6;
        dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
        dataGridViewTextBoxColumn5.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn6
        // 
        dataGridViewTextBoxColumn6.HeaderText = "E-mailadres";
        dataGridViewTextBoxColumn6.MinimumWidth = 6;
        dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
        dataGridViewTextBoxColumn6.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn7
        // 
        dataGridViewTextBoxColumn7.HeaderText = "Boot";
        dataGridViewTextBoxColumn7.MinimumWidth = 6;
        dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
        dataGridViewTextBoxColumn7.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn8
        // 
        dataGridViewTextBoxColumn8.HeaderText = "Datum";
        dataGridViewTextBoxColumn8.MinimumWidth = 6;
        dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
        dataGridViewTextBoxColumn8.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn9
        // 
        dataGridViewTextBoxColumn9.HeaderText = "Tijd";
        dataGridViewTextBoxColumn9.MinimumWidth = 6;
        dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
        dataGridViewTextBoxColumn9.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn10
        // 
        dataGridViewTextBoxColumn10.HeaderText = "Status";
        dataGridViewTextBoxColumn10.MinimumWidth = 6;
        dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
        dataGridViewTextBoxColumn10.ReadOnly = true;
        // 
        // FrmKlantenBeheer
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        ClientSize = new Size(1060, 700);
        Controls.Add(lblTitel);
        Controls.Add(cmbZoekenOp);
        Controls.Add(txtZoeken);
        Controls.Add(btnZoeken);
        Controls.Add(dgv);
        Controls.Add(btnToevoegen);
        Controls.Add(btnBewerken);
        Controls.Add(btnVerwijderen);
        Controls.Add(lblSub);
        Controls.Add(dgv2);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimumSize = new Size(1000, 650);
        Name = "FrmKlantenBeheer";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Klanten beheren";
        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgv2).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitel;
    private ComboBox cmbZoekenOp; private TextBox txtZoeken; private Button btnZoeken;
    private DataGridView dgv;
    private Button btnToevoegen;
    private Button btnBewerken;
    private Button btnVerwijderen;
    private Label lblSub; private DataGridView dgv2;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
}
