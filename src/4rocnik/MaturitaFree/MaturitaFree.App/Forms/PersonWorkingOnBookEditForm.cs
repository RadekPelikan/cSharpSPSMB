using MaturitaFree.Common.Entities;
using MaturitaFree.Common.Repositories;

namespace MaturitaFree.App.Forms;

public partial class PersonWorkingOnBookEditForm : Form
{
    private readonly IPersonWorkingOnBookRepository _linkRepo;
    private readonly IPersonRepository _personRepo;

    private int _bookId;
    private int? _linkId;

    public PersonWorkingOnBookEditForm(
        IPersonWorkingOnBookRepository linkRepo,
        IPersonRepository personRepo)
    {
        InitializeComponent();
        _linkRepo = linkRepo;
        _personRepo = personRepo;

        // Populate ContributorType combo
        cmbType.DataSource = Enum.GetValues<ContributorType>();
    }

    // ── Initialisation ───────────────────────────────────────────────────────

    /// <summary>Configures for adding a new contributor to <paramref name="bookId"/>.</summary>
    public void SetBook(int bookId)
    {
        _bookId = bookId;
        _linkId = null;
        Text = "Add Contributor";
        lblHeading.Text = "Add Contributor";
        _ = LoadPeopleAsync();
    }

    /// <summary>Configures for editing an existing contributor link.</summary>
    public void LoadLink(int linkId) => _ = LoadLinkAsync(linkId);

    private async Task LoadPeopleAsync()
    {
        var people = await _personRepo.GetAllAsync();
        cmbPerson.DataSource = people
            .OrderBy(p => p.LastName)
            .ThenBy(p => p.FirstName)
            .Select(p => new PersonItem(p.Id, FormatPersonName(p)))
            .ToList();
        cmbPerson.DisplayMember = "Label";
        cmbPerson.ValueMember = "Id";
    }

    private async Task LoadLinkAsync(int linkId)
    {
        var link = await _linkRepo.GetByIdAsync(linkId);
        if (link is null) return;

        _bookId = link.BookId;
        _linkId = link.Id;

        Text = "Edit Contributor";
        lblHeading.Text = "Edit Contributor";

        await LoadPeopleAsync();
        cmbPerson.SelectedValue = link.PersonId;
        cmbType.SelectedItem = link.Type;
        txtDescription.Text = link.Description ?? string.Empty;
    }

    // ── Event handlers ───────────────────────────────────────────────────────

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (cmbPerson.SelectedValue is not int personId)
        {
            MessageBox.Show("Please select a person.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbPerson.Focus();
            return;
        }

        if (cmbType.SelectedItem is not ContributorType type)
        {
            MessageBox.Show("Please select a contributor type.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        btnSave.Enabled = false;
        lblStatus.Text = "";
        try
        {
            string? description = string.IsNullOrWhiteSpace(txtDescription.Text)
                ? null : txtDescription.Text.Trim();

            if (_linkId.HasValue)
            {
                var link = await _linkRepo.GetByIdAsync(_linkId.Value);
                if (link is null) return;

                link.Type = type;
                link.Description = description;
                await _linkRepo.UpdateAsync(link);
            }
            else
            {
                var link = new PersonWorkingOnBook
                {
                    BookId = _bookId,
                    PersonId = personId,
                    Type = type,
                    Description = description,
                };
                await _linkRepo.AddAsync(link);
                _linkId = link.Id;
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

    // ── Helpers ──────────────────────────────────────────────────────────────

    private static string FormatPersonName(PersonEntity p)
    {
        var parts = new[] { p.FirstName, p.MiddleName, p.LastName }
            .Where(s => !string.IsNullOrWhiteSpace(s));
        var full = string.Join(" ", parts);
        return string.IsNullOrWhiteSpace(p.Pseudonym)
            ? full
            : string.IsNullOrEmpty(full) ? p.Pseudonym : $"{full} ({p.Pseudonym})";
    }

    private sealed record PersonItem(int Id, string Label);
}
