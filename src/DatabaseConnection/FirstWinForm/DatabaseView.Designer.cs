namespace FirstWinForm;

partial class DatabaseView
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseView));
        CookieLabel = new System.Windows.Forms.Label();
        CookieButton = new System.Windows.Forms.Button();
        pictureBox1 = new System.Windows.Forms.PictureBox();
        BuyUpgradeClick = new System.Windows.Forms.Button();
        BuyUpgradePerSecond = new System.Windows.Forms.Button();
        UpgradesContainer = new System.Windows.Forms.TableLayoutPanel();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // CookieLabel
        // 
        CookieLabel.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
        CookieLabel.Location = new System.Drawing.Point(12, 9);
        CookieLabel.Name = "CookieLabel";
        CookieLabel.Size = new System.Drawing.Size(313, 84);
        CookieLabel.TabIndex = 0;
        CookieLabel.Text = "cookies: 0";
        // 
        // CookieButton
        // 
        CookieButton.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
        CookieButton.Location = new System.Drawing.Point(12, 111);
        CookieButton.Name = "CookieButton";
        CookieButton.Size = new System.Drawing.Size(283, 83);
        CookieButton.TabIndex = 1;
        CookieButton.Text = "I dare u to click me!";
        CookieButton.UseVisualStyleBackColor = true;
        CookieButton.Click += CookieButton_Click;
        // 
        // pictureBox1
        // 
        pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        pictureBox1.Image = ((System.Drawing.Image)resources.GetObject("pictureBox1.Image"));
        pictureBox1.Location = new System.Drawing.Point(341, 35);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(187, 185);
        pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        pictureBox1.TabIndex = 2;
        pictureBox1.TabStop = false;
        // 
        // BuyUpgradeClick
        // 
        BuyUpgradeClick.Location = new System.Drawing.Point(21, 226);
        BuyUpgradeClick.Name = "BuyUpgradeClick";
        BuyUpgradeClick.Size = new System.Drawing.Size(157, 46);
        BuyUpgradeClick.TabIndex = 3;
        BuyUpgradeClick.Text = "Buy upgrade per click\r\ncost: 0";
        BuyUpgradeClick.UseVisualStyleBackColor = true;
        BuyUpgradeClick.Click += BuyUpgradeClick_Click;
        // 
        // BuyUpgradePerSecond
        // 
        BuyUpgradePerSecond.Location = new System.Drawing.Point(21, 294);
        BuyUpgradePerSecond.Name = "BuyUpgradePerSecond";
        BuyUpgradePerSecond.Size = new System.Drawing.Size(157, 46);
        BuyUpgradePerSecond.TabIndex = 4;
        BuyUpgradePerSecond.Text = "Buy upgrade per second\r\ncost: 0";
        BuyUpgradePerSecond.UseVisualStyleBackColor = true;
        BuyUpgradePerSecond.Click += BuyUpgradePerSecond_Click;
        // 
        // UpgradesContainer
        // 
        UpgradesContainer.ColumnCount = 2;
        UpgradesContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        UpgradesContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        UpgradesContainer.Location = new System.Drawing.Point(184, 226);
        UpgradesContainer.Name = "UpgradesContainer";
        UpgradesContainer.RowCount = 2;
        UpgradesContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        UpgradesContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        UpgradesContainer.Size = new System.Drawing.Size(496, 114);
        UpgradesContainer.TabIndex = 5;
        // 
        // DatabaseView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(UpgradesContainer);
        Controls.Add(BuyUpgradePerSecond);
        Controls.Add(BuyUpgradeClick);
        Controls.Add(pictureBox1);
        Controls.Add(CookieButton);
        Controls.Add(CookieLabel);
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.TableLayoutPanel UpgradesContainer;

    private System.Windows.Forms.Button BuyUpgradePerSecond;

    private System.Windows.Forms.Button BuyUpgradeClick;

    private System.Windows.Forms.PictureBox pictureBox1;

    private System.Windows.Forms.Label CookieLabel;
    private System.Windows.Forms.Button CookieButton;

    #endregion
}