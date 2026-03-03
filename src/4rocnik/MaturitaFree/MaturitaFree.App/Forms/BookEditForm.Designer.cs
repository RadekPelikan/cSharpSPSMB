namespace MaturitaFree.App.Forms;

partial class BookEditForm
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
        ClientSize = new System.Drawing.Size(680, 520);
        MinimumSize = new System.Drawing.Size(560, 420);
        Font = new System.Drawing.Font("Segoe UI", 9F);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Book";

        ResumeLayout(false);
    }
}
