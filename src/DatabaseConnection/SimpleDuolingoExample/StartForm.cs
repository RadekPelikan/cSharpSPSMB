namespace DatabaseViewForm;

public partial class StartForm : Form
{
    private NavigationView navigationView;
    private UserView userView;

    private UserControl _currentView;
    
    public enum ViewType
    {
        Navigation,
        User
    }
    
    public StartForm()
    {
        InitializeComponent();
        navigationView = new NavigationView(this);
        userView = new UserView(this);
        SelectView(ViewType.Navigation);
    }

    public void RenderCurrentView()
    {
        this.Controls.Clear();
        this.Controls.Add(_currentView);
    }

    public void SelectView(ViewType viewType)
    {
        _currentView = viewType switch
        {
            ViewType.Navigation => navigationView,
            ViewType.User => userView,
        };
        RenderCurrentView();
    }
}