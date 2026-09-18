namespace SailAway;

partial class FrmBootsoortenBeheer
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
        dgv = new DataGridView();
        btnToevoegen = new Button();
        btnBewerken = new Button();
        btnVerwijderen = new Button();
        dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        SuspendLayout();
        // 
        // lblTitel
        // 
        lblTitel.AutoSize = true;
        lblTitel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblTitel.ForeColor = Color.FromArgb(52, 58, 70);
        lblTitel.Location = new Point(45, 52);
        lblTitel.Name = "lblTitel";
        lblTitel.Size = new Size(392, 50);
        lblTitel.TabIndex = 0;
        lblTitel.Text = "Bootsoorten beheren";
        // 
        // dgv
        // 
        dgv.AllowUserToAddRows = false;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.BackgroundColor = Color.White;
        dgv.ColumnHeadersHeight = 29;
        dgv.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
        dgv.Location = new Point(45, 115);
        dgv.MultiSelect = false;
        dgv.Name = "dgv";
        dgv.ReadOnly = true;
        dgv.RowHeadersWidth = 51;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.Size = new Size(760, 350);
        dgv.TabIndex = 1;
        // 
        // btnToevoegen
        // 
        btnToevoegen.BackColor = Color.FromArgb(181, 32, 46);
        btnToevoegen.FlatStyle = FlatStyle.Flat;
        btnToevoegen.ForeColor = Color.White;
        btnToevoegen.Location = new Point(825, 115);
        btnToevoegen.Name = "btnToevoegen";
        btnToevoegen.Size = new Size(120, 38);
        btnToevoegen.TabIndex = 2;
        btnToevoegen.Text = "Toevoegen";
        btnToevoegen.UseVisualStyleBackColor = false;
        btnToevoegen.Click += btnToevoegen_Click;
        // 
        // btnBewerken
        // 
        btnBewerken.Location = new Point(825, 170);
        btnBewerken.Name = "btnBewerken";
        btnBewerken.Size = new Size(120, 38);
        btnBewerken.TabIndex = 3;
        btnBewerken.Text = "Bewerken";
        btnBewerken.Click += btnBewerken_Click;
        // 
        // btnVerwijderen
        // 
        btnVerwijderen.Location = new Point(825, 225);
        btnVerwijderen.Name = "btnVerwijderen";
        btnVerwijderen.Size = new Size(120, 38);
        btnVerwijderen.TabIndex = 4;
        btnVerwijderen.Text = "Verwijderen";
        btnVerwijderen.Click += btnVerwijderen_Click;
        // 
        // dataGridViewTextBoxColumn1
        // 
        dataGridViewTextBoxColumn1.HeaderText = "Naam";
        dataGridViewTextBoxColumn1.MinimumWidth = 6;
        dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        dataGridViewTextBoxColumn1.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn2
        // 
        dataGridViewTextBoxColumn2.HeaderText = "Beschrijving";
        dataGridViewTextBoxColumn2.MinimumWidth = 6;
        dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        dataGridViewTextBoxColumn2.ReadOnly = true;
        // 
        // FrmBootsoortenBeheer
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        ClientSize = new Size(1061, 644);
        Controls.Add(lblTitel);
        Controls.Add(dgv);
        Controls.Add(btnToevoegen);
        Controls.Add(btnBewerken);
        Controls.Add(btnVerwijderen);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimumSize = new Size(1000, 650);
        Name = "FrmBootsoortenBeheer";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Bootsoorten beheren";
        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitel;
    private DataGridView dgv;
    private Button btnToevoegen;
    private Button btnBewerken;
    private Button btnVerwijderen;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
}
