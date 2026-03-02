using MaturitaFree.App.Controls;
using MaturitaFree.App.Infrastructure;

namespace MaturitaFree.App.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        // Resolve the book list control from DI so it gets its dependencies injected
        var bookListControl = ServiceLocator.Instance.GetService<BookListControl>();
        bookListControl.Dock = DockStyle.Fill;
        pnlContent.Controls.Add(bookListControl);
    }
}
