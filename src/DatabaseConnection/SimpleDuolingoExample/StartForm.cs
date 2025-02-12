namespace DatabaseViewForm;

public partial class StartForm : Form
{
    public StartForm()
    {
        InitializeComponent();
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
        var userView = new UserView();
        this.Controls.Add(userView);
    }
}