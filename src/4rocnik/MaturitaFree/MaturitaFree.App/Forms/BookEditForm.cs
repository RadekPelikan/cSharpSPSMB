using MaturitaFree.App.Controls;

namespace MaturitaFree.App.Forms;

/// <summary>Standalone window that hosts a <see cref="BookEditControl"/>.</summary>
public partial class BookEditForm : Form
{
    private readonly BookEditControl _editControl;

    public event EventHandler? BookSaved;
    public event EventHandler? BookDeleted;

    public BookEditForm(BookEditControl editControl)
    {
        InitializeComponent();
        _editControl = editControl;
        _editControl.Dock = DockStyle.Fill;
        Controls.Add(_editControl);

        _editControl.BookSaved   += (s, e) => BookSaved?.Invoke(s, e);
        _editControl.BookDeleted += (s, e) => { BookDeleted?.Invoke(s, e); Close(); };
        _editControl.NewRequested += (_, _) => _editControl.ClearForm();
    }

    /// <summary>Opens the form ready to create a new book.</summary>
    public void NewBook()
    {
        _editControl.ClearForm();
        Text = "New Book";
    }

    /// <summary>Opens the form pre-loaded with <paramref name="bookId"/>.</summary>
    public void EditBook(int bookId)
    {
        _editControl.LoadBook(bookId);
        Text = "Edit Book";
    }
}
