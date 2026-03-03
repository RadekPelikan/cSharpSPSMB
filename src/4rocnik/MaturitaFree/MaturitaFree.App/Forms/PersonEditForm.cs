using MaturitaFree.App.Controls;

namespace MaturitaFree.App.Forms;

/// <summary>Standalone window that hosts a <see cref="PersonEditControl"/>.</summary>
public partial class PersonEditForm : Form
{
    private readonly PersonEditControl _editControl;

    public event EventHandler? PersonSaved;
    public event EventHandler? PersonDeleted;

    public PersonEditForm(PersonEditControl editControl)
    {
        InitializeComponent();
        _editControl = editControl;
        _editControl.Dock = DockStyle.Fill;
        Controls.Add(_editControl);

        _editControl.PersonSaved   += (s, e) => PersonSaved?.Invoke(s, e);
        _editControl.PersonDeleted += (s, e) => { PersonDeleted?.Invoke(s, e); Close(); };
        _editControl.NewRequested  += (_, _) => _editControl.ClearForm();
    }

    /// <summary>Opens the form ready to create a new person.</summary>
    public void NewPerson()
    {
        _editControl.ClearForm();
        Text = "New Person";
    }

    /// <summary>Opens the form pre-loaded with <paramref name="personId"/>.</summary>
    public void EditPerson(int personId)
    {
        _editControl.LoadPerson(personId);
        Text = "Edit Person";
    }
}
