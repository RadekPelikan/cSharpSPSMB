namespace UserControlViews.Views;

public partial class NavigationView : UserControl
{
    private readonly BaseForm _parentForm;

    public NavigationView(BaseForm parentForm)
    {
        _parentForm = parentForm;
        InitializeComponent();
    }

    private void StandaViewButton_Click(object? sender, EventArgs e)
    {
        _parentForm.SwitchView(0);
    }

    private void ZdarskyViewButton_Click(object? sender, EventArgs e)
    {
        _parentForm.SwitchView(0);
    }
}