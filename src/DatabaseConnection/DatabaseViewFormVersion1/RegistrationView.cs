using DatabaseViewForm;

namespace DatabaseViewFormVersion1;

public partial class RegistrationView : UserControl
{
    private DBDriver dbDriver = null;
    private Main _main;
    
    public RegistrationView(Main main)
    {
        _main = main;
        InitializeComponent();
    }

    private void PopulateListView(List<Language> languages, List<User> users, List<Registration> registrations)
    {
        
        RegistrationListView.Items.Clear();
        foreach (var registration in registrations)
        {
            ListViewItem item = new ListViewItem();
            item.Text = registration.Id.ToString();
            item.SubItems.Add(registration.UserId.ToString());
            item.SubItems.Add(registration.LanguageId.ToString());
            RegistrationListView.Items.Add(item);
        }
        
        UserListView.Items.Clear();
        foreach (var user in users)
        {
            ListViewItem item = new ListViewItem();
            item.Text = user.Id.ToString();
            item.SubItems.Add(user.Username);
            UserListView.Items.Add(item);
        }
        
        LanguageListView.Items.Clear();
        foreach (var language in languages)
        {
            ListViewItem item = new ListViewItem();
            item.Text = language.Id.ToString();
            item.SubItems.Add(language.Name);
            LanguageListView.Items.Add(item);
        }
    }

    private void UpdateTable()
    {
        if(dbDriver == null) dbDriver = DBDriver.GetInstanceOrNull();
        try
        {
            List<Language> languages = dbDriver.GetLanguages();
            List<User> users = dbDriver.GetUsers();
            List<Registration> registrations = dbDriver.GetRegistrations();
            PopulateListView(languages, users, registrations);
        }
        catch (Exception e)
        {
            UserListView.Items.Clear();
            LanguageListView.Items.Clear();
            RegistrationListView.Items.Clear();
            dbDriver = null;
            PrintError(e.Message);
        } 
    }

    private void PrintError(string error)
    {
        Error.Visible = true;
        Error.Text = error;
    }

    private void AddRegistration()
    {
        if (int.TryParse(textBox1.Text.Trim(), out int id1) && int.TryParse(textBox2.Text.Trim(), out int id2))
        {
            if(!dbDriver.AddRegistration(id1, id2)) {
                PrintError("Propojení již existuje");
            }
            UpdateTable();
            textBox1.Text = "";
            textBox2.Text = "";
        }
        else
        {
            PrintError("Špatně zadané hodnoty");
        }
    }

    private void RemoveRegistrations()
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
                    if (!dbDriver.RemoveRegistration(id)) foundError2 = true;
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
        RemoveRegistrations();
    }

    private void IdBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (int) Keys.Enter)
        {
            RemoveRegistrations();
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        _main.SwitchView(_main.GetView(1));
    }

    private void UserForm_Load(object sender, EventArgs e)
    {
        UpdateTable();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        AddRegistration();
    }
}