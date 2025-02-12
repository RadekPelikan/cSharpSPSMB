using System.ComponentModel;

namespace UserControlViews.Views;

partial class NameView
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
        NameLabel = new System.Windows.Forms.Label();
        button1 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // NameLabel
        // 
        NameLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
        NameLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
        NameLabel.Location = new System.Drawing.Point(0, 52);
        NameLabel.Name = "NameLabel";
        NameLabel.Size = new System.Drawing.Size(816, 44);
        NameLabel.TabIndex = 0;
        NameLabel.Text = "Name ";
        NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(356, 127);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(101, 41);
        button1.TabIndex = 1;
        button1.Text = "Back";
        button1.UseVisualStyleBackColor = true;
        button1.Click += BackButton_Click;
        // 
        // NameView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(button1);
        Controls.Add(NameLabel);
        Size = new System.Drawing.Size(816, 489);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Label NameLabel;

    #endregion
}