namespace MaturitaFree.App.Forms;

partial class PersonEditForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        SuspendLayout();

        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        ClientSize = new System.Drawing.Size(560, 480);
        MinimumSize = new System.Drawing.Size(460, 380);
        Font = new System.Drawing.Font("Segoe UI", 9F);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Person";

        ResumeLayout(false);
    }
}
