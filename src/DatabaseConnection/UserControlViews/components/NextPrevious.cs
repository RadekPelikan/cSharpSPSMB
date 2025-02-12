namespace UserControlViews.components;

public partial class NextPrevious : UserControl
{
    private readonly BaseForm _parentForm;
    private readonly BaseForm.ViewType _previous;
    private readonly BaseForm.ViewType _next;

    public NextPrevious(BaseForm parentForm, BaseForm.ViewType previous, BaseForm.ViewType next)
    {
        _parentForm = parentForm;
        _previous = previous;
        _next = next;
        InitializeComponent();
    }

    private void NextButton_Click(object sender, EventArgs e)
    {
        _parentForm.SwitchView(_next);
    }

    private void PreviousButton_Click(object sender, EventArgs e)
    {
        _parentForm.SwitchView(_previous);
    }
}