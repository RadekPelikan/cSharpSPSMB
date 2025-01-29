namespace DatabaseViewForm;

public partial class DatabaseForm : Form
{

    private DBDriver dbDriver = null;
    
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
        UserListView.Items.Clear();
        foreach (var user in users)
        {
            if (user.Username.ToLower().Contains(finding.Text.ToLower()))
            {
                ListViewItem item = new ListViewItem();
                item.Text = user.Id.ToString();
                item.SubItems.Add(user.Username);
                item.SubItems.Add(user.CreatedAt.ToString());
                item.SubItems.Add(user.ModifiedAt.ToString());
                UserListView.Items.Add(item);
            }
        }
    }

    private void FetchButton_Click(object sender, EventArgs e)
    {
        UpdateTable();
    }

    private void UpdateTable()
    {
        if(dbDriver == null) dbDriver = new DBDriver(PasswordTextBox.Text);
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
        PasswordTextBox.Text = "";
        
    }

    private void PrintError(string error)
    {
        ErrorLabel.Visible = true;
        ErrorLabel.Text = error;
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

        username.ForeColor = Color.Black;
    }

    private void username_Leave(object sender, EventArgs e)
    {
        if (username.Text.Length == 0)
        {
            username.ForeColor = Color.Gray;

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
                foreach (int id in ids)
                {
                    dbDriver.RemoveUser(id);
                }

                UpdateTable();
                PrintError("");
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

    private void UpdateName()
    {
        if (!nameBox.Text.Trim().Equals("") && !idBox2.Text.Trim().Equals(""))
        {
            if (int.TryParse(idBox2.Text.Trim(), out int id))
            {
                dbDriver.UpdateName(nameBox.Text, id);
                UpdateTable(); 
            }
        }   
    }
    
    private void nameButton_Click(object sender, EventArgs e)
    {
        UpdateName();
    }
    
    private void nameBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if(e.KeyChar == (int) Keys.Enter)
            UpdateName();
    }
}