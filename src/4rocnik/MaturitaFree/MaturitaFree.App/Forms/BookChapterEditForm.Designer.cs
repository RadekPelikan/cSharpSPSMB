namespace MaturitaFree.App.Forms;

partial class BookChapterEditForm
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
        tlpMain       = new System.Windows.Forms.TableLayoutPanel();
        pnlHeader     = new System.Windows.Forms.Panel();
        lblHeading    = new System.Windows.Forms.Label();
        tlpFields     = new System.Windows.Forms.TableLayoutPanel();
        lblTitle      = new System.Windows.Forms.Label();
        txtTitle      = new System.Windows.Forms.TextBox();
        lblOrder      = new System.Windows.Forms.Label();
        nudOrder      = new System.Windows.Forms.NumericUpDown();
        grpParagraphs = new System.Windows.Forms.GroupBox();
        tlpParagraphs = new System.Windows.Forms.TableLayoutPanel();
        pnlParaToolbar = new System.Windows.Forms.Panel();
        btnAddParagraph    = new System.Windows.Forms.Button();
        btnEditParagraph   = new System.Windows.Forms.Button();
        btnDeleteParagraph = new System.Windows.Forms.Button();
        dgvParagraphs      = new System.Windows.Forms.DataGridView();
        lblParagraphHint   = new System.Windows.Forms.Label();
        pnlBottom     = new System.Windows.Forms.Panel();
        btnSaveChapter = new System.Windows.Forms.Button();
        btnCancel      = new System.Windows.Forms.Button();
        lblStatus      = new System.Windows.Forms.Label();

        tlpMain.SuspendLayout();
        pnlHeader.SuspendLayout();
        tlpFields.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudOrder).BeginInit();
        grpParagraphs.SuspendLayout();
        tlpParagraphs.SuspendLayout();
        pnlParaToolbar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvParagraphs).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();

        // tlpMain
        tlpMain.ColumnCount = 1;
        tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpMain.RowCount = 4;
        tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
        tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
        tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
        tlpMain.Controls.Add(pnlHeader, 0, 0);
        tlpMain.Controls.Add(tlpFields, 0, 1);
        tlpMain.Controls.Add(grpParagraphs, 0, 2);
        tlpMain.Controls.Add(pnlBottom, 0, 3);
        tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;

        // pnlHeader
        pnlHeader.Controls.Add(lblHeading);
        pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlHeader.Padding = new System.Windows.Forms.Padding(8, 8, 8, 0);

        // lblHeading
        lblHeading.AutoSize = true;
        lblHeading.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        lblHeading.Location = new System.Drawing.Point(8, 8);
        lblHeading.Text = "Add Chapter";

        // tlpFields
        tlpFields.ColumnCount = 2;
        tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
        tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpFields.RowCount = 2;
        tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
        tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
        tlpFields.Controls.Add(lblTitle, 0, 0);
        tlpFields.Controls.Add(txtTitle, 1, 0);
        tlpFields.Controls.Add(lblOrder, 0, 1);
        tlpFields.Controls.Add(nudOrder, 1, 1);
        tlpFields.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpFields.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);

        // lblTitle
        lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
        lblTitle.Location = new System.Drawing.Point(3, 8);
        lblTitle.Text = "Title";

        // txtTitle
        txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
        txtTitle.TabIndex = 0;

        // lblOrder
        lblOrder.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
        lblOrder.Location = new System.Drawing.Point(3, 8);
        lblOrder.Text = "Order";

        // nudOrder
        nudOrder.Minimum = 1;
        nudOrder.Maximum = 9999;
        nudOrder.Value = 1;
        nudOrder.TabIndex = 1;
        nudOrder.Width = 80;

        // grpParagraphs
        grpParagraphs.Controls.Add(tlpParagraphs);
        grpParagraphs.Dock = System.Windows.Forms.DockStyle.Fill;
        grpParagraphs.Text = "Paragraphs";
        grpParagraphs.Padding = new System.Windows.Forms.Padding(6);

        // tlpParagraphs
        tlpParagraphs.ColumnCount = 1;
        tlpParagraphs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpParagraphs.RowCount = 3;
        tlpParagraphs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
        tlpParagraphs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpParagraphs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
        tlpParagraphs.Controls.Add(pnlParaToolbar, 0, 0);
        tlpParagraphs.Controls.Add(dgvParagraphs, 0, 1);
        tlpParagraphs.Controls.Add(lblParagraphHint, 0, 2);
        tlpParagraphs.Dock = System.Windows.Forms.DockStyle.Fill;

        // pnlParaToolbar
        pnlParaToolbar.Controls.Add(btnAddParagraph);
        pnlParaToolbar.Controls.Add(btnEditParagraph);
        pnlParaToolbar.Controls.Add(btnDeleteParagraph);
        pnlParaToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlParaToolbar.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);

        // btnAddParagraph
        btnAddParagraph.AutoSize = true;
        btnAddParagraph.Location = new System.Drawing.Point(0, 4);
        btnAddParagraph.Size = new System.Drawing.Size(70, 26);
        btnAddParagraph.Text = "Add";
        btnAddParagraph.TabIndex = 0;
        btnAddParagraph.Click += btnAddParagraph_Click;

        // btnEditParagraph
        btnEditParagraph.AutoSize = true;
        btnEditParagraph.Location = new System.Drawing.Point(76, 4);
        btnEditParagraph.Size = new System.Drawing.Size(70, 26);
        btnEditParagraph.Text = "Edit";
        btnEditParagraph.TabIndex = 1;
        btnEditParagraph.Click += btnEditParagraph_Click;

        // btnDeleteParagraph
        btnDeleteParagraph.AutoSize = true;
        btnDeleteParagraph.ForeColor = System.Drawing.Color.Firebrick;
        btnDeleteParagraph.Location = new System.Drawing.Point(152, 4);
        btnDeleteParagraph.Size = new System.Drawing.Size(70, 26);
        btnDeleteParagraph.Text = "Delete";
        btnDeleteParagraph.TabIndex = 2;
        btnDeleteParagraph.Click += btnDeleteParagraph_Click;

        // dgvParagraphs
        dgvParagraphs.AllowUserToAddRows = false;
        dgvParagraphs.AllowUserToDeleteRows = false;
        dgvParagraphs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvParagraphs.Dock = System.Windows.Forms.DockStyle.Fill;
        dgvParagraphs.ReadOnly = true;
        dgvParagraphs.RowHeadersVisible = false;
        dgvParagraphs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvParagraphs.MultiSelect = false;
        dgvParagraphs.DoubleClick += dgvParagraphs_DoubleClick;

        // lblParagraphHint
        lblParagraphHint.Dock = System.Windows.Forms.DockStyle.Fill;
        lblParagraphHint.ForeColor = System.Drawing.SystemColors.GrayText;
        lblParagraphHint.Text = "Save the chapter first to add paragraphs.";
        lblParagraphHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        lblParagraphHint.Visible = false;

        // pnlBottom
        pnlBottom.Controls.Add(lblStatus);
        pnlBottom.Controls.Add(btnCancel);
        pnlBottom.Controls.Add(btnSaveChapter);
        pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlBottom.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);

        // btnSaveChapter
        btnSaveChapter.AutoSize = true;
        btnSaveChapter.Location = new System.Drawing.Point(8, 6);
        btnSaveChapter.Size = new System.Drawing.Size(90, 30);
        btnSaveChapter.Text = "Save";
        btnSaveChapter.TabIndex = 0;
        btnSaveChapter.Click += btnSaveChapter_Click;

        // btnCancel
        btnCancel.AutoSize = true;
        btnCancel.Location = new System.Drawing.Point(104, 6);
        btnCancel.Size = new System.Drawing.Size(90, 30);
        btnCancel.Text = "Cancel";
        btnCancel.TabIndex = 1;
        btnCancel.Click += btnCancel_Click;

        // lblStatus
        lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
        lblStatus.ForeColor = System.Drawing.SystemColors.GrayText;
        lblStatus.Location = new System.Drawing.Point(210, 12);
        lblStatus.Size = new System.Drawing.Size(360, 20);
        lblStatus.Text = "";

        // BookChapterEditForm
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        ClientSize = new System.Drawing.Size(600, 520);
        MinimumSize = new System.Drawing.Size(520, 420);
        Controls.Add(tlpMain);
        Font = new System.Drawing.Font("Segoe UI", 9F);
        MinimizeBox = false;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Chapter";

        tlpMain.ResumeLayout(false);
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        tlpFields.ResumeLayout(false);
        tlpFields.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudOrder).EndInit();
        grpParagraphs.ResumeLayout(false);
        tlpParagraphs.ResumeLayout(false);
        pnlParaToolbar.ResumeLayout(false);
        pnlParaToolbar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvParagraphs).EndInit();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.TableLayoutPanel tlpMain;
    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblHeading;
    private System.Windows.Forms.TableLayoutPanel tlpFields;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.TextBox txtTitle;
    private System.Windows.Forms.Label lblOrder;
    private System.Windows.Forms.NumericUpDown nudOrder;
    private System.Windows.Forms.GroupBox grpParagraphs;
    private System.Windows.Forms.TableLayoutPanel tlpParagraphs;
    private System.Windows.Forms.Panel pnlParaToolbar;
    private System.Windows.Forms.Button btnAddParagraph;
    private System.Windows.Forms.Button btnEditParagraph;
    private System.Windows.Forms.Button btnDeleteParagraph;
    private System.Windows.Forms.DataGridView dgvParagraphs;
    private System.Windows.Forms.Label lblParagraphHint;
    private System.Windows.Forms.Panel pnlBottom;
    private System.Windows.Forms.Button btnSaveChapter;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label lblStatus;
}
