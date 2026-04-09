using MaturitaFree.App.Forms;
using MaturitaFree.App.Infrastructure;
using MaturitaFree.Common.AppSettings;
using MaturitaFree.Common.Entities;
using MaturitaFree.Common.Repositories;

namespace MaturitaFree.App.Controls;

public partial class BookListControl : UserControl
{
    private readonly IBookRepository _bookRepository;
    private readonly ViewConfig _viewConfig;

    private int _countdownSeconds;
    private bool _suppressSelection;

    public event EventHandler<int>? BookSelected;

    public BookListControl(IBookRepository bookRepository, ViewConfig viewConfig)
    {
        InitializeComponent();
        _bookRepository = bookRepository;
        _viewConfig = viewConfig;
        dgvBooks.SelectionChanged += DgvBooks_SelectionChanged;
        dgvBooks.DoubleClick += DgvBooks_DoubleClick;
    }

    public void RequestRefresh() => _ = LoadBooksAsync();

    public void ClearSelection()
    {
        _suppressSelection = true;
        try { dgvBooks.ClearSelection(); }
        finally { _suppressSelection = false; }
    }

    private void DgvBooks_SelectionChanged(object sender, EventArgs e)
    {
        if (_suppressSelection) return;
        if (dgvBooks.SelectedRows.Count == 0) return;
        if (dgvBooks.SelectedRows[0].Cells["Id"].Value is int id)
            BookSelected?.Invoke(this, id);
    }

    private async void BookListControl_Load(object sender, EventArgs e)
    {
        chkAutoRefresh.Checked = _viewConfig.AutoRefreshIntervalSeconds > 0;
        UpdateAutoRefresh();
        await LoadBooksAsync();
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
        => await LoadBooksAsync();

    private void btnNew_Click(object sender, EventArgs e)
        => OpenEditWindow(null);

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dgvBooks.SelectedRows.Count == 0) return;
        if (dgvBooks.SelectedRows[0].Cells["Id"].Value is int id)
            OpenEditWindow(id);
    }

    private void DgvBooks_DoubleClick(object sender, EventArgs e)
    {
        if (dgvBooks.SelectedRows.Count == 0) return;
        if (dgvBooks.SelectedRows[0].Cells["Id"].Value is int id)
            OpenEditWindow(id);
    }

    private void OpenEditWindow(int? bookId)
    {
        var form = ServiceLocator.Instance.GetService<BookEditForm>();
        if (bookId.HasValue)
            form.EditBook(bookId.Value);
        else
            form.NewBook();
        form.BookSaved   += (_, _) => RequestRefresh();
        form.BookDeleted += (_, _) => RequestRefresh();
        form.Show(ParentForm);
    }

    private void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        => UpdateAutoRefresh();

    private void UpdateAutoRefresh()
    {
        if (chkAutoRefresh.Checked && _viewConfig.AutoRefreshIntervalSeconds > 0)
        {
            _countdownSeconds = _viewConfig.AutoRefreshIntervalSeconds;
            lblCountdown.Text = $"Next refresh in {_countdownSeconds}s";
            timerAutoRefresh.Interval = 1000;
            timerAutoRefresh.Start();
        }
        else
        {
            timerAutoRefresh.Stop();
            lblCountdown.Text = "";
        }
    }

    private async void timerAutoRefresh_Tick(object sender, EventArgs e)
    {
        _countdownSeconds--;
        if (_countdownSeconds <= 0)
        {
            _countdownSeconds = _viewConfig.AutoRefreshIntervalSeconds;
            await LoadBooksAsync();
        }
        lblCountdown.Text = chkAutoRefresh.Checked
            ? $"Next refresh in {_countdownSeconds}s"
            : string.Empty;
    }

    private async Task LoadBooksAsync()
    {
        lblStatus.Text = "Loading...";
        btnRefresh.Enabled = false;

        _suppressSelection = true;
        try
        {
            var books = await _bookRepository.GetAllAsync();

            dgvBooks.DataSource = books
                .Select(b => new
                {
                    b.Id,
                    b.Title,
                    b.Description,
                    Created = b.DateCreated.ToString("yyyy-MM-dd HH:mm"),
                })
                .ToList();

            lblStatus.Text = $"{books.Count} book(s) loaded.";
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Error: {ex.Message}";
            MessageBox.Show(ex.Message, "Load error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnRefresh.Enabled = true;
            _suppressSelection = false;
        }
    }
}
