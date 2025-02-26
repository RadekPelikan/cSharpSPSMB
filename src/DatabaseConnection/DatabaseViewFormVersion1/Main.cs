namespace DatabaseViewFormVersion1;

public partial class Main : Form
{
    
    private UserControl _currentView;

    private List<UserControl> views;
    
    public Main()
    {
        InitializeComponent();
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        views = new List<UserControl>();
        views.Add(new LoginView(this));
        views.Add(new DatabaseListView(this));
        views.Add(new LanguageView(this));
        views.Add(new UserView(this));
        views.Add(new RegistrationView(this));
        SwitchView(GetView(0));
    }

    public void SwitchView(UserControl control)
    {
        Controls.Remove(_currentView);
        _currentView = control;
        Controls.Add(_currentView);
    }

    public UserControl GetView(int i)
    {
        return views[i];
    }
}