namespace DatabaseViewForm;

public partial class DatabaseForm : Form
{
    public DatabaseForm()
    {
        InitializeComponent();
    }
    

    private void PasswordTextBox_Enter(object sender, EventArgs e)
    {
        PasswordTextBox.Text = "";

        PasswordTextBox.ForeColor = Color.Black;

        PasswordTextBox.UseSystemPasswordChar = true;
    }

    private void PasswordTextBox_Leave(object sender, EventArgs e)
    {
        if (PasswordTextBox.Text.Length == 0)
        {
            PasswordTextBox.ForeColor = Color.Gray;

            PasswordTextBox.Text = "Enter password";

            PasswordTextBox.UseSystemPasswordChar = false;

            SelectNextControl(PasswordTextBox, true, true, false, true);
        }
    }

    private void FetchButton_Click(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }
}