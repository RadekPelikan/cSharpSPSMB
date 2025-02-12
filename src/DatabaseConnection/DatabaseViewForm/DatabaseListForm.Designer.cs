﻿using System.ComponentModel;

namespace DatabaseViewForm;

partial class DatabaseListForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
        Languages = new System.Windows.Forms.Button();
        Users = new System.Windows.Forms.Button();
        USER_LANGUAGE_RELATION = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // Languages
        // 
        Languages.Location = new System.Drawing.Point(246, 174);
        Languages.Name = "Languages";
        Languages.Size = new System.Drawing.Size(276, 23);
        Languages.TabIndex = 2;
        Languages.Text = "Languages";
        Languages.UseVisualStyleBackColor = true;
        Languages.Click += Languages_Click;
        // 
        // Users
        // 
        Users.Location = new System.Drawing.Point(246, 106);
        Users.Name = "Users";
        Users.Size = new System.Drawing.Size(276, 23);
        Users.TabIndex = 3;
        Users.Text = "Users";
        Users.UseVisualStyleBackColor = true;
        Users.Click += Users_Click;
        // 
        // USER_LANGUAGE_RELATION
        // 
        USER_LANGUAGE_RELATION.Location = new System.Drawing.Point(246, 239);
        USER_LANGUAGE_RELATION.Name = "USER_LANGUAGE_RELATION";
        USER_LANGUAGE_RELATION.Size = new System.Drawing.Size(276, 23);
        USER_LANGUAGE_RELATION.TabIndex = 5;
        USER_LANGUAGE_RELATION.Text = "USER_LANGUAGE_RELATION";
        USER_LANGUAGE_RELATION.UseVisualStyleBackColor = true;
        USER_LANGUAGE_RELATION.Click += USER_LANGUAGE_RELATION_Click;
        // 
        // DatabaseListForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(USER_LANGUAGE_RELATION);
        Controls.Add(Users);
        Controls.Add(Languages);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        Text = "DatabaseListForm";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button Languages;

    private System.Windows.Forms.Button USER_LANGUAGE_RELATION;

    private System.Windows.Forms.Button Users;

    #endregion
}