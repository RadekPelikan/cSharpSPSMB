namespace MaturitaFree.App.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlHeader = new Panel();
        lblAppTitle = new Label();
        pnlContent = new Panel();

        pnlHeader.SuspendLayout();
        SuspendLayout();

        // pnlHeader
        pnlHeader.BackColor = Color.FromArgb(30, 30, 50);
        pnlHeader.Controls.Add(lblAppTitle);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Height = 50;

        // lblAppTitle
        lblAppTitle.AutoSize = false;
        lblAppTitle.Dock = DockStyle.Fill;
        lblAppTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblAppTitle.ForeColor = Color.White;
        lblAppTitle.Text = "MaturitaFree";
        lblAppTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblAppTitle.Padding = new Padding(12, 0, 0, 0);

        // pnlContent
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Padding = new Padding(8);

        // MainForm
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1040, 680);
        MinimumSize = new Size(800, 520);
        Controls.Add(pnlContent);
        Controls.Add(pnlHeader);
        Text = "MaturitaFree";
        StartPosition = FormStartPosition.CenterScreen;

        pnlHeader.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Panel pnlHeader;
    private Label lblAppTitle;
    private Panel pnlContent;
}
