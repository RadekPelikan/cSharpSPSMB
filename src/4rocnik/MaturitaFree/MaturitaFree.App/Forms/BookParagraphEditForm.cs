using MaturitaFree.Common.Entities;
using MaturitaFree.Common.Repositories;

namespace MaturitaFree.App.Forms;

public partial class BookParagraphEditForm : Form
{
    private readonly IBookParagraphRepository _paragraphRepo;

    private int _chapterId;
    private int? _paragraphId;

    public BookParagraphEditForm(IBookParagraphRepository paragraphRepo)
    {
        InitializeComponent();
        _paragraphRepo = paragraphRepo;
    }

    // ── Initialisation ───────────────────────────────────────────────────────

    /// <summary>Configures the form for creating a new paragraph inside <paramref name="chapterId"/>.</summary>
    public void SetChapter(int chapterId)
    {
        _chapterId = chapterId;
        _paragraphId = null;
        Text = "Add Paragraph";
        lblHeading.Text = "Add Paragraph";
    }

    /// <summary>Configures the form for editing an existing paragraph.</summary>
    public void LoadParagraph(int paragraphId) => _ = LoadParagraphAsync(paragraphId);

    private async Task LoadParagraphAsync(int paragraphId)
    {
        var para = await _paragraphRepo.GetByIdAsync(paragraphId);
        if (para is null) return;

        _chapterId = para.ChapterId;
        _paragraphId = para.Id;
        txtContent.Text = para.Content;
        nudOrder.Value = para.Order;

        Text = "Edit Paragraph";
        lblHeading.Text = "Edit Paragraph";
    }

    // ── Event handlers ───────────────────────────────────────────────────────

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtContent.Text))
        {
            MessageBox.Show("Content is required.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtContent.Focus();
            return;
        }

        btnSave.Enabled = false;
        lblStatus.Text = "";
        try
        {
            if (_paragraphId.HasValue)
            {
                var para = await _paragraphRepo.GetByIdAsync(_paragraphId.Value);
                if (para is null) return;

                para.Content = txtContent.Text.Trim();
                para.Order = (int)nudOrder.Value;
                await _paragraphRepo.UpdateAsync(para);
            }
            else
            {
                var para = new BookParagraphEntity
                {
                    Content = txtContent.Text.Trim(),
                    Order = (int)nudOrder.Value,
                    ChapterId = _chapterId,
                };
                await _paragraphRepo.AddAsync(para);
                _paragraphId = para.Id;
            }

            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Error: {ex.Message}";
            MessageBox.Show(ex.Message, "Save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnSave.Enabled = true;
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
        => DialogResult = DialogResult.Cancel;
}
