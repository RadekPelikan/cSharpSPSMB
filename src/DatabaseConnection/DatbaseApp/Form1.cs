using DatabaseConnection;
using DBDriver;
using DBDriver.Entites;

namespace DatbaseApp;

public partial class Form1 : Form
{
    private DBDriver.DBDriver _dbDriver;
    private uint count = 0;

    public Form1()
    {
        InitializeComponent();
    }

    private void LoadUserList()
    {
        UserList.Items.Clear();
        UserRepository userRepository = new UserRepository(_dbDriver);
        List<User> users = userRepository.GetUsers();
        foreach (User user in users)
        {
            ListViewItem userItem = new ListViewItem(user.Id.ToString());
            userItem.SubItems.Add(user.Username);
            userItem.SubItems.Add(user.CreatedAt.ToString());
            userItem.SubItems.Add(user.ModifiedAt.ToString());
            UserList.Items.Add(userItem);
        }
    }


    private void Form1_Load(object sender, EventArgs e)
    {
        _dbDriver = new DBDriver.DBDriver();
        _dbDriver.Password = File.ReadAllText("password.env");
        LoadUserList();
    }


    private void button1_Click(object sender, EventArgs e)
    {
        if (UserNameInput.Text == "") return;

        UserRepository userRepository = new UserRepository(_dbDriver);
        userRepository.InsertUser(UserNameInput.Text);
        UserNameInput.Text = "";
        LoadUserList();
    }
}