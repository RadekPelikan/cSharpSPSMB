namespace MaturitaFree.App.Controls;

partial class PersonListControl
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
        components = new System.ComponentModel.Container();
        tlpMain = new System.Windows.Forms.TableLayoutPanel();
        pnlToolbar = new System.Windows.Forms.Panel();
        btnAdd = new System.Windows.Forms.Button();
        btnEdit = new System.Windows.Forms.Button();
        btnRefresh = new System.Windows.Forms.Button();
        chkAutoRefresh = new System.Windows.Forms.CheckBox();
        lblCountdown = new System.Windows.Forms.Label();
        dgvPeople = new System.Windows.Forms.DataGridView();
        lblStatus = new System.Windows.Forms.Label();
        timerAutoRefresh = new System.Windows.Forms.Timer(components);

        tlpMain.SuspendLayout();
        pnlToolbar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPeople).BeginInit();
        SuspendLayout();

        // tlpMain
        tlpMain.ColumnCount = 1;
        tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpMain.Controls.Add(pnlToolbar, 0, 0);
        tlpMain.Controls.Add(dgvPeople, 0, 1);
        tlpMain.Controls.Add(lblStatus, 0, 2);
        tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpMain.RowCount = 3;
        tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
        tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
        tlpMain.Size = new System.Drawing.Size(500, 305);
        tlpMain.TabIndex = 0;

        // pnlToolbar
        pnlToolbar.Controls.Add(btnAdd);
        pnlToolbar.Controls.Add(btnEdit);
        pnlToolbar.Controls.Add(btnRefresh);
        pnlToolbar.Controls.Add(chkAutoRefresh);
        pnlToolbar.Controls.Add(lblCountdown);
        pnlToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlToolbar.Location = new System.Drawing.Point(3, 3);
        pnlToolbar.Name = "pnlToolbar";
        pnlToolbar.Padding = new System.Windows.Forms.Padding(4, 6, 4, 0);
        pnlToolbar.Size = new System.Drawing.Size(494, 38);
        pnlToolbar.TabIndex = 0;

        // btnAdd
        btnAdd.AutoSize = true;
        btnAdd.Location = new System.Drawing.Point(4, 6);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new System.Drawing.Size(55, 25);
        btnAdd.TabIndex = 0;
        btnAdd.Text = "Add";
        btnAdd.Click += btnAdd_Click;

        // btnEdit
        btnEdit.AutoSize = true;
        btnEdit.Location = new System.Drawing.Point(65, 6);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new System.Drawing.Size(55, 25);
        btnEdit.TabIndex = 1;
        btnEdit.Text = "Edit";
        btnEdit.Click += btnEdit_Click;

        // btnRefresh
        btnRefresh.AutoSize = true;
        btnRefresh.Location = new System.Drawing.Point(126, 6);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new System.Drawing.Size(75, 25);
        btnRefresh.TabIndex = 2;
        btnRefresh.Text = "Refresh";
        btnRefresh.Click += btnRefresh_Click;

        // chkAutoRefresh
        chkAutoRefresh.AutoSize = true;
        chkAutoRefresh.Location = new System.Drawing.Point(208, 9);
        chkAutoRefresh.Name = "chkAutoRefresh";
        chkAutoRefresh.Size = new System.Drawing.Size(97, 19);
        chkAutoRefresh.TabIndex = 3;
        chkAutoRefresh.Text = "Auto-refresh";
        chkAutoRefresh.CheckedChanged += chkAutoRefresh_CheckedChanged;

        // lblCountdown
        lblCountdown.AutoSize = true;
        lblCountdown.ForeColor = System.Drawing.SystemColors.GrayText;
        lblCountdown.Location = new System.Drawing.Point(312, 11);
        lblCountdown.Name = "lblCountdown";
        lblCountdown.TabIndex = 4;
        lblCountdown.Text = "";

        // dgvPeople
        dgvPeople.AllowUserToAddRows = false;
        dgvPeople.AllowUserToDeleteRows = false;
        dgvPeople.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvPeople.BackgroundColor = System.Drawing.SystemColors.Window;
        dgvPeople.BorderStyle = System.Windows.Forms.BorderStyle.None;
        dgvPeople.Dock = System.Windows.Forms.DockStyle.Fill;
        dgvPeople.Name = "dgvPeople";
        dgvPeople.ReadOnly = true;
        dgvPeople.RowHeadersVisible = false;
        dgvPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvPeople.TabIndex = 1;

        // lblStatus
        lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
        lblStatus.ForeColor = System.Drawing.SystemColors.GrayText;
        lblStatus.Name = "lblStatus";
        lblStatus.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
        lblStatus.TabIndex = 2;
        lblStatus.Text = "Ready";
        lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // timerAutoRefresh
        timerAutoRefresh.Interval = 1000;
        timerAutoRefresh.Tick += timerAutoRefresh_Tick;

        // PersonListControl
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(tlpMain);
        Load += PersonListControl_Load;

        tlpMain.ResumeLayout(false);
        pnlToolbar.ResumeLayout(false);
        pnlToolbar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPeople).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.TableLayoutPanel tlpMain;
    private System.Windows.Forms.Panel pnlToolbar;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnEdit;
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.CheckBox chkAutoRefresh;
    private System.Windows.Forms.Label lblCountdown;
    private System.Windows.Forms.DataGridView dgvPeople;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.Timer timerAutoRefresh;
}
