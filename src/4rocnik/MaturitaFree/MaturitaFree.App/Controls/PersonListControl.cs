using MaturitaFree.App.Forms;
using MaturitaFree.App.Infrastructure;
using MaturitaFree.Common.AppSettings;
using MaturitaFree.Common.Repositories;

namespace MaturitaFree.App.Controls;

public partial class PersonListControl : UserControl
{
    private readonly IPersonRepository _personRepository;
    private readonly ViewConfig _viewConfig;

    private int _countdownSeconds;
    private bool _suppressSelection;

    public event EventHandler<int>? PersonSelected;

    public PersonListControl(IPersonRepository personRepository, ViewConfig viewConfig)
    {
        InitializeComponent();
        _personRepository = personRepository;
        _viewConfig = viewConfig;
        dgvPeople.SelectionChanged += DgvPeople_SelectionChanged;
        dgvPeople.DoubleClick += DgvPeople_DoubleClick;
    }

    public void RequestRefresh() => _ = LoadPeopleAsync();

    public void ClearSelection()
    {
        _suppressSelection = true;
        try { dgvPeople.ClearSelection(); }
        finally { _suppressSelection = false; }
    }

    private async void PersonListControl_Load(object sender, EventArgs e)
    {
        chkAutoRefresh.Checked = _viewConfig.AutoRefreshIntervalSeconds > 0;
        UpdateAutoRefresh();
        await LoadPeopleAsync();
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
        => await LoadPeopleAsync();

    private void btnAdd_Click(object sender, EventArgs e)
        => OpenEditWindow(null);

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dgvPeople.SelectedRows.Count == 0) return;
        if (dgvPeople.SelectedRows[0].Cells["Id"].Value is int id)
            OpenEditWindow(id);
    }

    private void DgvPeople_DoubleClick(object sender, EventArgs e)
    {
        if (dgvPeople.SelectedRows.Count == 0) return;
        if (dgvPeople.SelectedRows[0].Cells["Id"].Value is int id)
            OpenEditWindow(id);
    }

    private void OpenEditWindow(int? personId)
    {
        var form = ServiceLocator.Instance.GetService<PersonEditForm>();
        if (personId.HasValue)
            form.EditPerson(personId.Value);
        else
            form.NewPerson();
        form.PersonSaved   += (_, _) => RequestRefresh();
        form.PersonDeleted += (_, _) => RequestRefresh();
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
            await LoadPeopleAsync();
        }
        lblCountdown.Text = chkAutoRefresh.Checked
            ? $"Next refresh in {_countdownSeconds}s"
            : string.Empty;
    }

    private async Task LoadPeopleAsync()
    {
        lblStatus.Text = "Loading...";
        btnRefresh.Enabled = false;
        _suppressSelection = true;

        try
        {
            var people = await _personRepository.GetAllAsync();

            dgvPeople.DataSource = people
                .Select(p => new
                {
                    p.Id,
                    FullName = string.Join(" ", new[] { p.FirstName, p.MiddleName, p.LastName }
                        .Where(s => !string.IsNullOrWhiteSpace(s))),
                    p.Pseudonym,
                    Created = p.DateCreated.ToString("yyyy-MM-dd HH:mm"),
                })
                .ToList();

            lblStatus.Text = $"{people.Count} person(s) loaded.";
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

    private void DgvPeople_SelectionChanged(object sender, EventArgs e)
    {
        if (_suppressSelection) return;
        if (dgvPeople.SelectedRows.Count == 0) return;
        if (dgvPeople.SelectedRows[0].Cells["Id"].Value is int id)
            PersonSelected?.Invoke(this, id);
    }
}
