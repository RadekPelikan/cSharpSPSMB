namespace MaturitaFree.App.Controls;

partial class PersonEditControl
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
        tlpOuter = new System.Windows.Forms.TableLayoutPanel();
        pnlToolbar = new System.Windows.Forms.Panel();
        lblHeading = new System.Windows.Forms.Label();
        pnlButtons = new System.Windows.Forms.Panel();
        btnDelete = new System.Windows.Forms.Button();
        btnSubmit = new System.Windows.Forms.Button();
        tlpFields = new System.Windows.Forms.TableLayoutPanel();
        lblFirstName = new System.Windows.Forms.Label();
        txtFirstName = new System.Windows.Forms.TextBox();
        lblMiddleName = new System.Windows.Forms.Label();
        txtMiddleName = new System.Windows.Forms.TextBox();
        lblLastName = new System.Windows.Forms.Label();
        txtLastName = new System.Windows.Forms.TextBox();
        lblPseudonym = new System.Windows.Forms.Label();
        txtPseudonym = new System.Windows.Forms.TextBox();
        lblDescription = new System.Windows.Forms.Label();
        txtDescription = new System.Windows.Forms.TextBox();
        lblStatus = new System.Windows.Forms.Label();
        tlpOuter.SuspendLayout();
        pnlToolbar.SuspendLayout();
        pnlButtons.SuspendLayout();
        tlpFields.SuspendLayout();
        SuspendLayout();
        // 
        // tlpOuter
        // 
        tlpOuter.ColumnCount = 1;
        tlpOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpOuter.Controls.Add(pnlToolbar, 0, 0);
        tlpOuter.Controls.Add(tlpFields, 0, 1);
        tlpOuter.Controls.Add(lblStatus, 0, 2);
        tlpOuter.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpOuter.Location = new System.Drawing.Point(0, 0);
        tlpOuter.Name = "tlpOuter";
        tlpOuter.RowCount = 3;
        tlpOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
        tlpOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
        tlpOuter.Size = new System.Drawing.Size(539, 515);
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
        pnlToolbar.Size = new System.Drawing.Size(533, 38);
        pnlToolbar.TabIndex = 0;
        // 
        // lblHeading
        // 
        lblHeading.AutoSize = true;
        lblHeading.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        lblHeading.Location = new System.Drawing.Point(4, 8);
        lblHeading.Name = "lblHeading";
        lblHeading.Size = new System.Drawing.Size(90, 20);
        lblHeading.TabIndex = 0;
        lblHeading.Text = "Add Person";
        // 
        // pnlButtons
        // 
        pnlButtons.AutoSize = true;
        pnlButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        pnlButtons.Controls.Add(btnDelete);
        pnlButtons.Controls.Add(btnSubmit);
        pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
        pnlButtons.Location = new System.Drawing.Point(330, 6);
        pnlButtons.Name = "pnlButtons";
        pnlButtons.Padding = new System.Windows.Forms.Padding(0, 5, 4, 0);
        pnlButtons.Size = new System.Drawing.Size(199, 32);
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
        btnSubmit.Location = new System.Drawing.Point(56, 0);
        btnSubmit.Name = "btnSubmit";
        btnSubmit.Size = new System.Drawing.Size(70, 28);
        btnSubmit.TabIndex = 1;
        btnSubmit.Text = "Submit";
        btnSubmit.Click += btnSubmit_Click;
        // 
        // tlpFields
        // 
        tlpFields.ColumnCount = 2;
        tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
        tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpFields.Controls.Add(lblFirstName, 0, 0);
        tlpFields.Controls.Add(txtFirstName, 1, 0);
        tlpFields.Controls.Add(lblMiddleName, 0, 1);
        tlpFields.Controls.Add(txtMiddleName, 1, 1);
        tlpFields.Controls.Add(lblLastName, 0, 2);
        tlpFields.Controls.Add(txtLastName, 1, 2);
        tlpFields.Controls.Add(lblPseudonym, 0, 3);
        tlpFields.Controls.Add(txtPseudonym, 1, 3);
        tlpFields.Controls.Add(lblDescription, 0, 4);
        tlpFields.Controls.Add(txtDescription, 1, 4);
        tlpFields.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpFields.Location = new System.Drawing.Point(3, 47);
        tlpFields.Name = "tlpFields";
        tlpFields.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
        tlpFields.RowCount = 5;
        tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
        tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
        tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
        tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
        tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpFields.Size = new System.Drawing.Size(533, 439);
        tlpFields.TabIndex = 1;
        // 
        // lblFirstName
        // 
        lblFirstName.Location = new System.Drawing.Point(11, 4);
        lblFirstName.Name = "lblFirstName";
        lblFirstName.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
        lblFirstName.Size = new System.Drawing.Size(84, 23);
        lblFirstName.TabIndex = 0;
        lblFirstName.Text = "First name";
        // 
        // txtFirstName
        // 
        txtFirstName.Dock = System.Windows.Forms.DockStyle.Fill;
        txtFirstName.Location = new System.Drawing.Point(101, 7);
        txtFirstName.Name = "txtFirstName";
        txtFirstName.Size = new System.Drawing.Size(421, 23);
        txtFirstName.TabIndex = 10;
        // 
        // lblMiddleName
        // 
        lblMiddleName.Location = new System.Drawing.Point(11, 36);
        lblMiddleName.Name = "lblMiddleName";
        lblMiddleName.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
        lblMiddleName.Size = new System.Drawing.Size(84, 23);
        lblMiddleName.TabIndex = 11;
        lblMiddleName.Text = "Middle name";
        // 
        // txtMiddleName
        // 
        txtMiddleName.Dock = System.Windows.Forms.DockStyle.Fill;
        txtMiddleName.Location = new System.Drawing.Point(101, 39);
        txtMiddleName.Name = "txtMiddleName";
        txtMiddleName.Size = new System.Drawing.Size(421, 23);
        txtMiddleName.TabIndex = 11;
        // 
        // lblLastName
        // 
        lblLastName.Location = new System.Drawing.Point(11, 68);
        lblLastName.Name = "lblLastName";
        lblLastName.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
        lblLastName.Size = new System.Drawing.Size(84, 23);
        lblLastName.TabIndex = 12;
        lblLastName.Text = "Last name";
        // 
        // txtLastName
        // 
        txtLastName.Dock = System.Windows.Forms.DockStyle.Fill;
        txtLastName.Location = new System.Drawing.Point(101, 71);
        txtLastName.Name = "txtLastName";
        txtLastName.Size = new System.Drawing.Size(421, 23);
        txtLastName.TabIndex = 12;
        // 
        // lblPseudonym
        // 
        lblPseudonym.Location = new System.Drawing.Point(11, 100);
        lblPseudonym.Name = "lblPseudonym";
        lblPseudonym.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
        lblPseudonym.Size = new System.Drawing.Size(84, 23);
        lblPseudonym.TabIndex = 13;
        lblPseudonym.Text = "Pseudonym";
        // 
        // txtPseudonym
        // 
        txtPseudonym.Dock = System.Windows.Forms.DockStyle.Fill;
        txtPseudonym.Location = new System.Drawing.Point(101, 103);
        txtPseudonym.Name = "txtPseudonym";
        txtPseudonym.Size = new System.Drawing.Size(421, 23);
        txtPseudonym.TabIndex = 13;
        // 
        // lblDescription
        // 
        lblDescription.Location = new System.Drawing.Point(11, 132);
        lblDescription.Name = "lblDescription";
        lblDescription.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
        lblDescription.Size = new System.Drawing.Size(84, 23);
        lblDescription.TabIndex = 14;
        lblDescription.Text = "Description";
        // 
        // txtDescription
        // 
        txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
        txtDescription.Location = new System.Drawing.Point(101, 135);
        txtDescription.Multiline = true;
        txtDescription.Name = "txtDescription";
        txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        txtDescription.Size = new System.Drawing.Size(421, 297);
        txtDescription.TabIndex = 14;
        // 
        // lblStatus
        // 
        lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
        lblStatus.ForeColor = System.Drawing.SystemColors.GrayText;
        lblStatus.Location = new System.Drawing.Point(3, 489);
        lblStatus.Name = "lblStatus";
        lblStatus.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
        lblStatus.Size = new System.Drawing.Size(533, 26);
        lblStatus.TabIndex = 2;
        lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // PersonEditControl
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(tlpOuter);
        Size = new System.Drawing.Size(539, 515);
        tlpOuter.ResumeLayout(false);
        pnlToolbar.ResumeLayout(false);
        pnlToolbar.PerformLayout();
        pnlButtons.ResumeLayout(false);
        pnlButtons.PerformLayout();
        tlpFields.ResumeLayout(false);
        tlpFields.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.TableLayoutPanel tlpOuter;
    private System.Windows.Forms.Panel pnlToolbar;
    private System.Windows.Forms.Label lblHeading;
    private System.Windows.Forms.Panel pnlButtons;
    private System.Windows.Forms.Button btnSubmit;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.TableLayoutPanel tlpFields;
    private System.Windows.Forms.Label lblFirstName;
    private System.Windows.Forms.TextBox txtFirstName;
    private System.Windows.Forms.Label lblMiddleName;
    private System.Windows.Forms.TextBox txtMiddleName;
    private System.Windows.Forms.Label lblLastName;
    private System.Windows.Forms.TextBox txtLastName;
    private System.Windows.Forms.Label lblPseudonym;
    private System.Windows.Forms.TextBox txtPseudonym;
    private System.Windows.Forms.Label lblDescription;
    private System.Windows.Forms.TextBox txtDescription;
    private System.Windows.Forms.Label lblStatus;
}
