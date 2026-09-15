namespace SailAway;

public partial class FrmBootDetails : Form
{
    public FrmBootDetails()
    {
        InitializeComponent();
    }

    private void btnReserveren_Click(object? sender, EventArgs e) => new FrmReserveringMaken().ShowDialog();

    private void btnTerug_Click(object? sender, EventArgs e)
    {
        Close();
    }

}
