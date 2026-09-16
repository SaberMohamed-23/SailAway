namespace SailAway;

public partial class FrmReserveringMaken : Form
{
    // Optional public property so callers can pass boot id
    public int BootId { get; set; }

    public FrmReserveringMaken()
    {
        InitializeComponent();
        Load += FrmReserveringMaken_Load;
        btnPrimary.Click += BtnPrimary_Click;
    }

    private void btnAnnuleren_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void FrmReserveringMaken_Load(object? sender, EventArgs e)
    {
        // Pre-fill boot selection if BootId set
        if (BootId > 0)
        {
            // If cmbBoot exists, try to select proper boat
            try
            {
                // Load locations and boats similar to other forms
                var f = this; // no-op placeholder
            }
            catch { }
        }
    }

    private void BtnPrimary_Click(object? sender, EventArgs e)
    {
        // For this beginner-friendly project we redirect to the existing FrmReserveringToevoegen
        // and pass the selected boot via Session or simply open the add form.
        using var f = new FrmReserveringToevoegen();
        // If BootId is set and FrmReserveringToevoegen has a way to accept it, set via reflection
        var prop = f.GetType().GetProperty("SelectedBootId");
        if (prop != null && prop.CanWrite) prop.SetValue(f, BootId);
        f.ShowDialog();
        Close();
    }

}
