namespace FirstWinForm;

public partial class DatabaseView : Form
{
    private int _cookies = 0;
    
    private int _perClick = 1;
    private int _perSecond = 0;

    private int _upgrade_clickCost = 10;
    private int _upgrade_perSecondCost = 25;

    private int _upgrade_clickCount = 0;
    private int _upgrade_perSecondCount = 1;
    
    public DatabaseView()
    {
        InitializeComponent();
        Update_UpgradeClickText();
        Update_UpgradePerSecondText();
    }

    private void Update_UpgradeClickText()
    {
        BuyUpgradeClick.Text = $"Buy upgrade per click\ncost: {_upgrade_clickCost}";
    }
    
    private void Update_UpgradePerSecondText()
    {
        BuyUpgradePerSecond.Text = $"Buy upgrade per second\ncost: {_upgrade_perSecondCost}";
    }
    
    private void CookieButton_Click(object sender, EventArgs e)
    {
        _cookies += _perClick;
        CookieLabel.Text = $"cookies: {_cookies}";
    }

    private void BuyUpgradeClick_Click(object sender, EventArgs e)
    {
        if (_cookies < _upgrade_clickCost) return;
        
        
    }

    private void BuyUpgradePerSecond_Click(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }
}