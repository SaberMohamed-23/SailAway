namespace SailAway;

public partial class FrmBoten : Form
{
    public FrmBoten()
    {
        InitializeComponent();
    }

    private void btnBoot_Click(object? sender, EventArgs e) => new FrmBootDetails().ShowDialog();

}
