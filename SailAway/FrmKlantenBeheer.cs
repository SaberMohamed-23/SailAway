namespace SailAway;

public partial class FrmKlantenBeheer : Form
{
    public FrmKlantenBeheer()
    {
        InitializeComponent();
    }

    private void btnToevoegen_Click(object? s, EventArgs e) => new FrmKlantToevoegen().ShowDialog();
    private void btnBewerken_Click(object? s, EventArgs e) => new FrmKlantBewerken().ShowDialog();
    private void btnVerwijderen_Click(object? s, EventArgs e) => MessageBox.Show("Weet u zeker dat u deze klant wilt verwijderen?", "Klant verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

}
