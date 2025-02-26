using System.ComponentModel;

namespace DatabaseViewForm;

partial class UserView
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
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

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        UserListView = new System.Windows.Forms.ListView();
        idCol = new System.Windows.Forms.ColumnHeader();
        usernameCol = new System.Windows.Forms.ColumnHeader();
        createdDateCol = new System.Windows.Forms.ColumnHeader();
        modifiedDateCol = new System.Windows.Forms.ColumnHeader();
        PasswordTextBox = new System.Windows.Forms.TextBox();
        button1 = new System.Windows.Forms.Button();
        ErrorLabel = new System.Windows.Forms.Label();
        TextBoxNewUser = new System.Windows.Forms.TextBox();
        CreateUserButton = new System.Windows.Forms.Button();
        ButtonDelete = new System.Windows.Forms.Button();
        TextBoxDeleteUser = new System.Windows.Forms.TextBox();
        SuspendLayout();
        // 
        // UserListView
        // 
        UserListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { idCol, usernameCol, createdDateCol, modifiedDateCol });
        UserListView.Location = new System.Drawing.Point(12, 41);
        UserListView.Name = "UserListView";
        UserListView.Size = new System.Drawing.Size(590, 169);
        UserListView.TabIndex = 0;
        UserListView.UseCompatibleStateImageBehavior = false;
        UserListView.View = System.Windows.Forms.View.Details;
        UserListView.ItemSelectionChanged += UserListView_ItemSelectionChanged;
        // 
        // idCol
        // 
        idCol.Name = "idCol";
        idCol.Text = "Id";
        idCol.Width = 56;
        // 
        // usernameCol
        // 
        usernameCol.Name = "usernameCol";
        usernameCol.Text = "Username";
        usernameCol.Width = 153;
        // 
        // createdDateCol
        // 
        createdDateCol.Name = "createdDateCol";
        createdDateCol.Text = "Created";
        createdDateCol.Width = 94;
        // 
        // modifiedDateCol
        // 
        modifiedDateCol.Name = "modifiedDateCol";
        modifiedDateCol.Text = "Modified";
        modifiedDateCol.Width = 218;
        // 
        // PasswordTextBox
        // 
        PasswordTextBox.Location = new System.Drawing.Point(176, 232);
        PasswordTextBox.Name = "PasswordTextBox";
        PasswordTextBox.Size = new System.Drawing.Size(287, 23);
        PasswordTextBox.TabIndex = 1;
        PasswordTextBox.Enter += PasswordTextBox_Enter;
        PasswordTextBox.KeyPress += PasswordTextBox_KeyPressed;
        PasswordTextBox.Leave += PasswordTextBox_Leave;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(479, 232);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(123, 26);
        button1.TabIndex = 2;
        button1.Text = "Fetch";
        button1.UseVisualStyleBackColor = true;
        button1.Click += FetchButton_Click;
        // 
        // ErrorLabel
        // 
        ErrorLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)238));
        ErrorLabel.ForeColor = System.Drawing.Color.Red;
        ErrorLabel.Location = new System.Drawing.Point(306, 312);
        ErrorLabel.Name = "ErrorLabel";
        ErrorLabel.Size = new System.Drawing.Size(426, 24);
        ErrorLabel.TabIndex = 3;
        // 
        // TextBoxNewUser
        // 
        TextBoxNewUser.Location = new System.Drawing.Point(608, 41);
        TextBoxNewUser.Name = "TextBoxNewUser";
        TextBoxNewUser.Size = new System.Drawing.Size(180, 23);
        TextBoxNewUser.TabIndex = 4;
        TextBoxNewUser.KeyDown += TextBoxNewUser_KeyDown;
        // 
        // CreateUserButton
        // 
        CreateUserButton.Location = new System.Drawing.Point(700, 70);
        CreateUserButton.Name = "CreateUserButton";
        CreateUserButton.Size = new System.Drawing.Size(88, 25);
        CreateUserButton.TabIndex = 5;
        CreateUserButton.Text = "Create User";
        CreateUserButton.UseVisualStyleBackColor = true;
        CreateUserButton.Click += ButtonNewUser_Click;
        // 
        // ButtonDelete
        // 
        ButtonDelete.Location = new System.Drawing.Point(700, 148);
        ButtonDelete.Name = "ButtonDelete";
        ButtonDelete.Size = new System.Drawing.Size(88, 25);
        ButtonDelete.TabIndex = 6;
        ButtonDelete.Text = "Delete";
        ButtonDelete.UseVisualStyleBackColor = true;
        ButtonDelete.Click += ButtonDelete_Click;
        // 
        // TextBoxDeleteUser
        // 
        TextBoxDeleteUser.Location = new System.Drawing.Point(608, 119);
        TextBoxDeleteUser.Name = "TextBoxDeleteUser";
        TextBoxDeleteUser.Size = new System.Drawing.Size(180, 23);
        TextBoxDeleteUser.TabIndex = 7;
        TextBoxDeleteUser.KeyDown += TextBoxDeleteUser_KeyDown;
        // 
        // UserView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(TextBoxDeleteUser);
        Controls.Add(ButtonDelete);
        Controls.Add(CreateUserButton);
        Controls.Add(TextBoxNewUser);
        Controls.Add(ErrorLabel);
        Controls.Add(button1);
        Controls.Add(PasswordTextBox);
        Controls.Add(UserListView);
        Size = new System.Drawing.Size(800, 450);
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox TextBoxDeleteUser;

    private System.Windows.Forms.Button ButtonDelete;

    private System.Windows.Forms.TextBox TextBoxNewUser;
    private System.Windows.Forms.Button CreateUserButton;

    private System.Windows.Forms.Label ErrorLabel;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.TextBox PasswordTextBox;

    private System.Windows.Forms.ColumnHeader idCol;
    private System.Windows.Forms.ColumnHeader usernameCol;
    private System.Windows.Forms.ColumnHeader createdDateCol;
    private System.Windows.Forms.ColumnHeader modifiedDateCol;

    private System.Windows.Forms.ListView UserListView;

    #endregion
}