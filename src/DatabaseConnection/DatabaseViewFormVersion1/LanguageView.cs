using DatabaseViewForm;

namespace DatabaseViewFormVersion1;

public partial class LanguageView : UserControl
{
    private DBDriver dbDriver = null;
    private Main _main;

    public LanguageView(Main main)
    {
        _main = main;
        InitializeComponent();
    }

    private void PopulateListView(List<Language> languages)
    {
        LanguageListView.Items.Clear();
        foreach (var language in languages)
        {
            ListViewItem item = new ListViewItem();
            item.Text = language.Id.ToString();
            item.SubItems.Add(language.Name);
            item.SubItems.Add(language.CreatedAt.ToString());
            item.SubItems.Add(language.ModifiedAt.ToString());
            LanguageListView.Items.Add(item);
        }
    }

    private void UpdateTable()
    {
        if(dbDriver == null) dbDriver = DBDriver.GetInstanceOrNull();
        try
        {
            List<Language> languages = dbDriver.GetLanguages();
            PopulateListView(languages);
        }
        catch (Exception e)
        {
            LanguageListView.Items.Clear();
            dbDriver = null;
            PrintError(e.Message);
        } 
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

    private void AddLanguage()
    {
        if (username.Text.Trim() != "")
        {
            dbDriver.AddLanguage(username.Text.Trim());
            UpdateTable();
            username.Text = "";
        }
    }

    private void usernameButton_Click(object sender, EventArgs e)
    {
        AddLanguage();
    }

    private void username_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (int) Keys.Enter)
        {
            AddLanguage();
        }
    }

    private void RemoveLanguages()
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
                    if (!dbDriver.RemoveLanguage(id)) foundError2 = true;
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
        RemoveLanguages();
    }

    private void IdBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (int) Keys.Enter)
        {
            RemoveLanguages();
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
}