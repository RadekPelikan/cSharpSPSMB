using System.ComponentModel;

namespace UserControlViews.Views;

partial class ZdarskyView
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
        label1 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(356, 153);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(124, 44);
        button1.TabIndex = 0;
        button1.Text = "Back";
        button1.UseVisualStyleBackColor = true;
        button1.Click += BackButton_Click;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
        label1.Location = new System.Drawing.Point(0, 97);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(815, 39);
        label1.TabIndex = 1;
        label1.Text = "Zdarsky View";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ZdarskyView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(label1);
        Controls.Add(button1);
        Size = new System.Drawing.Size(816, 489);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button button1;

    #endregion
}