namespace SailAway;

public partial class FrmBotenBeheer : Form
{
    public FrmBotenBeheer()
    {
        InitializeComponent();
    }

    private void btnToevoegen_Click(object? s, EventArgs e) => new FrmBootToevoegen().ShowDialog();
    private void btnBewerken_Click(object? s, EventArgs e) => new FrmBootBewerken().ShowDialog();
    private void btnVerwijderen_Click(object? s, EventArgs e) => MessageBox.Show("Weet u zeker dat u deze boot wilt verwijderen?", "Boot verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

}
