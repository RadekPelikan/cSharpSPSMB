using MaturitaFree.Common.Entities;
using MaturitaFree.Common.Repositories;

namespace MaturitaFree.App.Controls;

public partial class PersonEditControl : UserControl
{
    private readonly IPersonRepository _personRepository;
    private int? _currentPersonId;

    public event EventHandler? PersonSaved;
    public event EventHandler? PersonDeleted;
    public event EventHandler? NewRequested;

    public PersonEditControl(IPersonRepository personRepository)
    {
        InitializeComponent();
        _personRepository = personRepository;
        SetFormState(isNew: true);
    }

    public void LoadPerson(int personId) => _ = LoadPersonAsync(personId);

    private async Task LoadPersonAsync(int personId)
    {
        var person = await _personRepository.GetByIdAsync(personId);
        if (person is null) return;

        _currentPersonId = person.Id;
        txtFirstName.Text = person.FirstName ?? string.Empty;
        txtMiddleName.Text = person.MiddleName ?? string.Empty;
        txtLastName.Text = person.LastName ?? string.Empty;
        txtPseudonym.Text = person.Pseudonym ?? string.Empty;
        txtDescription.Text = person.Description ?? string.Empty;
        SetFormState(isNew: false);
        lblStatus.Text = "";
    }

    public void ClearForm()
    {
        _currentPersonId = null;
        txtFirstName.Text = "";
        txtMiddleName.Text = "";
        txtLastName.Text = "";
        txtPseudonym.Text = "";
        txtDescription.Text = "";
        SetFormState(isNew: true);
        lblStatus.Text = "";
        txtFirstName.Focus();
    }

    private void SetFormState(bool isNew)
    {
        btnDelete.Enabled = !isNew;
        lblHeading.Text = isNew ? "Add Person" : "Edit Person";
    }

    private async void btnSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtFirstName.Text) &&
            string.IsNullOrWhiteSpace(txtLastName.Text) &&
            string.IsNullOrWhiteSpace(txtPseudonym.Text))
        {
            MessageBox.Show("Provide at least a first name, last name, or pseudonym.",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        btnSubmit.Enabled = false;
        try
        {
            string? Trim(string s) => string.IsNullOrWhiteSpace(s) ? null : s.Trim();

            if (_currentPersonId.HasValue)
            {
                var person = await _personRepository.GetByIdAsync(_currentPersonId.Value);
                if (person is null) return;

                person.FirstName = Trim(txtFirstName.Text);
                person.MiddleName = Trim(txtMiddleName.Text);
                person.LastName = Trim(txtLastName.Text);
                person.Pseudonym = Trim(txtPseudonym.Text);
                person.Description = Trim(txtDescription.Text);
                await _personRepository.UpdateAsync(person);
                lblStatus.Text = "Saved.";
            }
            else
            {
                var person = new PersonEntity
                {
                    FirstName = Trim(txtFirstName.Text),
                    MiddleName = Trim(txtMiddleName.Text),
                    LastName = Trim(txtLastName.Text),
                    Pseudonym = Trim(txtPseudonym.Text),
                    Description = Trim(txtDescription.Text),
                    WorkedOnBooks = [],
                };
                await _personRepository.AddAsync(person);
                _currentPersonId = person.Id;
                SetFormState(isNew: false);
                lblStatus.Text = "Person added.";
            }

            PersonSaved?.Invoke(this, EventArgs.Empty);
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
        if (!_currentPersonId.HasValue) return;

        if (MessageBox.Show("Delete this person?", "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            return;

        btnDelete.Enabled = false;
        try
        {
            await _personRepository.DeleteAsync(_currentPersonId.Value);
            ClearForm();
            PersonDeleted?.Invoke(this, EventArgs.Empty);
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
}
