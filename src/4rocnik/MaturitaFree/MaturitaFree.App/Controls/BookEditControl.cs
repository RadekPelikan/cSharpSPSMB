using MaturitaFree.App.Forms;
using MaturitaFree.App.Infrastructure;
using MaturitaFree.Common.Entities;
using MaturitaFree.Common.Repositories;

namespace MaturitaFree.App.Controls;

public partial class BookEditControl : UserControl
{
    private readonly IBookRepository _bookRepository;
    private readonly IBookChapterRepository _chapterRepository;
    private readonly IPersonWorkingOnBookRepository _linkRepository;

    private int? _currentBookId;

    public event EventHandler? BookSaved;
    public event EventHandler? BookDeleted;
    public event EventHandler? NewRequested;

    public BookEditControl(
        IBookRepository bookRepository,
        IBookChapterRepository chapterRepository,
        IPersonWorkingOnBookRepository linkRepository)
    {
        InitializeComponent();
        _bookRepository = bookRepository;
        _chapterRepository = chapterRepository;
        _linkRepository = linkRepository;
        SetFormState(isNew: true);
    }

    // ── Public API ───────────────────────────────────────────────────────────

    public void LoadBook(int bookId) => _ = LoadBookAsync(bookId);

    private async Task LoadBookAsync(int bookId)
    {
        var book = await _bookRepository.GetByIdAsync(bookId);
        if (book is null) return;

        _currentBookId = book.Id;
        txtTitle.Text = book.Title;
        txtDescription.Text = book.Description ?? string.Empty;
        SetFormState(isNew: false);
        lblStatus.Text = "";

        await Task.WhenAll(RefreshChaptersAsync(), RefreshContributorsAsync());
    }

    public void ClearForm()
    {
        _currentBookId = null;
        txtTitle.Text = "";
        txtDescription.Text = "";
        dgvChapters.DataSource = null;
        dgvContributors.DataSource = null;
        SetFormState(isNew: true);
        lblStatus.Text = "";
        txtTitle.Focus();
    }

    private void SetFormState(bool isNew)
    {
        btnDelete.Enabled = !isNew;
        tabChapters.Enabled = !isNew;
        tabContributors.Enabled = !isNew;
        lblHeading.Text = isNew ? "Add Book" : "Edit Book";
    }

    // ── Chapters ─────────────────────────────────────────────────────────────

    private async Task RefreshChaptersAsync()
    {
        if (_currentBookId is null) return;
        var chapters = await _chapterRepository.GetByBookIdAsync(_currentBookId.Value);
        dgvChapters.DataSource = chapters
            .Select(c => new { c.Id, c.Order, c.Title })
            .ToList();
        if (dgvChapters.Columns.Contains("Id"))
            dgvChapters.Columns["Id"]!.Visible = false;
    }

    private int? SelectedChapterId()
    {
        if (dgvChapters.SelectedRows.Count == 0) return null;
        return dgvChapters.SelectedRows[0].Cells["Id"].Value as int?;
    }

    private void OpenChapterDialog(int? chapterId)
    {
        if (_currentBookId is null) return;
        using var dlg = ServiceLocator.Instance.GetService<BookChapterEditForm>();
        if (chapterId.HasValue)
            dlg.LoadChapter(chapterId.Value);
        else
            dlg.SetBook(_currentBookId.Value);
        if (dlg.ShowDialog(this) == DialogResult.OK)
            _ = RefreshChaptersAsync();
    }

    private void btnAddChapter_Click(object sender, EventArgs e) => OpenChapterDialog(null);

    private void btnEditChapter_Click(object sender, EventArgs e)
    {
        if (SelectedChapterId() is { } id) OpenChapterDialog(id);
    }

    private void dgvChapters_DoubleClick(object sender, EventArgs e)
    {
        if (SelectedChapterId() is { } id) OpenChapterDialog(id);
    }

    private async void btnDeleteChapter_Click(object sender, EventArgs e)
    {
        if (SelectedChapterId() is not { } id) return;
        if (MessageBox.Show("Delete this chapter and all its paragraphs?", "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
        try
        {
            await _chapterRepository.DeleteAsync(id);
            await RefreshChaptersAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Delete error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ── Contributors ─────────────────────────────────────────────────────────

    private async Task RefreshContributorsAsync()
    {
        if (_currentBookId is null) return;
        var links = await _linkRepository.GetByBookIdAsync(_currentBookId.Value);
        dgvContributors.DataSource = links
            .Select(l => new
            {
                l.Id,
                Person = FormatPersonName(l.Person),
                Role = l.Type.ToString(),
                l.Description,
            })
            .ToList();
        if (dgvContributors.Columns.Contains("Id"))
            dgvContributors.Columns["Id"]!.Visible = false;
    }

    private int? SelectedContributorId()
    {
        if (dgvContributors.SelectedRows.Count == 0) return null;
        return dgvContributors.SelectedRows[0].Cells["Id"].Value as int?;
    }

    private void OpenContributorDialog(int? linkId)
    {
        if (_currentBookId is null) return;
        using var dlg = ServiceLocator.Instance.GetService<PersonWorkingOnBookEditForm>();
        if (linkId.HasValue)
            dlg.LoadLink(linkId.Value);
        else
            dlg.SetBook(_currentBookId.Value);
        if (dlg.ShowDialog(this) == DialogResult.OK)
            _ = RefreshContributorsAsync();
    }

    private void btnAddContributor_Click(object sender, EventArgs e) => OpenContributorDialog(null);

    private void btnEditContributor_Click(object sender, EventArgs e)
    {
        if (SelectedContributorId() is { } id) OpenContributorDialog(id);
    }

    private void dgvContributors_DoubleClick(object sender, EventArgs e)
    {
        if (SelectedContributorId() is { } id) OpenContributorDialog(id);
    }

    private async void btnRemoveContributor_Click(object sender, EventArgs e)
    {
        if (SelectedContributorId() is not { } id) return;
        if (MessageBox.Show("Remove this contributor from the book?", "Confirm remove",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
        try
        {
            await _linkRepository.DeleteAsync(id);
            await RefreshContributorsAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Remove error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ── Save / Delete ────────────────────────────────────────────────────────

    private async void btnSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTitle.Text))
        {
            MessageBox.Show("Title is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tabContent.SelectedTab = tabDetails;
            txtTitle.Focus();
            return;
        }

        btnSubmit.Enabled = false;
        try
        {
            if (_currentBookId.HasValue)
            {
                var book = await _bookRepository.GetByIdAsync(_currentBookId.Value);
                if (book is null) return;

                book.Title = txtTitle.Text.Trim();
                book.Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim();
                await _bookRepository.UpdateAsync(book);
                lblStatus.Text = "Saved.";
            }
            else
            {
                var book = new BookEntity
                {
                    Title = txtTitle.Text.Trim(),
                    Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim(),
                    Chapters = [],
                    Contributers = [],
                };
                await _bookRepository.AddAsync(book);
                _currentBookId = book.Id;
                SetFormState(isNew: false);
                lblStatus.Text = "Book added.";
            }

            BookSaved?.Invoke(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Error: {ex.Message}";
            MessageBox.Show(ex.Message, "Save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnSubmit.Enabled = true;
        }
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (!_currentBookId.HasValue) return;

        if (MessageBox.Show("Delete this book?", "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            return;

        btnDelete.Enabled = false;
        try
        {
            await _bookRepository.DeleteAsync(_currentBookId.Value);
            ClearForm();
            BookDeleted?.Invoke(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Error: {ex.Message}";
            MessageBox.Show(ex.Message, "Delete error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            btnDelete.Enabled = true;
        }
    }

    private void btnNew_Click(object sender, EventArgs e)
    {
        ClearForm();
        NewRequested?.Invoke(this, EventArgs.Empty);
    }

    // ── Helpers ──────────────────────────────────────────────────────────────

    private static string FormatPersonName(PersonEntity? p)
    {
        if (p is null) return "(unknown)";
        var parts = new[] { p.FirstName, p.MiddleName, p.LastName }
            .Where(s => !string.IsNullOrWhiteSpace(s));
        var full = string.Join(" ", parts);
        return string.IsNullOrWhiteSpace(p.Pseudonym)
            ? full
            : string.IsNullOrEmpty(full) ? p.Pseudonym : $"{full} ({p.Pseudonym})";
    }
}
