using UserControlViews.components;
using UserControlViews.Views;

namespace UserControlViews;

public partial class BaseForm : Form
{
    private NavigationView _navigationView;
    private StandaView _standaView;
    private ZdarskyView _zdarskyView;
    private List<NameView> _nameViews = new List<NameView>();
    

    private UserControl _currentView;

    public enum ViewType
    {
        Navigation,
        Standa,
        Zdarsky,
        // Zdarsky_RED,
        // Zdarsky_BLUE,
        // Zdarsky_GREEN,
        Pepa1,
        Pepa2,
        Pepa3
    }

    public BaseForm()
    {
        InitializeComponent();
        _navigationView = new NavigationView(this)
        {
            Dock = DockStyle.Top,
            Size = Size with { Height = 300 }
        };
        _standaView = new StandaView(this)
        {
            Dock = DockStyle.Top,
            Size = Size with { Height = 300 }
        };
        _zdarskyView = new ZdarskyView(this)
        {
            Dock = DockStyle.Top,
            Size = Size with { Height = 300 }
        };

        for (int i = 0; i < 3; ++i)
        {
            _nameViews.Add(new NameView(this, $"Pepa{i}")
            {
                Dock = DockStyle.Top,
                Size = Size with { Height = 300 }
            });
        }

        SwitchView(ViewType.Navigation);
    }

    public void SwitchView(ViewType viewType)
    {
        FlowLayoutPanel container = new FlowLayoutPanel()
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoScroll = false,
        };

        Controls.Clear();

        _currentView = viewType switch
        {
            ViewType.Navigation => _navigationView,
            ViewType.Standa => _standaView,
            ViewType.Zdarsky => _zdarskyView,
            // ViewType.Zdarsky_RED => _zdarskyView.ColoredCopy(Color.Red),
            // ViewType.Zdarsky_BLUE => _zdarskyView.ColoredCopy(Color.Blue),
            // ViewType.Zdarsky_GREEN => _zdarskyView.ColoredCopy(Color.Green),
            ViewType.Pepa1 => _nameViews[0],
            ViewType.Pepa2 => _nameViews[1],
            ViewType.Pepa3 => _nameViews[2],
        };

        ViewType previous = viewType - 1;
        if (viewType == 0)
            previous = Enum.GetValues(typeof(ViewType)).Cast<ViewType>().Last();
        ViewType next = viewType + 1;
        if (viewType == Enum.GetValues(typeof(ViewType)).Cast<ViewType>().Last())
            next = 0;

        NextPrevious nextPreviousButtons = new NextPrevious(this, previous, next);

        container.Controls.Add(nextPreviousButtons);
        container.Controls.Add(_currentView);

        Controls.Add(container);
    }
}