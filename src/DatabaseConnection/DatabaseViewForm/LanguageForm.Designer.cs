using System.ComponentModel;

namespace DatabaseViewForm;

partial class LanguageForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        LanguageListView = new System.Windows.Forms.ListView();
        idCol = new System.Windows.Forms.ColumnHeader();
        nameCol = new System.Windows.Forms.ColumnHeader();
        createdDateCol = new System.Windows.Forms.ColumnHeader();
        modifiedDateCol = new System.Windows.Forms.ColumnHeader();
        ErrorLabel = new System.Windows.Forms.Label();
        usernameButton = new System.Windows.Forms.Button();
        username = new System.Windows.Forms.TextBox();
        IdButton = new System.Windows.Forms.Button();
        IdBox = new System.Windows.Forms.TextBox();
        button2 = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // UserListView
        // 
        LanguageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { idCol, nameCol, createdDateCol, modifiedDateCol });
        LanguageListView.Location = new System.Drawing.Point(313, 21);
        LanguageListView.Name = "LanguageListView";
        LanguageListView.Size = new System.Drawing.Size(416, 373);
        LanguageListView.TabIndex = 0;
        LanguageListView.UseCompatibleStateImageBehavior = false;
        LanguageListView.View = System.Windows.Forms.View.Details;
        // 
        // idCol
        // 
        idCol.Name = "idCol";
        idCol.Text = "Id";
        idCol.Width = 100;
        // 
        // nameCol
        // 
        nameCol.Name = "nameCol";
        nameCol.Text = "Name";
        nameCol.Width = 86;
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
        // ErrorLabel
        // 
        ErrorLabel.Enabled = false;
        ErrorLabel.Location = new System.Drawing.Point(313, 397);
        ErrorLabel.Name = "ErrorLabel";
        ErrorLabel.Size = new System.Drawing.Size(197, 23);
        ErrorLabel.TabIndex = 3;
        ErrorLabel.Text = "label1";
        ErrorLabel.Visible = false;
        // 
        // usernameButton
        // 
        usernameButton.Location = new System.Drawing.Point(122, 61);
        usernameButton.Name = "usernameButton";
        usernameButton.Size = new System.Drawing.Size(185, 26);
        usernameButton.TabIndex = 5;
        usernameButton.Text = "Add";
        usernameButton.UseVisualStyleBackColor = true;
        usernameButton.Click += usernameButton_Click;
        // 
        // username
        // 
        username.Location = new System.Drawing.Point(122, 32);
        username.Name = "username";
        username.Size = new System.Drawing.Size(185, 23);
        username.TabIndex = 4;
        username.Enter += username_Enter;
        username.KeyPress += username_KeyPress;
        username.Leave += username_Leave;
        // 
        // IdButton
        // 
        IdButton.Location = new System.Drawing.Point(122, 142);
        IdButton.Name = "IdButton";
        IdButton.Size = new System.Drawing.Size(185, 26);
        IdButton.TabIndex = 7;
        IdButton.Text = "Remove";
        IdButton.UseVisualStyleBackColor = true;
        IdButton.Click += IdButton_Click;
        // 
        // IdBox
        // 
        IdBox.Location = new System.Drawing.Point(122, 113);
        IdBox.Name = "IdBox";
        IdBox.Size = new System.Drawing.Size(185, 23);
        IdBox.TabIndex = 6;
        IdBox.KeyPress += IdBox_KeyPress;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(606, 412);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(123, 26);
        button2.TabIndex = 12;
        button2.Text = "Back";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // label1
        // 
        label1.ForeColor = System.Drawing.Color.Black;
        label1.Location = new System.Drawing.Point(16, 32);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(100, 23);
        label1.TabIndex = 13;
        label1.Text = "Name";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label2
        // 
        label2.ForeColor = System.Drawing.Color.Black;
        label2.Location = new System.Drawing.Point(16, 113);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(100, 23);
        label2.TabIndex = 14;
        label2.Text = "Id";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // LanguageForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(button2);
        Controls.Add(IdButton);
        Controls.Add(IdBox);
        Controls.Add(usernameButton);
        Controls.Add(username);
        Controls.Add(ErrorLabel);
        Controls.Add(LanguageListView);
        ForeColor = System.Drawing.Color.DarkRed;
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        Text = "Form1";
        Load += UserForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.Button IdButton;
    private System.Windows.Forms.TextBox IdBox;

    private System.Windows.Forms.TextBox username;
    private System.Windows.Forms.Button usernameButton;

    private System.Windows.Forms.Label ErrorLabel;

    private System.Windows.Forms.ColumnHeader idCol;
    private System.Windows.Forms.ColumnHeader nameCol;
    private System.Windows.Forms.ColumnHeader createdDateCol;
    private System.Windows.Forms.ColumnHeader modifiedDateCol;

    private System.Windows.Forms.ListView LanguageListView;

    #endregion
}