namespace MaturitaFree.App.Forms;

partial class BookParagraphEditForm
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
        tlpMain    = new System.Windows.Forms.TableLayoutPanel();
        pnlHeader  = new System.Windows.Forms.Panel();
        lblHeading = new System.Windows.Forms.Label();
        tlpFields  = new System.Windows.Forms.TableLayoutPanel();
        lblOrder   = new System.Windows.Forms.Label();
        nudOrder   = new System.Windows.Forms.NumericUpDown();
        lblContent = new System.Windows.Forms.Label();
        txtContent = new System.Windows.Forms.TextBox();
        pnlBottom  = new System.Windows.Forms.Panel();
        btnSave    = new System.Windows.Forms.Button();
        btnCancel  = new System.Windows.Forms.Button();
        lblStatus  = new System.Windows.Forms.Label();

        tlpMain.SuspendLayout();
        pnlHeader.SuspendLayout();
        tlpFields.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudOrder).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();

        // tlpMain
        tlpMain.ColumnCount = 1;
        tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpMain.RowCount = 3;
        tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
        tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
        tlpMain.Controls.Add(pnlHeader, 0, 0);
        tlpMain.Controls.Add(tlpFields, 0, 1);
        tlpMain.Controls.Add(pnlBottom, 0, 2);
        tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;

        // pnlHeader
        pnlHeader.Controls.Add(lblHeading);
        pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlHeader.Padding = new System.Windows.Forms.Padding(8, 8, 8, 0);

        // lblHeading
        lblHeading.AutoSize = true;
        lblHeading.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        lblHeading.Location = new System.Drawing.Point(8, 8);
        lblHeading.Text = "Add Paragraph";

        // tlpFields
        tlpFields.ColumnCount = 2;
        tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
        tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpFields.RowCount = 2;
        tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
        tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpFields.Controls.Add(lblOrder, 0, 0);
        tlpFields.Controls.Add(nudOrder, 1, 0);
        tlpFields.Controls.Add(lblContent, 0, 1);
        tlpFields.Controls.Add(txtContent, 1, 1);
        tlpFields.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpFields.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);

        // lblOrder
        lblOrder.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
        lblOrder.Location = new System.Drawing.Point(3, 8);
        lblOrder.Text = "Order";

        // nudOrder
        nudOrder.Minimum = 1;
        nudOrder.Maximum = 9999;
        nudOrder.Value = 1;
        nudOrder.TabIndex = 0;
        nudOrder.Width = 80;

        // lblContent
        lblContent.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
        lblContent.Location = new System.Drawing.Point(3, 6);
        lblContent.Text = "Content";

        // txtContent
        txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
        txtContent.Multiline = true;
        txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        txtContent.TabIndex = 1;

        // pnlBottom
        pnlBottom.Controls.Add(lblStatus);
        pnlBottom.Controls.Add(btnCancel);
        pnlBottom.Controls.Add(btnSave);
        pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlBottom.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);

        // btnSave
        btnSave.AutoSize = true;
        btnSave.Location = new System.Drawing.Point(8, 6);
        btnSave.Size = new System.Drawing.Size(90, 30);
        btnSave.Text = "Save";
        btnSave.TabIndex = 0;
        btnSave.Click += btnSave_Click;

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
        lblStatus.Size = new System.Drawing.Size(260, 20);
        lblStatus.Text = "";

        // BookParagraphEditForm
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        ClientSize = new System.Drawing.Size(520, 380);
        MinimumSize = new System.Drawing.Size(420, 300);
        Controls.Add(tlpMain);
        Font = new System.Drawing.Font("Segoe UI", 9F);
        MinimizeBox = false;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Paragraph";

        tlpMain.ResumeLayout(false);
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        tlpFields.ResumeLayout(false);
        tlpFields.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudOrder).EndInit();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.TableLayoutPanel tlpMain;
    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblHeading;
    private System.Windows.Forms.TableLayoutPanel tlpFields;
    private System.Windows.Forms.Label lblOrder;
    private System.Windows.Forms.NumericUpDown nudOrder;
    private System.Windows.Forms.Label lblContent;
    private System.Windows.Forms.TextBox txtContent;
    private System.Windows.Forms.Panel pnlBottom;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label lblStatus;
}
