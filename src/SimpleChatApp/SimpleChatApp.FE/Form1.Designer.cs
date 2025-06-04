namespace SimpleChatApp.FE;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        ChatListView = new System.Windows.Forms.ListView();
        Sender = new System.Windows.Forms.ColumnHeader();
        MessageTextBox = new System.Windows.Forms.TextBox();
        SendButton = new System.Windows.Forms.Button();
        SenderTextBox = new System.Windows.Forms.TextBox();
        Message = new System.Windows.Forms.ColumnHeader();
        SuspendLayout();
        // 
        // ChatListView
        // 
        ChatListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { Sender, Message });
        ChatListView.Location = new System.Drawing.Point(47, 25);
        ChatListView.Name = "ChatListView";
        ChatListView.Size = new System.Drawing.Size(700, 359);
        ChatListView.TabIndex = 0;
        ChatListView.UseCompatibleStateImageBehavior = false;
        ChatListView.View = System.Windows.Forms.View.Details;
        // 
        // Sender
        // 
        Sender.Name = "Sender";
        Sender.Text = "Sender";
        // 
        // MessageTextBox
        // 
        MessageTextBox.Location = new System.Drawing.Point(177, 399);
        MessageTextBox.Name = "MessageTextBox";
        MessageTextBox.Size = new System.Drawing.Size(488, 23);
        MessageTextBox.TabIndex = 1;
        // 
        // SendButton
        // 
        SendButton.Location = new System.Drawing.Point(677, 397);
        SendButton.Name = "SendButton";
        SendButton.Size = new System.Drawing.Size(69, 24);
        SendButton.TabIndex = 2;
        SendButton.Text = "Send";
        SendButton.UseVisualStyleBackColor = true;
        SendButton.Click += SendButton_Click;
        // 
        // SenderTextBox
        // 
        SenderTextBox.Location = new System.Drawing.Point(47, 397);
        SenderTextBox.Name = "SenderTextBox";
        SenderTextBox.Size = new System.Drawing.Size(115, 23);
        SenderTextBox.TabIndex = 3;
        // 
        // Message
        // 
        Message.Name = "Message";
        Message.Text = "Messager";
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(SenderTextBox);
        Controls.Add(SendButton);
        Controls.Add(MessageTextBox);
        Controls.Add(ChatListView);
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ColumnHeader Message;

    private System.Windows.Forms.TextBox SenderTextBox;

    private System.Windows.Forms.ColumnHeader Sender;

    private System.Windows.Forms.ListView ChatListView;
    private System.Windows.Forms.TextBox MessageTextBox;
    private System.Windows.Forms.Button SendButton;

    #endregion
}