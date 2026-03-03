namespace MaturitaFree.App.Controls;

partial class BookEditControl
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
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
        tlpOuter = new System.Windows.Forms.TableLayoutPanel();
        pnlToolbar = new System.Windows.Forms.Panel();
        lblHeading = new System.Windows.Forms.Label();
        pnlButtons = new System.Windows.Forms.Panel();
        btnDelete = new System.Windows.Forms.Button();
        btnSubmit = new System.Windows.Forms.Button();
        tabContent = new System.Windows.Forms.TabControl();
        tabDetails = new System.Windows.Forms.TabPage();
        tlpFields = new System.Windows.Forms.TableLayoutPanel();
        lblTitle = new System.Windows.Forms.Label();
        txtTitle = new System.Windows.Forms.TextBox();
        lblDescription = new System.Windows.Forms.Label();
        txtDescription = new System.Windows.Forms.TextBox();
        tabChapters = new System.Windows.Forms.TabPage();
        tlpChapters = new System.Windows.Forms.TableLayoutPanel();
        pnlChapterToolbar = new System.Windows.Forms.Panel();
        btnAddChapter = new System.Windows.Forms.Button();
        btnEditChapter = new System.Windows.Forms.Button();
        btnDeleteChapter = new System.Windows.Forms.Button();
        dgvChapters = new System.Windows.Forms.DataGridView();
        tabContributors = new System.Windows.Forms.TabPage();
        tlpContributors = new System.Windows.Forms.TableLayoutPanel();
        pnlContributorToolbar = new System.Windows.Forms.Panel();
        btnAddContributor = new System.Windows.Forms.Button();
        btnEditContributor = new System.Windows.Forms.Button();
        btnRemoveContributor = new System.Windows.Forms.Button();
        dgvContributors = new System.Windows.Forms.DataGridView();
        lblStatus = new System.Windows.Forms.Label();
        tlpOuter.SuspendLayout();
        pnlToolbar.SuspendLayout();
        pnlButtons.SuspendLayout();
        tabContent.SuspendLayout();
        tabDetails.SuspendLayout();
        tlpFields.SuspendLayout();
        tabChapters.SuspendLayout();
        tlpChapters.SuspendLayout();
        pnlChapterToolbar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvChapters).BeginInit();
        tabContributors.SuspendLayout();
        tlpContributors.SuspendLayout();
        pnlContributorToolbar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvContributors).BeginInit();
        SuspendLayout();
        // 
        // tlpOuter
        // 
        tlpOuter.ColumnCount = 1;
        tlpOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpOuter.Controls.Add(pnlToolbar, 0, 0);
        tlpOuter.Controls.Add(tabContent, 0, 1);
        tlpOuter.Controls.Add(lblStatus, 0, 2);
        tlpOuter.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpOuter.Location = new System.Drawing.Point(0, 0);
        tlpOuter.Name = "tlpOuter";
        tlpOuter.RowCount = 3;
        tlpOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
        tlpOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
        tlpOuter.Size = new System.Drawing.Size(443, 352);
        tlpOuter.TabIndex = 0;
        // 
        // pnlToolbar
        // 
        pnlToolbar.Controls.Add(lblHeading);
        pnlToolbar.Controls.Add(pnlButtons);
        pnlToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlToolbar.Location = new System.Drawing.Point(3, 3);
        pnlToolbar.Name = "pnlToolbar";
        pnlToolbar.Padding = new System.Windows.Forms.Padding(4, 6, 4, 0);
        pnlToolbar.Size = new System.Drawing.Size(437, 38);
        pnlToolbar.TabIndex = 0;
        // 
        // lblHeading
        // 
        lblHeading.AutoSize = true;
        lblHeading.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        lblHeading.Location = new System.Drawing.Point(4, 8);
        lblHeading.Name = "lblHeading";
        lblHeading.Size = new System.Drawing.Size(78, 20);
        lblHeading.TabIndex = 0;
        lblHeading.Text = "Add Book";
        // 
        // pnlButtons
        // 
        pnlButtons.AutoSize = true;
        pnlButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        pnlButtons.Controls.Add(btnDelete);
        pnlButtons.Controls.Add(btnSubmit);
        pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
        pnlButtons.Location = new System.Drawing.Point(234, 6);
        pnlButtons.Name = "pnlButtons";
        pnlButtons.Padding = new System.Windows.Forms.Padding(0, 5, 4, 0);
        pnlButtons.Size = new System.Drawing.Size(150, 32);
        pnlButtons.TabIndex = 1;
        // 
        // btnDelete
        // 
        btnDelete.AutoSize = true;
        btnDelete.ForeColor = System.Drawing.Color.Firebrick;
        btnDelete.Location = new System.Drawing.Point(132, 0);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new System.Drawing.Size(60, 28);
        btnDelete.TabIndex = 2;
        btnDelete.Text = "Delete";
        btnDelete.Click += btnDelete_Click;
        // 
        // btnSubmit
        // 
        btnSubmit.AutoSize = true;
        btnSubmit.Location = new System.Drawing.Point(66, 0);
        btnSubmit.Name = "btnSubmit";
        btnSubmit.Size = new System.Drawing.Size(70, 28);
        btnSubmit.TabIndex = 1;
        btnSubmit.Text = "Submit";
        btnSubmit.Click += btnSubmit_Click;
        // 
        // tabContent
        // 
        tabContent.Controls.Add(tabDetails);
        tabContent.Controls.Add(tabChapters);
        tabContent.Controls.Add(tabContributors);
        tabContent.Dock = System.Windows.Forms.DockStyle.Fill;
        tabContent.Font = new System.Drawing.Font("Segoe UI", 9F);
        tabContent.Location = new System.Drawing.Point(3, 47);
        tabContent.Name = "tabContent";
        tabContent.SelectedIndex = 0;
        tabContent.Size = new System.Drawing.Size(437, 276);
        tabContent.TabIndex = 1;
        // 
        // tabDetails
        // 
        tabDetails.Controls.Add(tlpFields);
        tabDetails.Dock = System.Windows.Forms.DockStyle.Fill;
        tabDetails.Location = new System.Drawing.Point(4, 24);
        tabDetails.Name = "tabDetails";
        tabDetails.Padding = new System.Windows.Forms.Padding(2);
        tabDetails.Size = new System.Drawing.Size(429, 248);
        tabDetails.TabIndex = 0;
        tabDetails.Text = "Details";
        // 
        // tlpFields
        // 
        tlpFields.ColumnCount = 2;
        tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
        tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpFields.Controls.Add(lblTitle, 0, 0);
        tlpFields.Controls.Add(txtTitle, 1, 0);
        tlpFields.Controls.Add(lblDescription, 0, 1);
        tlpFields.Controls.Add(txtDescription, 1, 1);
        tlpFields.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpFields.Location = new System.Drawing.Point(2, 2);
        tlpFields.Name = "tlpFields";
        tlpFields.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
        tlpFields.RowCount = 2;
        tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
        tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpFields.Size = new System.Drawing.Size(425, 244);
        tlpFields.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.Location = new System.Drawing.Point(11, 4);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(84, 23);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Title";
        // 
        // txtTitle
        // 
        txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
        txtTitle.Location = new System.Drawing.Point(101, 7);
        txtTitle.Name = "txtTitle";
        txtTitle.Size = new System.Drawing.Size(313, 23);
        txtTitle.TabIndex = 10;
        // 
        // lblDescription
        // 
        lblDescription.Location = new System.Drawing.Point(11, 36);
        lblDescription.Name = "lblDescription";
        lblDescription.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
        lblDescription.Size = new System.Drawing.Size(84, 23);
        lblDescription.TabIndex = 11;
        lblDescription.Text = "Description";
        // 
        // txtDescription
        // 
        txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
        txtDescription.Location = new System.Drawing.Point(101, 39);
        txtDescription.Multiline = true;
        txtDescription.Name = "txtDescription";
        txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        txtDescription.Size = new System.Drawing.Size(313, 198);
        txtDescription.TabIndex = 11;
        // 
        // tabChapters
        // 
        tabChapters.Controls.Add(tlpChapters);
        tabChapters.Dock = System.Windows.Forms.DockStyle.Fill;
        tabChapters.Location = new System.Drawing.Point(4, 24);
        tabChapters.Name = "tabChapters";
        tabChapters.Padding = new System.Windows.Forms.Padding(2);
        tabChapters.Size = new System.Drawing.Size(429, 248);
        tabChapters.TabIndex = 1;
        tabChapters.Text = "Chapters";
        // 
        // tlpChapters
        // 
        tlpChapters.ColumnCount = 1;
        tlpChapters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpChapters.Controls.Add(pnlChapterToolbar, 0, 0);
        tlpChapters.Controls.Add(dgvChapters, 0, 1);
        tlpChapters.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpChapters.Location = new System.Drawing.Point(2, 2);
        tlpChapters.Name = "tlpChapters";
        tlpChapters.RowCount = 2;
        tlpChapters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
        tlpChapters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpChapters.Size = new System.Drawing.Size(425, 244);
        tlpChapters.TabIndex = 0;
        // 
        // pnlChapterToolbar
        // 
        pnlChapterToolbar.Controls.Add(btnAddChapter);
        pnlChapterToolbar.Controls.Add(btnEditChapter);
        pnlChapterToolbar.Controls.Add(btnDeleteChapter);
        pnlChapterToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlChapterToolbar.Location = new System.Drawing.Point(3, 3);
        pnlChapterToolbar.Name = "pnlChapterToolbar";
        pnlChapterToolbar.Padding = new System.Windows.Forms.Padding(4);
        pnlChapterToolbar.Size = new System.Drawing.Size(419, 30);
        pnlChapterToolbar.TabIndex = 0;
        // 
        // btnAddChapter
        // 
        btnAddChapter.AutoSize = true;
        btnAddChapter.Location = new System.Drawing.Point(4, 4);
        btnAddChapter.Name = "btnAddChapter";
        btnAddChapter.Size = new System.Drawing.Size(70, 26);
        btnAddChapter.TabIndex = 0;
        btnAddChapter.Text = "Add";
        btnAddChapter.Click += btnAddChapter_Click;
        // 
        // btnEditChapter
        // 
        btnEditChapter.AutoSize = true;
        btnEditChapter.Location = new System.Drawing.Point(80, 4);
        btnEditChapter.Name = "btnEditChapter";
        btnEditChapter.Size = new System.Drawing.Size(70, 26);
        btnEditChapter.TabIndex = 1;
        btnEditChapter.Text = "Edit";
        btnEditChapter.Click += btnEditChapter_Click;
        // 
        // btnDeleteChapter
        // 
        btnDeleteChapter.AutoSize = true;
        btnDeleteChapter.ForeColor = System.Drawing.Color.Firebrick;
        btnDeleteChapter.Location = new System.Drawing.Point(156, 4);
        btnDeleteChapter.Name = "btnDeleteChapter";
        btnDeleteChapter.Size = new System.Drawing.Size(70, 26);
        btnDeleteChapter.TabIndex = 2;
        btnDeleteChapter.Text = "Delete";
        btnDeleteChapter.Click += btnDeleteChapter_Click;
        // 
        // dgvChapters
        // 
        dgvChapters.AllowUserToAddRows = false;
        dgvChapters.AllowUserToDeleteRows = false;
        dgvChapters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
        dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        dgvChapters.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        dgvChapters.DefaultCellStyle = dataGridViewCellStyle2;
        dgvChapters.Dock = System.Windows.Forms.DockStyle.Fill;
        dgvChapters.Location = new System.Drawing.Point(3, 39);
        dgvChapters.MultiSelect = false;
        dgvChapters.Name = "dgvChapters";
        dgvChapters.ReadOnly = true;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        dgvChapters.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
        dgvChapters.RowHeadersVisible = false;
        dgvChapters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvChapters.Size = new System.Drawing.Size(419, 202);
        dgvChapters.TabIndex = 1;
        dgvChapters.DoubleClick += dgvChapters_DoubleClick;
        // 
        // tabContributors
        // 
        tabContributors.Controls.Add(tlpContributors);
        tabContributors.Dock = System.Windows.Forms.DockStyle.Fill;
        tabContributors.Location = new System.Drawing.Point(4, 24);
        tabContributors.Name = "tabContributors";
        tabContributors.Padding = new System.Windows.Forms.Padding(2);
        tabContributors.Size = new System.Drawing.Size(429, 248);
        tabContributors.TabIndex = 2;
        tabContributors.Text = "Contributors";
        // 
        // tlpContributors
        // 
        tlpContributors.ColumnCount = 1;
        tlpContributors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpContributors.Controls.Add(pnlContributorToolbar, 0, 0);
        tlpContributors.Controls.Add(dgvContributors, 0, 1);
        tlpContributors.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpContributors.Location = new System.Drawing.Point(2, 2);
        tlpContributors.Name = "tlpContributors";
        tlpContributors.RowCount = 2;
        tlpContributors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
        tlpContributors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpContributors.Size = new System.Drawing.Size(425, 244);
        tlpContributors.TabIndex = 0;
        // 
        // pnlContributorToolbar
        // 
        pnlContributorToolbar.Controls.Add(btnAddContributor);
        pnlContributorToolbar.Controls.Add(btnEditContributor);
        pnlContributorToolbar.Controls.Add(btnRemoveContributor);
        pnlContributorToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlContributorToolbar.Location = new System.Drawing.Point(3, 3);
        pnlContributorToolbar.Name = "pnlContributorToolbar";
        pnlContributorToolbar.Padding = new System.Windows.Forms.Padding(4);
        pnlContributorToolbar.Size = new System.Drawing.Size(419, 30);
        pnlContributorToolbar.TabIndex = 0;
        // 
        // btnAddContributor
        // 
        btnAddContributor.AutoSize = true;
        btnAddContributor.Location = new System.Drawing.Point(4, 4);
        btnAddContributor.Name = "btnAddContributor";
        btnAddContributor.Size = new System.Drawing.Size(70, 26);
        btnAddContributor.TabIndex = 0;
        btnAddContributor.Text = "Add";
        btnAddContributor.Click += btnAddContributor_Click;
        // 
        // btnEditContributor
        // 
        btnEditContributor.AutoSize = true;
        btnEditContributor.Location = new System.Drawing.Point(80, 4);
        btnEditContributor.Name = "btnEditContributor";
        btnEditContributor.Size = new System.Drawing.Size(70, 26);
        btnEditContributor.TabIndex = 1;
        btnEditContributor.Text = "Edit";
        btnEditContributor.Click += btnEditContributor_Click;
        // 
        // btnRemoveContributor
        // 
        btnRemoveContributor.AutoSize = true;
        btnRemoveContributor.ForeColor = System.Drawing.Color.Firebrick;
        btnRemoveContributor.Location = new System.Drawing.Point(156, 4);
        btnRemoveContributor.Name = "btnRemoveContributor";
        btnRemoveContributor.Size = new System.Drawing.Size(70, 26);
        btnRemoveContributor.TabIndex = 2;
        btnRemoveContributor.Text = "Remove";
        btnRemoveContributor.Click += btnRemoveContributor_Click;
        // 
        // dgvContributors
        // 
        dgvContributors.AllowUserToAddRows = false;
        dgvContributors.AllowUserToDeleteRows = false;
        dgvContributors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
        dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
        dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        dgvContributors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
        dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
        dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
        dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        dgvContributors.DefaultCellStyle = dataGridViewCellStyle5;
        dgvContributors.Dock = System.Windows.Forms.DockStyle.Fill;
        dgvContributors.Location = new System.Drawing.Point(3, 39);
        dgvContributors.MultiSelect = false;
        dgvContributors.Name = "dgvContributors";
        dgvContributors.ReadOnly = true;
        dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
        dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
        dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        dgvContributors.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
        dgvContributors.RowHeadersVisible = false;
        dgvContributors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvContributors.Size = new System.Drawing.Size(419, 202);
        dgvContributors.TabIndex = 1;
        dgvContributors.DoubleClick += dgvContributors_DoubleClick;
        // 
        // lblStatus
        // 
        lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
        lblStatus.ForeColor = System.Drawing.SystemColors.GrayText;
        lblStatus.Location = new System.Drawing.Point(3, 326);
        lblStatus.Name = "lblStatus";
        lblStatus.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
        lblStatus.Size = new System.Drawing.Size(437, 26);
        lblStatus.TabIndex = 2;
        lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // BookEditControl
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(tlpOuter);
        Size = new System.Drawing.Size(443, 352);
        tlpOuter.ResumeLayout(false);
        pnlToolbar.ResumeLayout(false);
        pnlToolbar.PerformLayout();
        pnlButtons.ResumeLayout(false);
        pnlButtons.PerformLayout();
        tabContent.ResumeLayout(false);
        tabDetails.ResumeLayout(false);
        tlpFields.ResumeLayout(false);
        tlpFields.PerformLayout();
        tabChapters.ResumeLayout(false);
        tlpChapters.ResumeLayout(false);
        pnlChapterToolbar.ResumeLayout(false);
        pnlChapterToolbar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvChapters).EndInit();
        tabContributors.ResumeLayout(false);
        tlpContributors.ResumeLayout(false);
        pnlContributorToolbar.ResumeLayout(false);
        pnlContributorToolbar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvContributors).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.TableLayoutPanel tlpOuter;
    private System.Windows.Forms.Panel pnlToolbar;
    private System.Windows.Forms.Label lblHeading;
    private System.Windows.Forms.Panel pnlButtons;
    private System.Windows.Forms.Button btnSubmit;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.TabControl tabContent;
    private System.Windows.Forms.TabPage tabDetails;
    private System.Windows.Forms.TableLayoutPanel tlpFields;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.TextBox txtTitle;
    private System.Windows.Forms.Label lblDescription;
    private System.Windows.Forms.TextBox txtDescription;
    private System.Windows.Forms.TabPage tabChapters;
    private System.Windows.Forms.TableLayoutPanel tlpChapters;
    private System.Windows.Forms.Panel pnlChapterToolbar;
    private System.Windows.Forms.Button btnAddChapter;
    private System.Windows.Forms.Button btnEditChapter;
    private System.Windows.Forms.Button btnDeleteChapter;
    private System.Windows.Forms.DataGridView dgvChapters;
    private System.Windows.Forms.TabPage tabContributors;
    private System.Windows.Forms.TableLayoutPanel tlpContributors;
    private System.Windows.Forms.Panel pnlContributorToolbar;
    private System.Windows.Forms.Button btnAddContributor;
    private System.Windows.Forms.Button btnEditContributor;
    private System.Windows.Forms.Button btnRemoveContributor;
    private System.Windows.Forms.DataGridView dgvContributors;
    private System.Windows.Forms.Label lblStatus;
}
