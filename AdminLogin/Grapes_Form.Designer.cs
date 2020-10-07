﻿namespace AdminLogin
{
    partial class Grapes_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOverview = new System.Windows.Forms.TabPage();
            this.lbGrapes = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearchOverview = new System.Windows.Forms.Button();
            this.btnRefreshOverview = new System.Windows.Forms.Button();
            this.tabManage = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlID = new System.Windows.Forms.Panel();
            this.btnRefreshInfo = new System.Windows.Forms.Button();
            this.btnRefreshIDs = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbIDs = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMod = new System.Windows.Forms.CheckBox();
            this.gbGrapeInfo = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabOverview.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabManage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlID.SuspendLayout();
            this.gbGrapeInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabOverview);
            this.tabControl1.Controls.Add(this.tabManage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabOverview
            // 
            this.tabOverview.Controls.Add(this.lbGrapes);
            this.tabOverview.Controls.Add(this.groupBox2);
            this.tabOverview.Location = new System.Drawing.Point(4, 25);
            this.tabOverview.Name = "tabOverview";
            this.tabOverview.Padding = new System.Windows.Forms.Padding(3);
            this.tabOverview.Size = new System.Drawing.Size(792, 421);
            this.tabOverview.TabIndex = 0;
            this.tabOverview.Text = "Overview";
            this.tabOverview.UseVisualStyleBackColor = true;
            // 
            // lbGrapes
            // 
            this.lbGrapes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGrapes.FormattingEnabled = true;
            this.lbGrapes.ItemHeight = 16;
            this.lbGrapes.Location = new System.Drawing.Point(8, 76);
            this.lbGrapes.Name = "lbGrapes";
            this.lbGrapes.Size = new System.Drawing.Size(776, 340);
            this.lbGrapes.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Controls.Add(this.btnSearchOverview);
            this.groupBox2.Controls.Add(this.btnRefreshOverview);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 67);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(381, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(298, 22);
            this.txtSearch.TabIndex = 2;
            this.toolTips.SetToolTip(this.txtSearch, "What to search for in the overview.");
            // 
            // btnSearchOverview
            // 
            this.btnSearchOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchOverview.Location = new System.Drawing.Point(685, 27);
            this.btnSearchOverview.Name = "btnSearchOverview";
            this.btnSearchOverview.Size = new System.Drawing.Size(75, 23);
            this.btnSearchOverview.TabIndex = 1;
            this.btnSearchOverview.Text = "Search";
            this.toolTips.SetToolTip(this.btnSearchOverview, "Search the overview.");
            this.btnSearchOverview.UseVisualStyleBackColor = true;
            this.btnSearchOverview.Click += new System.EventHandler(this.btnSearchOverview_Click);
            // 
            // btnRefreshOverview
            // 
            this.btnRefreshOverview.Location = new System.Drawing.Point(18, 27);
            this.btnRefreshOverview.Name = "btnRefreshOverview";
            this.btnRefreshOverview.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshOverview.TabIndex = 0;
            this.btnRefreshOverview.Text = "Refresh";
            this.toolTips.SetToolTip(this.btnRefreshOverview, "Refresh the overview completely.");
            this.btnRefreshOverview.UseVisualStyleBackColor = true;
            this.btnRefreshOverview.Click += new System.EventHandler(this.btnRefreshOverview_Click);
            // 
            // tabManage
            // 
            this.tabManage.Controls.Add(this.label6);
            this.tabManage.Controls.Add(this.txtLog);
            this.tabManage.Controls.Add(this.groupBox1);
            this.tabManage.Controls.Add(this.pnlID);
            this.tabManage.Controls.Add(this.cbMod);
            this.tabManage.Controls.Add(this.gbGrapeInfo);
            this.tabManage.Location = new System.Drawing.Point(4, 25);
            this.tabManage.Name = "tabManage";
            this.tabManage.Padding = new System.Windows.Forms.Padding(3);
            this.tabManage.Size = new System.Drawing.Size(792, 421);
            this.tabManage.TabIndex = 1;
            this.tabManage.Text = "Manage";
            this.tabManage.UseVisualStyleBackColor = true;
            this.tabManage.Click += new System.EventHandler(this.tabManage_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(399, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Log";
            // 
            // txtLog
            // 
            this.txtLog.AcceptsReturn = true;
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(399, 203);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(374, 198);
            this.txtLog.TabIndex = 4;
            this.txtLog.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(399, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 73);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(229, 24);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(99, 30);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.toolTips.SetToolTip(this.btnReset, "Clear the fields and reset the current form for re-use.");
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(124, 24);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(99, 30);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.toolTips.SetToolTip(this.btnUpdate, "Update the grape with the selected ID to reflect the current details/properties.");
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(19, 24);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(99, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.toolTips.SetToolTip(this.btnAdd, "Add a new grape with the current properties/details.");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlID
            // 
            this.pnlID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlID.Controls.Add(this.btnRefreshInfo);
            this.pnlID.Controls.Add(this.btnRefreshIDs);
            this.pnlID.Controls.Add(this.btnDelete);
            this.pnlID.Controls.Add(this.cbIDs);
            this.pnlID.Controls.Add(this.label2);
            this.pnlID.Enabled = false;
            this.pnlID.Location = new System.Drawing.Point(18, 46);
            this.pnlID.Name = "pnlID";
            this.pnlID.Size = new System.Drawing.Size(755, 52);
            this.pnlID.TabIndex = 2;
            // 
            // btnRefreshInfo
            // 
            this.btnRefreshInfo.Location = new System.Drawing.Point(490, 13);
            this.btnRefreshInfo.Name = "btnRefreshInfo";
            this.btnRefreshInfo.Size = new System.Drawing.Size(103, 24);
            this.btnRefreshInfo.TabIndex = 8;
            this.btnRefreshInfo.Text = "Refresh Info";
            this.toolTips.SetToolTip(this.btnRefreshInfo, "Refresh the selected grape\'s information.");
            this.btnRefreshInfo.UseVisualStyleBackColor = true;
            this.btnRefreshInfo.Click += new System.EventHandler(this.btnRefreshInfo_Click);
            // 
            // btnRefreshIDs
            // 
            this.btnRefreshIDs.Location = new System.Drawing.Point(380, 13);
            this.btnRefreshIDs.Name = "btnRefreshIDs";
            this.btnRefreshIDs.Size = new System.Drawing.Size(104, 24);
            this.btnRefreshIDs.TabIndex = 7;
            this.btnRefreshIDs.Text = "Refresh ID\'s";
            this.toolTips.SetToolTip(this.btnRefreshIDs, "Refresh the grape ID\'s.");
            this.btnRefreshIDs.UseVisualStyleBackColor = true;
            this.btnRefreshIDs.Click += new System.EventHandler(this.btnRefreshIDs_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(623, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(112, 24);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete Grape";
            this.toolTips.SetToolTip(this.btnDelete, "Delete the grape with the selected ID.");
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // cbIDs
            // 
            this.cbIDs.FormattingEnabled = true;
            this.cbIDs.Location = new System.Drawing.Point(132, 13);
            this.cbIDs.MaxLength = 15;
            this.cbIDs.Name = "cbIDs";
            this.cbIDs.Size = new System.Drawing.Size(242, 24);
            this.cbIDs.TabIndex = 5;
            this.cbIDs.SelectedIndexChanged += new System.EventHandler(this.cbIDs_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Grape ID";
            // 
            // cbMod
            // 
            this.cbMod.AutoSize = true;
            this.cbMod.Location = new System.Drawing.Point(18, 19);
            this.cbMod.Name = "cbMod";
            this.cbMod.Size = new System.Drawing.Size(115, 21);
            this.cbMod.TabIndex = 1;
            this.cbMod.Text = "Modify Grape";
            this.toolTips.SetToolTip(this.cbMod, "Enable/Disable modification of a grape by using the ID dropdown.");
            this.cbMod.UseVisualStyleBackColor = true;
            this.cbMod.CheckedChanged += new System.EventHandler(this.cbMod_CheckedChanged);
            // 
            // gbGrapeInfo
            // 
            this.gbGrapeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbGrapeInfo.Controls.Add(this.txtDescription);
            this.gbGrapeInfo.Controls.Add(this.label3);
            this.gbGrapeInfo.Controls.Add(this.txtType);
            this.gbGrapeInfo.Controls.Add(this.label5);
            this.gbGrapeInfo.Controls.Add(this.label4);
            this.gbGrapeInfo.Controls.Add(this.txtID);
            this.gbGrapeInfo.Controls.Add(this.txtName);
            this.gbGrapeInfo.Controls.Add(this.label1);
            this.gbGrapeInfo.Location = new System.Drawing.Point(18, 104);
            this.gbGrapeInfo.Name = "gbGrapeInfo";
            this.gbGrapeInfo.Size = new System.Drawing.Size(375, 297);
            this.gbGrapeInfo.TabIndex = 0;
            this.gbGrapeInfo.TabStop = false;
            this.gbGrapeInfo.Text = "Grape Details";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(21, 162);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(327, 79);
            this.txtDescription.TabIndex = 7;
            this.toolTips.SetToolTip(this.txtDescription, "The grape\'s description.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Grape Description";
            // 
            // txtType
            // 
            this.txtType.FormattingEnabled = true;
            this.txtType.Items.AddRange(new object[] {
            "White Grape",
            "Red Grape"});
            this.txtType.Location = new System.Drawing.Point(133, 101);
            this.txtType.MaxLength = 25;
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(166, 24);
            this.txtType.TabIndex = 5;
            this.toolTips.SetToolTip(this.txtType, "Type of grape.");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Grape Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(18, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Current ID";
            // 
            // txtID
            // 
            this.txtID.AutoSize = true;
            this.txtID.ForeColor = System.Drawing.Color.Gray;
            this.txtID.Location = new System.Drawing.Point(130, 37);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(89, 17);
            this.txtID.TabIndex = 2;
            this.txtID.Text = "<GRAPE ID>";
            this.toolTips.SetToolTip(this.txtID, "The ID of the current grape.");
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(133, 73);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(215, 22);
            this.txtName.TabIndex = 1;
            this.toolTips.SetToolTip(this.txtName, "Name of the grape.");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grape Name";
            // 
            // Grapes_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Enabled = false;
            this.Name = "Grapes_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grapes";
            this.Load += new System.EventHandler(this.Grapes_Form_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabOverview.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabManage.ResumeLayout(false);
            this.tabManage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.pnlID.ResumeLayout(false);
            this.pnlID.PerformLayout();
            this.gbGrapeInfo.ResumeLayout(false);
            this.gbGrapeInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOverview;
        private System.Windows.Forms.TabPage tabManage;
        private System.Windows.Forms.GroupBox gbGrapeInfo;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbMod;
        private System.Windows.Forms.Panel pnlID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbIDs;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label txtID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox txtType;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnRefreshIDs;
        private System.Windows.Forms.Button btnRefreshInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbGrapes;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearchOverview;
        private System.Windows.Forms.Button btnRefreshOverview;
    }
}