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

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        pnlHeader = new System.Windows.Forms.Panel();
        lblAppTitle = new System.Windows.Forms.Label();
        tabMain = new System.Windows.Forms.TabControl();
        tabBooks = new System.Windows.Forms.TabPage();
        tabPeople = new System.Windows.Forms.TabPage();
        pnlHeader.SuspendLayout();
        tabMain.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)30)), ((int)((byte)50)));
        pnlHeader.Controls.Add(lblAppTitle);
        pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
        pnlHeader.Location = new System.Drawing.Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new System.Drawing.Size(1040, 50);
        pnlHeader.TabIndex = 1;
        // 
        // lblAppTitle
        // 
        lblAppTitle.Dock = System.Windows.Forms.DockStyle.Fill;
        lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        lblAppTitle.ForeColor = System.Drawing.Color.White;
        lblAppTitle.Location = new System.Drawing.Point(0, 0);
        lblAppTitle.Name = "lblAppTitle";
        lblAppTitle.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
        lblAppTitle.Size = new System.Drawing.Size(1040, 50);
        lblAppTitle.TabIndex = 0;
        lblAppTitle.Text = "MaturitaFree";
        lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // tabMain
        // 
        tabMain.Controls.Add(tabBooks);
        tabMain.Controls.Add(tabPeople);
        tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
        tabMain.Font = new System.Drawing.Font("Segoe UI", 10F);
        tabMain.Location = new System.Drawing.Point(0, 50);
        tabMain.Name = "tabMain";
        tabMain.Padding = new System.Drawing.Point(12, 4);
        tabMain.SelectedIndex = 0;
        tabMain.Size = new System.Drawing.Size(1040, 630);
        tabMain.TabIndex = 0;
        // 
        // tabBooks
        // 
        tabBooks.Dock = System.Windows.Forms.DockStyle.Fill;
        tabBooks.Location = new System.Drawing.Point(4, 28);
        tabBooks.Name = "tabBooks";
        tabBooks.Padding = new System.Windows.Forms.Padding(4);
        tabBooks.Size = new System.Drawing.Size(1032, 598);
        tabBooks.TabIndex = 0;
        tabBooks.Text = "Books";
        // 
        // tabPeople
        // 
        tabPeople.Dock = System.Windows.Forms.DockStyle.Fill;
        tabPeople.Location = new System.Drawing.Point(4, 28);
        tabPeople.Name = "tabPeople";
        tabPeople.Padding = new System.Windows.Forms.Padding(4);
        tabPeople.Size = new System.Drawing.Size(1032, 598);
        tabPeople.TabIndex = 1;
        tabPeople.Text = "Authors / Illustrators";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1040, 680);
        Controls.Add(tabMain);
        Controls.Add(pnlHeader);
        MinimumSize = new System.Drawing.Size(800, 520);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "MaturitaFree";
        pnlHeader.ResumeLayout(false);
        tabMain.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Panel pnlHeader;
    private Label lblAppTitle;
    private TabControl tabMain;
    private TabPage tabBooks;
    private TabPage tabPeople;
}
