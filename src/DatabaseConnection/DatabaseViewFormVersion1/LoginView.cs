using DatabaseViewForm;

namespace DatabaseViewFormVersion1;

public partial class LoginView : UserControl
{
    private Main _main;
    
    public LoginView(Main main)
    {
        _main = main;
        
        InitializeComponent();
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        TryToLogin();
    }

    private void TryToLogin()
    {
        DBDriver dbDriver = new DBDriver(textBox1.Text);
        textBox1.Text = "";   
        try
        {
            dbDriver.GetUsers();
            _main.SwitchView(_main.GetView(1));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void textBox1_Enter(object sender, EventArgs e)
    {
        textBox1.Text = "";

        textBox1.ForeColor = Color.Black;

        textBox1.UseSystemPasswordChar = true;
    }

    private void textBox1_Leave(object sender, EventArgs e)
    {
        if (textBox1.Text.Length == 0)
        {
            textBox1.ForeColor = Color.Gray;

            textBox1.Text = "Enter password";

            textBox1.UseSystemPasswordChar = false;

            SelectNextControl(textBox1, true, true, false, true);
        }
    }

    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (int) Keys.Enter)
        {
            TryToLogin();
        }
    }
}