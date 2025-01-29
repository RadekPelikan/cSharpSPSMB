namespace DatbaseApp;

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
        UserList = new System.Windows.Forms.ListView();
        columnHeader1 = new System.Windows.Forms.ColumnHeader();
        columnHeader2 = new System.Windows.Forms.ColumnHeader();
        columnHeader3 = new System.Windows.Forms.ColumnHeader();
        columnHeader4 = new System.Windows.Forms.ColumnHeader();
        UserNameInput = new System.Windows.Forms.TextBox();
        InsertButton = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // UserList
        // 
        UserList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
        UserList.Location = new System.Drawing.Point(28, 12);
        UserList.Name = "UserList";
        UserList.Size = new System.Drawing.Size(420, 247);
        UserList.TabIndex = 0;
        UserList.UseCompatibleStateImageBehavior = false;
        UserList.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader1
        // 
        columnHeader1.Name = "columnHeader1";
        columnHeader1.Text = "Id";
        // 
        // columnHeader2
        // 
        columnHeader2.Name = "columnHeader2";
        columnHeader2.Text = "Username";
        columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        // 
        // columnHeader3
        // 
        columnHeader3.Name = "columnHeader3";
        columnHeader3.Text = "date created";
        // 
        // columnHeader4
        // 
        columnHeader4.Name = "columnHeader4";
        columnHeader4.Text = "date modified";
        // 
        // UserNameInput
        // 
        UserNameInput.Location = new System.Drawing.Point(521, 67);
        UserNameInput.Name = "UserNameInput";
        UserNameInput.Size = new System.Drawing.Size(153, 23);
        UserNameInput.TabIndex = 1;
        // 
        // InsertButton
        // 
        InsertButton.Location = new System.Drawing.Point(521, 106);
        InsertButton.Name = "InsertButton";
        InsertButton.Size = new System.Drawing.Size(83, 44);
        InsertButton.TabIndex = 2;
        InsertButton.Text = "Insert";
        InsertButton.UseVisualStyleBackColor = true;
        InsertButton.Click += button1_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(821, 544);
        Controls.Add(InsertButton);
        Controls.Add(UserNameInput);
        Controls.Add(UserList);
        Tag = "ListForm";
        Text = "AAAAAA";
        Load += Form1_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox UserNameInput;
    private System.Windows.Forms.Button InsertButton;

    private System.Windows.Forms.ColumnHeader columnHeader4;

    private System.Windows.Forms.ColumnHeader columnHeader3;

    private System.Windows.Forms.ColumnHeader columnHeader2;

    private System.Windows.Forms.ColumnHeader columnHeader1;

    private System.Windows.Forms.ListView UserList;

    #endregion
}