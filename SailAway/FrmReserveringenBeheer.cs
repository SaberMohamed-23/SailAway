namespace SailAway;

public partial class FrmReserveringenBeheer : Form
{
    public FrmReserveringenBeheer()
    {
        InitializeComponent();
    }

    private void btnToevoegen_Click(object? s, EventArgs e) => new FrmReserveringToevoegen().ShowDialog();
    private void btnBewerken_Click(object? s, EventArgs e) => new FrmReserveringBewerken().ShowDialog();
    private void btnVerwijderen_Click(object? s, EventArgs e) => MessageBox.Show("Weet u zeker dat u deze reservering wilt verwijderen?", "Reservering verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

}
