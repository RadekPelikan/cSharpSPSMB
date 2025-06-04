using Microsoft.AspNetCore.SignalR.Client;

namespace SimpleChatApp.FE;

public partial class Form1 : Form
{
    private readonly HubConnection _connection;


    public Form1(HubConnection connection)
    {
        InitializeComponent();
        _connection = connection;
        try
        {
            _connection.StartAsync().Wait();
            
            _connection.On<ChatMessage>("ReceiveMessage", (message) =>
            {
                var listViewItem = new ListViewItem(message.Sender);
                listViewItem.SubItems.Add(message.Message);
                ChatListView.Items.Add(listViewItem);
            });
        
            _connection.On<List<ChatMessage>>("LoadMessages", (messages) =>
            {
                foreach (var message in messages)
                {
                    var listViewItem = new ListViewItem(message.Sender);
                    listViewItem.SubItems.Add(message.Message);
                    ChatListView.Items.Add(listViewItem);
                }
            
            });
            
            _connection.SendAsync("Connect", Guid.NewGuid());
            Console.WriteLine("Connection started");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
    
    private void SendButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(SenderTextBox.Text) || string.IsNullOrWhiteSpace(MessageTextBox.Text))
            return;
        _connection.SendAsync("SendMessage", new ChatMessage(SenderTextBox.Text, MessageTextBox.Text));
        MessageTextBox.Text = "";
    }
}

public record ChatMessage(string Sender, string Message)
{
    public override string ToString()
    {
        return $"{Sender}: {Message}";
    }
};