namespace SailAway;

public partial class FrmLocatiesBeheer : Form
{
    public FrmLocatiesBeheer()
    {
        InitializeComponent();
    }

    private void btnToevoegen_Click(object? s, EventArgs e) => new FrmLocatieToevoegen().ShowDialog();
    private void btnBewerken_Click(object? s, EventArgs e) => new FrmLocatieBewerken().ShowDialog();
    private void btnVerwijderen_Click(object? s, EventArgs e) => MessageBox.Show("Weet u zeker dat u deze locatie wilt verwijderen?", "Locatie verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

}
