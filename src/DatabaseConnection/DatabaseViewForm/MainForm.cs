namespace DatabaseViewForm;

public partial class MainForm : Form
{
    public static Panel MainPanel;
    
    public MainForm()
    {
        InitializeComponent();
        MainPanel = panel1;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        LoginForm loginForm = new LoginForm();
        loginForm.Dock = DockStyle.Fill;
        loginForm.TopLevel = false;
        panel1.Controls.Clear();
        panel1.Controls.Add(loginForm);
        loginForm.Show();
    }
}