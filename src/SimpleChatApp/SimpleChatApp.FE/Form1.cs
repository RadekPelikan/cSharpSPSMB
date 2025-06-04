using Microsoft.AspNetCore.SignalR.Client;

namespace SimpleChatApp.FE;

public partial class Form1 : Form
{
    private readonly HubConnection _connection;


    public Form1(HubConnection connection)
    {
        _connection = connection;
        try
        {
            connection.StartAsync().Wait();
            Console.WriteLine("Connection started");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        connection.On<string>("ReceiveMessage", (message) =>
        {
            var listViewItem = new ListViewItem(message);
            ChatListView.Items.Add(listViewItem);
        });
        InitializeComponent();
    }
    
    private void SendButton_Click(object sender, EventArgs e)
    {
        _connection.SendAsync("SendMessage", InputTextBox.Text);
    }
}
