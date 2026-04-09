namespace MaturitaFree.App.Forms;

partial class PersonWorkingOnBookEditForm
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
        lblPerson     = new System.Windows.Forms.Label();
        cmbPerson     = new System.Windows.Forms.ComboBox();
        lblType       = new System.Windows.Forms.Label();
        cmbType       = new System.Windows.Forms.ComboBox();
        lblDescription = new System.Windows.Forms.Label();
        txtDescription = new System.Windows.Forms.TextBox();
        pnlBottom     = new System.Windows.Forms.Panel();
        btnSave       = new System.Windows.Forms.Button();
        btnCancel     = new System.Windows.Forms.Button();
        lblStatus     = new System.Windows.Forms.Label();

        tlpMain.SuspendLayout();
        pnlHeader.SuspendLayout();
        tlpFields.SuspendLayout();
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
        lblHeading.Text = "Add Contributor";

        // tlpFields
        tlpFields.ColumnCount = 2;
        tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
        tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpFields.RowCount = 3;
        tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
        tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
        tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpFields.Controls.Add(lblPerson, 0, 0);
        tlpFields.Controls.Add(cmbPerson, 1, 0);
        tlpFields.Controls.Add(lblType, 0, 1);
        tlpFields.Controls.Add(cmbType, 1, 1);
        tlpFields.Controls.Add(lblDescription, 0, 2);
        tlpFields.Controls.Add(txtDescription, 1, 2);
        tlpFields.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpFields.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);

        // lblPerson
        lblPerson.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
        lblPerson.Location = new System.Drawing.Point(3, 10);
        lblPerson.Text = "Person";

        // cmbPerson
        cmbPerson.Dock = System.Windows.Forms.DockStyle.Fill;
        cmbPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbPerson.TabIndex = 0;

        // lblType
        lblType.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
        lblType.Location = new System.Drawing.Point(3, 10);
        lblType.Text = "Role";

        // cmbType
        cmbType.Dock = System.Windows.Forms.DockStyle.Fill;
        cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbType.TabIndex = 1;

        // lblDescription
        lblDescription.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
        lblDescription.Location = new System.Drawing.Point(3, 6);
        lblDescription.Text = "Description";

        // txtDescription
        txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
        txtDescription.Multiline = true;
        txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        txtDescription.TabIndex = 2;

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

        // PersonWorkingOnBookEditForm
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        ClientSize = new System.Drawing.Size(480, 320);
        MinimumSize = new System.Drawing.Size(400, 280);
        Controls.Add(tlpMain);
        Font = new System.Drawing.Font("Segoe UI", 9F);
        MinimizeBox = false;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Contributor";

        tlpMain.ResumeLayout(false);
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        tlpFields.ResumeLayout(false);
        tlpFields.PerformLayout();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.TableLayoutPanel tlpMain;
    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblHeading;
    private System.Windows.Forms.TableLayoutPanel tlpFields;
    private System.Windows.Forms.Label lblPerson;
    private System.Windows.Forms.ComboBox cmbPerson;
    private System.Windows.Forms.Label lblType;
    private System.Windows.Forms.ComboBox cmbType;
    private System.Windows.Forms.Label lblDescription;
    private System.Windows.Forms.TextBox txtDescription;
    private System.Windows.Forms.Panel pnlBottom;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label lblStatus;
}
