namespace MaturitaFree.App.Controls;

partial class BookListControl
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
        tlpMain = new TableLayoutPanel();
        pnlToolbar = new Panel();
        btnRefresh = new Button();
        btnAdd = new Button();
        dgvBooks = new DataGridView();
        lblStatus = new Label();

        tlpMain.SuspendLayout();
        pnlToolbar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
        SuspendLayout();

        // tlpMain
        tlpMain.Dock = DockStyle.Fill;
        tlpMain.ColumnCount = 1;
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpMain.RowCount = 3;
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        tlpMain.Controls.Add(pnlToolbar, 0, 0);
        tlpMain.Controls.Add(dgvBooks, 0, 1);
        tlpMain.Controls.Add(lblStatus, 0, 2);

        // pnlToolbar
        pnlToolbar.Dock = DockStyle.Fill;
        pnlToolbar.Padding = new Padding(4, 6, 4, 0);
        pnlToolbar.Controls.Add(btnAdd);
        pnlToolbar.Controls.Add(btnRefresh);

        // btnRefresh
        btnRefresh.Text = "⟳  Refresh";
        btnRefresh.AutoSize = true;
        btnRefresh.Location = new Point(4, 6);
        btnRefresh.Click += btnRefresh_Click;

        // btnAdd
        btnAdd.Text = "+ Add test book";
        btnAdd.AutoSize = true;
        btnAdd.Location = new Point(100, 6);
        btnAdd.Click += btnAdd_Click;

        // dgvBooks
        dgvBooks.Dock = DockStyle.Fill;
        dgvBooks.AllowUserToAddRows = false;
        dgvBooks.AllowUserToDeleteRows = false;
        dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvBooks.ReadOnly = true;
        dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvBooks.RowHeadersVisible = false;
        dgvBooks.BackgroundColor = SystemColors.Window;
        dgvBooks.BorderStyle = BorderStyle.None;

        // lblStatus
        lblStatus.Dock = DockStyle.Fill;
        lblStatus.Text = "Ready";
        lblStatus.TextAlign = ContentAlignment.MiddleLeft;
        lblStatus.Padding = new Padding(6, 0, 0, 0);
        lblStatus.ForeColor = SystemColors.GrayText;

        // BookListControl
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(tlpMain);
        Name = "BookListControl";
        Load += BookListControl_Load;

        tlpMain.ResumeLayout(false);
        pnlToolbar.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
        ResumeLayout(false);
    }

    private TableLayoutPanel tlpMain;
    private Panel pnlToolbar;
    private Button btnRefresh;
    private Button btnAdd;
    private DataGridView dgvBooks;
    private Label lblStatus;
}
