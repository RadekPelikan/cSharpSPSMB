namespace UserControlViews.Views;

public partial class NameView : UserControl
{
    private readonly BaseForm _parentForm;

    public NameView(BaseForm parentForm, string name)
    {
        InitializeComponent();
        _parentForm = parentForm;
        NameLabel.Text = name;
    }

    private void BackButton_Click(object sender, EventArgs e)
    {
        _parentForm.SwitchView(0);
    }
}