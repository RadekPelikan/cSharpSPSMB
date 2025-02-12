namespace DatabaseViewForm;

public partial class DatabaseListForm : Form
{
    public DatabaseListForm()
    {
        InitializeComponent();
    }
    private void Languages_Click(object sender, EventArgs e)
    {
        LanguageForm languageForm = new LanguageForm();
        languageForm.Dock = DockStyle.Fill;
        languageForm.TopLevel = false;
        MainForm.MainPanel.Controls.Clear();
        MainForm.MainPanel.Controls.Add(languageForm);
        languageForm.Show();
    }

    private void Users_Click(object sender, EventArgs e)
    {
        UserForm userForm = new UserForm();
        userForm.Dock = DockStyle.Fill;
        userForm.TopLevel = false;
        MainForm.MainPanel.Controls.Clear();
        MainForm.MainPanel.Controls.Add(userForm);
        userForm.Show();
    }

    private void USER_LANGUAGE_RELATION_Click(object sender, EventArgs e)
    {
        RegistrationForm registrationForm = new RegistrationForm();
        registrationForm.Dock = DockStyle.Fill;
        registrationForm.TopLevel = false;
        MainForm.MainPanel.Controls.Clear();
        MainForm.MainPanel.Controls.Add(registrationForm);
        registrationForm.Show();
    }
}