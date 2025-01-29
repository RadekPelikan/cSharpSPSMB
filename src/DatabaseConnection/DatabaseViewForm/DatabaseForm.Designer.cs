namespace DatabaseViewForm;

partial class DatabaseForm
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
        UserListView = new System.Windows.Forms.ListView();
        idCol = new System.Windows.Forms.ColumnHeader();
        usernameCol = new System.Windows.Forms.ColumnHeader();
        createdDateCol = new System.Windows.Forms.ColumnHeader();
        modifiedDateCol = new System.Windows.Forms.ColumnHeader();
        PasswordTextBox = new System.Windows.Forms.TextBox();
        button1 = new System.Windows.Forms.Button();
        ErrorLabel = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // UserListView
        // 
        UserListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { idCol, usernameCol, createdDateCol, modifiedDateCol });
        UserListView.Location = new System.Drawing.Point(68, 71);
        UserListView.Name = "UserListView";
        UserListView.Size = new System.Drawing.Size(525, 169);
        UserListView.TabIndex = 0;
        UserListView.UseCompatibleStateImageBehavior = false;
        UserListView.View = System.Windows.Forms.View.Details;
        // 
        // idCol
        // 
        idCol.Name = "idCol";
        idCol.Text = "Id";
        idCol.Width = 100;
        // 
        // usernameCol
        // 
        usernameCol.Name = "usernameCol";
        usernameCol.Text = "Username";
        usernameCol.Width = 86;
        // 
        // createdDateCol
        // 
        createdDateCol.Name = "createdDateCol";
        createdDateCol.Text = "Created";
        createdDateCol.Width = 117;
        // 
        // modifiedDateCol
        // 
        modifiedDateCol.Name = "modifiedDateCol";
        modifiedDateCol.Text = "Modified";
        modifiedDateCol.Width = 162;
        // 
        // PasswordTextBox
        // 
        PasswordTextBox.Location = new System.Drawing.Point(306, 286);
        PasswordTextBox.Name = "PasswordTextBox";
        PasswordTextBox.Size = new System.Drawing.Size(287, 23);
        PasswordTextBox.TabIndex = 1;
        PasswordTextBox.Enter += PasswordTextBox_Enter;
        PasswordTextBox.KeyPress += PasswordTextBox_KeyPressed;
        PasswordTextBox.Leave += PasswordTextBox_Leave;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(609, 286);
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
        // DatabaseForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(ErrorLabel);
        Controls.Add(button1);
        Controls.Add(PasswordTextBox);
        Controls.Add(UserListView);
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

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