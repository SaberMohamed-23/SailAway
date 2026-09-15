namespace SailAway;

public partial class FrmBeheerMenu : Form
{
    public FrmBeheerMenu()
    {
        InitializeComponent();
    }

    private void btnKlanten_Click(object? sender, EventArgs e)
    {
        new FrmKlantenBeheer().ShowDialog();
    }

    private void btnBoten_Click(object? sender, EventArgs e)
    {
        new FrmBotenBeheer().ShowDialog();
    }

    private void btnReserveringen_Click(object? sender, EventArgs e)
    {
        new FrmReserveringenBeheer().ShowDialog();
    }

    private void btnBootsoorten_Click(object? sender, EventArgs e)
    {
        new FrmBootsoortenBeheer().ShowDialog();
    }

    private void btnLocaties_Click(object? sender, EventArgs e)
    {
        new FrmLocatiesBeheer().ShowDialog();
    }

    private void btnUitloggen_Click(object? sender, EventArgs e)
    {
        Close();
    }

}
