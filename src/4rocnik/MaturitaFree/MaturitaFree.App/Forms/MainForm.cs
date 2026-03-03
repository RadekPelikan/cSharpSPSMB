using MaturitaFree.App.Controls;
using MaturitaFree.App.Infrastructure;

namespace MaturitaFree.App.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        // --- Books tab ---
        var bookList = ServiceLocator.Instance.GetService<BookListControl>();
        bookList.Dock = DockStyle.Fill;
        tabBooks.Controls.Add(bookList);

        // --- People tab ---
        var personList = ServiceLocator.Instance.GetService<PersonListControl>();
        personList.Dock = DockStyle.Fill;
        tabPeople.Controls.Add(personList);
    }
}
