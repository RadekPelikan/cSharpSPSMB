using UserControlViews.components;
using UserControlViews.Views;

namespace UserControlViews;

public partial class BaseForm : Form
{
    private List<UserControl> _views = new List<UserControl>();

    private UserControl _currentView;
    

    public BaseForm()
    {
        InitializeComponent();
        _views.Add(new NavigationView(this)
        {
            Dock = DockStyle.Top,
            Size = Size with { Height = 300 }
        });
        _views.Add(new StandaView(this)
        {
            Dock = DockStyle.Top,
            Size = Size with { Height = 300 }
        });
        _views.Add(new ZdarskyView(this)
        {
            Dock = DockStyle.Top,
            Size = Size with { Height = 300 }
        });

        for (int i = 0; i < 3; ++i)
        {
            _views.Add(new NameView(this, $"Pepa{i}")
            {
                Dock = DockStyle.Top,
                Size = Size with { Height = 300 }
            });
        }

        SwitchView(0);
    }

    public void SwitchView(int index)
    {
        FlowLayoutPanel container = new FlowLayoutPanel()
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoScroll = false,
        };

        Controls.Clear();
        
        _currentView = _views[index];

        int previous = index - 1;
        if (index == 0)
            previous = _views.Count - 1;
        int next = index + 1;
        if (index == _views.Count - 1)
            next = 0;

        NextPrevious nextPreviousButtons = new NextPrevious(this, previous, next);

        container.Controls.Add(nextPreviousButtons);
        container.Controls.Add(_currentView);

        Controls.Add(container);
    }
}