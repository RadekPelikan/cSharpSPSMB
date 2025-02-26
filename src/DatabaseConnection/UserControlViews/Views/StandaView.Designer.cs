using System.ComponentModel;

namespace UserControlViews.Views;

partial class StandaView
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
        label2 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(351, 170);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(125, 37);
        button1.TabIndex = 3;
        button1.Text = "Back";
        button1.UseVisualStyleBackColor = true;
        button1.Click += BackButton_Click;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
        label2.Location = new System.Drawing.Point(-2, 89);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(818, 49);
        label2.TabIndex = 2;
        label2.Text = "Standa View";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // StandaView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(button1);
        Controls.Add(label2);
        Size = new System.Drawing.Size(816, 489);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label2;

    #endregion
}