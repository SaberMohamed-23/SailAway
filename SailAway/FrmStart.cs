namespace SailAway;

public partial class FrmStart : Form
{
    public FrmStart()
    {
        InitializeComponent();

        // Het panel is verborgen bij het opstarten
        panel1.Visible = false;
    }

    private void btnBotenBekijken_Click(object? sender, EventArgs e)
    {
        // Panel zichtbaar maken
        panel1.Visible = true;

        // FrmBoten in het panel openen
        OpenFormInPanel(new FrmBoten());
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

    private void OpenFormInPanel(Form form)
    {
        panel1.Controls.Clear();

        form.TopLevel = false;
        form.FormBorderStyle = FormBorderStyle.None;
        form.Dock = DockStyle.Fill;

        panel1.Controls.Add(form);
        form.Show();
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void panel1_Paint_1(object sender, PaintEventArgs e)
    {
    }
}