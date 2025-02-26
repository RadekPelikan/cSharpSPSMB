using System.ComponentModel;

namespace DatabaseViewFormVersion1;

partial class RegistrationView
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
        usersId = new System.Windows.Forms.ColumnHeader();
        usersName = new System.Windows.Forms.ColumnHeader();
        IdButton = new System.Windows.Forms.Button();
        IdBox = new System.Windows.Forms.TextBox();
        button2 = new System.Windows.Forms.Button();
        label2 = new System.Windows.Forms.Label();
        LanguageListView = new System.Windows.Forms.ListView();
        languagesId = new System.Windows.Forms.ColumnHeader();
        languagesName = new System.Windows.Forms.ColumnHeader();
        label3 = new System.Windows.Forms.Label();
        textBox1 = new System.Windows.Forms.TextBox();
        label4 = new System.Windows.Forms.Label();
        textBox2 = new System.Windows.Forms.TextBox();
        button1 = new System.Windows.Forms.Button();
        RegistrationListView = new System.Windows.Forms.ListView();
        registrationId = new System.Windows.Forms.ColumnHeader();
        userId = new System.Windows.Forms.ColumnHeader();
        languageId = new System.Windows.Forms.ColumnHeader();
        Error = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // UserListView
        // 
        UserListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { usersId, usersName });
        UserListView.Location = new System.Drawing.Point(24, 55);
        UserListView.Name = "UserListView";
        UserListView.Size = new System.Drawing.Size(215, 299);
        UserListView.TabIndex = 0;
        UserListView.UseCompatibleStateImageBehavior = false;
        UserListView.View = System.Windows.Forms.View.Details;
        // 
        // usersId
        // 
        usersId.Name = "usersId";
        usersId.Text = "Id";
        // 
        // usersName
        // 
        usersName.Name = "usersName";
        usersName.Text = "Name";
        usersName.Width = 110;
        // 
        // IdButton
        // 
        IdButton.Location = new System.Drawing.Point(606, 246);
        IdButton.Name = "IdButton";
        IdButton.Size = new System.Drawing.Size(185, 26);
        IdButton.TabIndex = 7;
        IdButton.Text = "Remove";
        IdButton.UseVisualStyleBackColor = true;
        IdButton.Click += IdButton_Click;
        // 
        // IdBox
        // 
        IdBox.Location = new System.Drawing.Point(606, 217);
        IdBox.Name = "IdBox";
        IdBox.Size = new System.Drawing.Size(185, 23);
        IdBox.TabIndex = 6;
        IdBox.KeyPress += IdBox_KeyPress;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(668, 412);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(123, 26);
        button2.TabIndex = 12;
        button2.Text = "Back";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // label2
        // 
        label2.ForeColor = System.Drawing.Color.Black;
        label2.Location = new System.Drawing.Point(500, 217);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(100, 23);
        label2.TabIndex = 14;
        label2.Text = "Id";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // LanguageListView
        // 
        LanguageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { languagesId, languagesName });
        LanguageListView.Location = new System.Drawing.Point(279, 55);
        LanguageListView.Name = "LanguageListView";
        LanguageListView.Size = new System.Drawing.Size(215, 299);
        LanguageListView.TabIndex = 15;
        LanguageListView.UseCompatibleStateImageBehavior = false;
        LanguageListView.View = System.Windows.Forms.View.Details;
        // 
        // languagesId
        // 
        languagesId.Name = "languagesId";
        languagesId.Text = "Id";
        // 
        // languagesName
        // 
        languagesName.Name = "languagesName";
        languagesName.Text = "Name";
        languagesName.Width = 108;
        // 
        // label3
        // 
        label3.ForeColor = System.Drawing.Color.Black;
        label3.Location = new System.Drawing.Point(4, 374);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(139, 23);
        label3.TabIndex = 17;
        label3.Text = "User ID";
        label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(149, 374);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(90, 23);
        textBox1.TabIndex = 16;
        // 
        // label4
        // 
        label4.ForeColor = System.Drawing.Color.Black;
        label4.Location = new System.Drawing.Point(259, 375);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(113, 23);
        label4.TabIndex = 19;
        label4.Text = "Language ID";
        label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBox2
        // 
        textBox2.BackColor = System.Drawing.SystemColors.Window;
        textBox2.Location = new System.Drawing.Point(378, 375);
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(116, 23);
        textBox2.TabIndex = 18;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(202, 412);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(123, 26);
        button1.TabIndex = 20;
        button1.Text = "Register";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // RegistrationListView
        // 
        RegistrationListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { registrationId, userId, languageId });
        RegistrationListView.Location = new System.Drawing.Point(533, 41);
        RegistrationListView.Name = "RegistrationListView";
        RegistrationListView.Size = new System.Drawing.Size(258, 170);
        RegistrationListView.TabIndex = 21;
        RegistrationListView.UseCompatibleStateImageBehavior = false;
        RegistrationListView.View = System.Windows.Forms.View.Details;
        // 
        // registrationId
        // 
        registrationId.Name = "registrationId";
        registrationId.Text = "Id";
        registrationId.Width = 57;
        // 
        // userId
        // 
        userId.Name = "userId";
        userId.Text = "UserID";
        userId.Width = 67;
        // 
        // languageId
        // 
        languageId.Name = "languageId";
        languageId.Text = "LanguageID";
        languageId.Width = 75;
        // 
        // Error
        // 
        Error.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)238));
        Error.Location = new System.Drawing.Point(24, 11);
        Error.Name = "Error";
        Error.Size = new System.Drawing.Size(470, 41);
        Error.TabIndex = 22;
        Error.Text = "Error";
        Error.Visible = false;
        // 
        // RegistrationView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.Green;
        Controls.Add(Error);
        Controls.Add(RegistrationListView);
        Controls.Add(button1);
        Controls.Add(label4);
        Controls.Add(textBox2);
        Controls.Add(label3);
        Controls.Add(textBox1);
        Controls.Add(LanguageListView);
        Controls.Add(label2);
        Controls.Add(button2);
        Controls.Add(IdButton);
        Controls.Add(IdBox);
        Controls.Add(UserListView);
        ForeColor = System.Drawing.Color.DarkRed;
        Size = new System.Drawing.Size(800, 450);
        Load += UserForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label Error;

    private System.Windows.Forms.ColumnHeader registrationId;
    private System.Windows.Forms.ColumnHeader userId;
    private System.Windows.Forms.ColumnHeader languageId;

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.ListView RegistrationListView;

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.ColumnHeader languagesId;
    private System.Windows.Forms.ColumnHeader languagesName;

    private System.Windows.Forms.ColumnHeader usersName;
    private System.Windows.Forms.ListView LanguageListView;

    private System.Windows.Forms.ColumnHeader usersId;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.Button IdButton;
    private System.Windows.Forms.TextBox IdBox;

    private System.Windows.Forms.ListView UserListView;

    #endregion
}