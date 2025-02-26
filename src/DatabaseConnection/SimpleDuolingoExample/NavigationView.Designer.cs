using System.ComponentModel;

namespace DatabaseViewForm;

partial class NavigationView
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
        button1 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(176, 151);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(124, 42);
        button1.TabIndex = 0;
        button1.Text = "User";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click_1;
        // 
        // StartForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(button1);
        Text = "StartForm";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;

    #endregion
}