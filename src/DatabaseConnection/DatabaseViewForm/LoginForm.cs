namespace DatabaseViewForm;

public partial class LoginForm : Form
{
    public LoginForm()
    {
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
            DatabaseListForm databaseListForm = new DatabaseListForm();
            databaseListForm.Dock = DockStyle.Fill;
            databaseListForm.TopLevel = false;
            MainForm.MainPanel.Controls.Clear();
            MainForm.MainPanel.Controls.Add(databaseListForm);
            databaseListForm.Show();
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