namespace SailAway;

public partial class FrmMijnReserveringen : Form
{
    public FrmMijnReserveringen()
    {
        InitializeComponent();
    }

    private void btnWijzigen_Click(object? s, EventArgs e) => new FrmReserveringWijzigen().ShowDialog();
    private void btnAnnulerenRes_Click(object? s, EventArgs e) => MessageBox.Show("Reservering geannuleerd (demo).", "SailAway");
    private void btnTerug_Click(object? s, EventArgs e) => Close();

}
