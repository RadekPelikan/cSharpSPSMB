namespace UserControlViews.components;

public partial class NextPrevious : UserControl
{
    private readonly BaseForm _parentForm;
    private readonly int _previous;
    private readonly int _next;

    public NextPrevious(BaseForm parentForm, int previous, int next)
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