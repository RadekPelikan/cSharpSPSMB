using MaturitaFree.Common.Entities;
using MaturitaFree.Common.Repositories;

namespace MaturitaFree.App.Controls;

public partial class BookListControl : UserControl
{
    private readonly IBookRepository _bookRepository;

    public BookListControl(IBookRepository bookRepository)
    {
        InitializeComponent();
        _bookRepository = bookRepository;
    }

    private async void BookListControl_Load(object sender, EventArgs e)
        => await LoadBooksAsync();

    private async void btnRefresh_Click(object sender, EventArgs e)
        => await LoadBooksAsync();

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        var book = new BookEntity
        {
            Title = $"Test Book {DateTime.UtcNow:HH:mm:ss}",
            Description = "Auto-generated test entry",
            Chapters = [],
            Contributers = [],
        };

        btnAdd.Enabled = false;
        try
        {
            await _bookRepository.AddAsync(book);
            await LoadBooksAsync();
        }
        finally
        {
            btnAdd.Enabled = true;
        }
    }

    private async Task LoadBooksAsync()
    {
        lblStatus.Text = "Loading…";
        btnRefresh.Enabled = false;

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
        }
    }
}
