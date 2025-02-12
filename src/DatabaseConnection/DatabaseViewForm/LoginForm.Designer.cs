using System.ComponentModel;

namespace DatabaseViewForm;

partial class LoginForm
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
        textBox1 = new System.Windows.Forms.TextBox();
        button1 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(289, 175);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(200, 23);
        textBox1.TabIndex = 0;
        textBox1.Enter += textBox1_Enter;
        textBox1.KeyPress += textBox1_KeyPress;
        textBox1.Leave += textBox1_Leave;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(405, 215);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(84, 28);
        button1.TabIndex = 1;
        button1.Text = "Login";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // LoginForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(button1);
        Controls.Add(textBox1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        Text = "LoginForm";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button button1;

    #endregion
}