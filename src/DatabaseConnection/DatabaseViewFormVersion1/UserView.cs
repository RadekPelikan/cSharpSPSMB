using DatabaseViewForm;

namespace DatabaseViewFormVersion1;

public partial class UserView : UserControl
{
    private DBDriver dbDriver = null;
    private Main _main;
    
    public UserView(Main main)
    {
        _main = main;
        InitializeComponent();
    }

    private void PopulateListView(List<User> users)
    {
        UserListView.Items.Clear();
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
        UpdateTable();
    }

    private void UpdateTable()
    {
        if(dbDriver == null) dbDriver = DBDriver.GetInstanceOrNull();
        try
        {
            List<User> users = dbDriver.GetUsers();
            PopulateListView(users);
        }
        catch (Exception e)
        {
            UserListView.Items.Clear();
            dbDriver = null;
            PrintError(e.Message);
        } 
    }

    private void PrintError(string error)
    {
        ErrorLabel.Visible = true;
        ErrorLabel.Text = error;
        ErrorLabel.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
    }
     
    private void PasswordTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (int) Keys.Enter)
        {
            UpdateTable();
        }
    }

    private void username_Enter(object sender, EventArgs e)
    {
        username.Text = "";

        //username.ForeColor = Color.Black;
    }

    private void username_Leave(object sender, EventArgs e)
    {
        if (username.Text.Length == 0)
        {
            //username.ForeColor = Color.Gray;

            username.Text = "Enter username";

            SelectNextControl(username, true, true, false, true);
        }
    }

    private void AddUser()
    {
        if (username.Text.Trim() != "")
        {
            dbDriver.AddUser(username.Text.Trim());
            UpdateTable();
            username.Text = "";
        }
    }
    
    private void usernameButton_Click(object sender, EventArgs e)
    {
        AddUser();
    }

    private void username_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (int) Keys.Enter)
        {
            AddUser();
        }
    }

    private void RemoveUsers()
    {
        if (IdBox.Text.Trim() != "")
        {
            string[] s = IdBox.Text.Split(",");
            bool foundError = false;
            List<int> ids = new List<int>();
            foreach (var ss in s)
            {
                if (int.TryParse(ss.Trim(), out int id))
                {
                    ids.Add(id);
                }
                else
                {
                    PrintError("Špatně zadaná hodnota");
                    foundError = true;
                }
            }

            if (!foundError)
            {
                bool foundError2 = false;
                foreach (int id in ids)
                {
                    if (!dbDriver.RemoveUser(id)) foundError2 = true;
                }

                UpdateTable();
                PrintError("");
                if (foundError2)
                {
                    PrintError("Špatně zadaná hodnota");
                }
            }
            
            IdBox.Text = "";
        }
    }

    private void IdButton_Click(object sender, EventArgs e)
    {
        RemoveUsers();
    }

    private void IdBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (int) Keys.Enter)
        {
            RemoveUsers();
        }
    }

    private void finding_KeyUp(object sender, KeyEventArgs e)
    {
        UpdateTable();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        _main.SwitchView(_main.GetView(1));
    }

    private void UserForm_Load(object sender, EventArgs e)
    {
        UpdateTable();
    }
}