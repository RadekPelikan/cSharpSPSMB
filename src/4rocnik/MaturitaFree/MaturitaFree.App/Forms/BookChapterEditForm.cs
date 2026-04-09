using MaturitaFree.App.Infrastructure;
using MaturitaFree.Common.Entities;
using MaturitaFree.Common.Repositories;

namespace MaturitaFree.App.Forms;

public partial class BookChapterEditForm : Form
{
    private readonly IBookChapterRepository _chapterRepo;
    private readonly IBookParagraphRepository _paragraphRepo;

    private int _bookId;
    private int? _chapterId;

    public BookChapterEditForm(IBookChapterRepository chapterRepo, IBookParagraphRepository paragraphRepo)
    {
        InitializeComponent();
        _chapterRepo = chapterRepo;
        _paragraphRepo = paragraphRepo;
    }

    // ── Initialisation (called by opener before ShowDialog) ──────────────────

    /// <summary>Configures the form for creating a new chapter inside <paramref name="bookId"/>.</summary>
    public void SetBook(int bookId)
    {
        _bookId = bookId;
        _chapterId = null;
        Text = "Add Chapter";
        lblHeading.Text = "Add Chapter";
        grpParagraphs.Enabled = false;
        lblParagraphHint.Visible = true;
    }

    /// <summary>Configures the form for editing an existing chapter.</summary>
    public void LoadChapter(int chapterId) => _ = LoadChapterAsync(chapterId);

    private async Task LoadChapterAsync(int chapterId)
    {
        var ch = await _chapterRepo.GetByIdWithParagraphsAsync(chapterId);
        if (ch is null) return;

        _bookId = ch.BookId;
        _chapterId = ch.Id;
        txtTitle.Text = ch.Title;
        nudOrder.Value = ch.Order;

        Text = "Edit Chapter";
        lblHeading.Text = "Edit Chapter";
        grpParagraphs.Enabled = true;
        lblParagraphHint.Visible = false;
        BindParagraphsGrid(ch.Paragraphs);
    }

    // ── Paragraphs grid ──────────────────────────────────────────────────────

    private void BindParagraphsGrid(IEnumerable<BookParagraphEntity> paragraphs)
    {
        dgvParagraphs.DataSource = paragraphs
            .OrderBy(p => p.Order)
            .Select(p => new
            {
                p.Id,
                p.Order,
                Preview = p.Content is { Length: > 70 } ? p.Content[..70] + "…" : p.Content
            })
            .ToList();

        if (dgvParagraphs.Columns.Contains("Id"))
            dgvParagraphs.Columns["Id"]!.Visible = false;
    }

    private async Task RefreshParagraphsAsync()
    {
        if (_chapterId is null) return;
        var paras = await _paragraphRepo.GetByChapterIdAsync(_chapterId.Value);
        BindParagraphsGrid(paras);
    }

    private int? SelectedParagraphId()
    {
        if (dgvParagraphs.SelectedRows.Count == 0) return null;
        return dgvParagraphs.SelectedRows[0].Cells["Id"].Value as int?;
    }

    private void OpenParagraphDialog(int? paragraphId)
    {
        if (_chapterId is null) return;

        using var dlg = ServiceLocator.Instance.GetService<BookParagraphEditForm>();
        if (paragraphId.HasValue)
            dlg.LoadParagraph(paragraphId.Value);
        else
            dlg.SetChapter(_chapterId.Value);

        if (dlg.ShowDialog(this) == DialogResult.OK)
            _ = RefreshParagraphsAsync();
    }

    // ── Event handlers ───────────────────────────────────────────────────────

    private async void btnSaveChapter_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTitle.Text))
        {
            MessageBox.Show("Title is required.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTitle.Focus();
            return;
        }

        btnSaveChapter.Enabled = false;
        lblStatus.Text = "";
        try
        {
            if (_chapterId.HasValue)
            {
                var ch = await _chapterRepo.GetByIdAsync(_chapterId.Value);
                if (ch is null) return;

                ch.Title = txtTitle.Text.Trim();
                ch.Order = (int)nudOrder.Value;
                await _chapterRepo.UpdateAsync(ch);
                lblStatus.Text = "Saved.";
            }
            else
            {
                var ch = new BookChapterEntity
                {
                    Title = txtTitle.Text.Trim(),
                    Order = (int)nudOrder.Value,
                    BookId = _bookId,
                    Paragraphs = [],
                };
                await _chapterRepo.AddAsync(ch);
                _chapterId = ch.Id;
                grpParagraphs.Enabled = true;
                lblParagraphHint.Visible = false;
                lblStatus.Text = "Chapter added. You can now add paragraphs.";
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
            btnSaveChapter.Enabled = true;
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
        => DialogResult = DialogResult.Cancel;

    private void btnAddParagraph_Click(object sender, EventArgs e)
        => OpenParagraphDialog(null);

    private void btnEditParagraph_Click(object sender, EventArgs e)
    {
        if (SelectedParagraphId() is { } id) OpenParagraphDialog(id);
    }

    private void dgvParagraphs_DoubleClick(object sender, EventArgs e)
    {
        if (SelectedParagraphId() is { } id) OpenParagraphDialog(id);
    }

    private async void btnDeleteParagraph_Click(object sender, EventArgs e)
    {
        if (SelectedParagraphId() is not { } id) return;

        if (MessageBox.Show("Delete this paragraph?", "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

        try
        {
            await _paragraphRepo.DeleteAsync(id);
            await RefreshParagraphsAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Delete error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
