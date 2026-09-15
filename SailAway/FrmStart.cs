namespace SailAway;

public partial class FrmStart : Form
{
    public FrmStart()
    {
        InitializeComponent();
    }

    private void btnBotenBekijken_Click(object? sender, EventArgs e) => new FrmBoten().ShowDialog();
    private void btnInloggen_Click(object? sender, EventArgs e) => new FrmInloggen().ShowDialog();
    private void btnRegistreren_Click(object? sender, EventArgs e) => new FrmRegistreren().ShowDialog();

}
