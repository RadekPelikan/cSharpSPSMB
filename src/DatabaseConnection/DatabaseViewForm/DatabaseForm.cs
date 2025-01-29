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

    private void PopulateListView(List<User> users)
    {
        foreach (var user in users)
        {
            ListViewItem item = new ListViewItem();
            item.Text = user.Id.ToString();
            item.SubItems.Add(user.Username);
            item.SubItems.Add(user.CreatedAt.ToString());
            item.SubItems.Add(user.ModifiedAt.ToString());
            UserListView.Items.Add(item);
        }
    }

    private void FetchButton_Click(object sender, EventArgs e)
    {
        DBDriver dbDriver = new DBDriver(PasswordTextBox.Text);
        List<User> users = dbDriver.GetUsers();
        PopulateListView(users);
    }

}