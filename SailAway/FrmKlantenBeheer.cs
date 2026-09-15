namespace SailAway;

public partial class FrmKlantenBeheer : Form
{
    public FrmKlantenBeheer()
    {
        InitializeComponent();
    }

    private void btnToevoegen_Click(object? s, EventArgs e) => new FrmKlantToevoegen().ShowDialog();
    private void btnBewerken_Click(object? s, EventArgs e)
    {
        // Get selected klant id from the DataGridView. Here we assume the first column contains KlantId when integrated with real data.
        if (dgv.SelectedRows.Count == 0)
        {
            MessageBox.Show("Selecteer eerst een klant.", "Bewerken", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // This example expects that when real data is loaded, the row's Tag or a hidden column holds the klant_id.
        // For now, try to parse a hidden value from the row's Tag or first cell.
        var row = dgv.SelectedRows[0];
        int klantId = 0;

        if (row.Tag is int id)
        {
            klantId = id;
        }
        else
        {
            // Try parse from first cell (if you later put klant_id there).
            if (row.Cells.Count > 0 && int.TryParse(row.Cells[0].Value?.ToString(), out var parsed))
                klantId = parsed;
        }

        if (klantId <= 0)
        {
            // Fallback: open empty editor (existing behavior)
            new FrmKlantBewerken().ShowDialog();
            return;
        }

        new FrmKlantBewerken(klantId).ShowDialog();
    }
    private void btnVerwijderen_Click(object? s, EventArgs e) => MessageBox.Show("Weet u zeker dat u deze klant wilt verwijderen?", "Klant verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

}
