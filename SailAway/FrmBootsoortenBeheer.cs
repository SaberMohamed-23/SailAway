namespace SailAway;

public partial class FrmBootsoortenBeheer : Form
{
    public FrmBootsoortenBeheer()
    {
        InitializeComponent();
    }

    private void btnToevoegen_Click(object? s, EventArgs e) => new FrmBootsoortToevoegen().ShowDialog();
    private void btnBewerken_Click(object? s, EventArgs e) => new FrmBootsoortBewerken().ShowDialog();
    private void btnVerwijderen_Click(object? s, EventArgs e) => MessageBox.Show("Weet u zeker dat u deze bootsoort wilt verwijderen?", "Bootsoort verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

}
