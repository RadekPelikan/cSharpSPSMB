using System.ComponentModel;

namespace UserControlViews.components;

partial class NextPrevious
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
        button2 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(686, 3);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(111, 37);
        button1.TabIndex = 0;
        button1.Text = "Next";
        button1.UseVisualStyleBackColor = true;
        button1.Click += NextButton_Click;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(3, 3);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(111, 37);
        button2.TabIndex = 1;
        button2.Text = "Previous";
        button2.UseVisualStyleBackColor = true;
        button2.Click += PreviousButton_Click;
        // 
        // NextPrevious
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(button2);
        Controls.Add(button1);
        Size = new System.Drawing.Size(800, 44);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;

    #endregion
}