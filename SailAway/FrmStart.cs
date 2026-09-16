namespace SailAway;

public partial class FrmStart : Form
{
    public FrmStart()
    {
        InitializeComponent();
    }

    private void btnBotenBekijken_Click(object? sender, EventArgs e)
    {
        // Open boat catalogue non-modally so user can navigate back
        var f = new FrmBoten();
        f.Show();
    }

    private void btnInloggen_Click(object? sender, EventArgs e)
    {
        using var f = new FrmInloggen();
        f.ShowDialog();
    }

    private void btnRegistreren_Click(object? sender, EventArgs e)
    {
        using var f = new FrmRegistreren();
        f.ShowDialog();
    }

}
