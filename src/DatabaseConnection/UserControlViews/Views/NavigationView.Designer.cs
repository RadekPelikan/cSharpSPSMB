using System.ComponentModel;

namespace UserControlViews.Views;

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
        label1 = new System.Windows.Forms.Label();
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
        label1.Location = new System.Drawing.Point(0, 74);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(816, 47);
        label1.TabIndex = 0;
        label1.Text = "Navigation";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(352, 175);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(123, 44);
        button1.TabIndex = 1;
        button1.Text = "Standa View";
        button1.UseVisualStyleBackColor = true;
        button1.Click += StandaViewButton_Click;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(352, 248);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(123, 44);
        button2.TabIndex = 1;
        button2.Text = "Zdarsky View";
        button2.UseVisualStyleBackColor = true;
        button2.Click += ZdarskyViewButton_Click;
        // 
        // NavigationView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(label1);
        Size = new System.Drawing.Size(816, 334);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Label label1;

    #endregion
}