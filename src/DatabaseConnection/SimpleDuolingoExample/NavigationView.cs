namespace DatabaseViewForm;

public partial class NavigationView : UserControl
{
    private readonly StartForm _parentForm;

    public NavigationView(StartForm parentForm)
    {
        _parentForm = parentForm;
        InitializeComponent();
    }
    
    private void button1_Click_1(object sender, EventArgs e)
    {
        Console.WriteLine("SWITCH");
        _parentForm.SelectView(StartForm.ViewType.User);
    }
}
