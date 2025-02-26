namespace UserControlViews.Views;

public partial class StandaView : UserControl
{
    private readonly BaseForm _parentForm;

    public StandaView(BaseForm parentForm)
    {
        _parentForm = parentForm;
        InitializeComponent();
    }

    private void BackButton_Click(object sender, EventArgs e)
    {
        _parentForm.SwitchView(0);
    }
}