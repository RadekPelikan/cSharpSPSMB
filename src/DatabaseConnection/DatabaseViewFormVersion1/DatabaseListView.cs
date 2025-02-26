namespace DatabaseViewFormVersion1;

public partial class DatabaseListView : UserControl
{
    private Main _main;
    
    public DatabaseListView(Main main)
    {
        _main = main;
        InitializeComponent();
    }
    private void Languages_Click(object sender, EventArgs e)
    {
        _main.SwitchView(_main.GetView(2));
    }

    private void Users_Click(object sender, EventArgs e)
    {
        _main.SwitchView(_main.GetView(3));
    }

    private void USER_LANGUAGE_RELATION_Click(object sender, EventArgs e)
    {
        _main.SwitchView(_main.GetView(4));
    }
}