﻿using System.Windows.Forms;

namespace SysTool.Forms {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Computers");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Collections");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Task");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Query");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Results");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Resource Explorer", new System.Windows.Forms.TreeNode[] { treeNode1, treeNode2, treeNode3, treeNode4, treeNode5 });
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Custom Actions");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Settings", new System.Windows.Forms.TreeNode[] { treeNode7 });
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ResourceExplorer = new SysTool.Controls.ResourceExplorer();
            this.UserInputComboBox = new System.Windows.Forms.ComboBox();
            this.LabelResource = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.UpTimeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MemoryUsageStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CpuUsageStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ConnectionsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.DateTimeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainSplitContainer.BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.MainSplitContainer.Location = new System.Drawing.Point(2, 53);
            this.MainSplitContainer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.ResourceExplorer);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.BackColor = System.Drawing.Color.White;
            this.MainSplitContainer.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MainSplitContainer.Size = new System.Drawing.Size(1350, 817);
            this.MainSplitContainer.SplitterDistance = 323;
            this.MainSplitContainer.SplitterWidth = 6;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // ResourceExplorer
            // 
            this.ResourceExplorer.AllowDrop = true;
            this.ResourceExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResourceExplorer.HideSelection = false;
            this.ResourceExplorer.Location = new System.Drawing.Point(0, 0);
            this.ResourceExplorer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ResourceExplorer.Name = "ResourceExplorer";
            treeNode1.Name = "Computers";
            treeNode1.Text = "Computers";
            treeNode2.Name = "Collections";
            treeNode2.Text = "Collections";
            treeNode3.Name = "Task";
            treeNode3.Text = "Task";
            treeNode4.Name = "Query";
            treeNode4.Text = "Query";
            treeNode5.Name = "Results";
            treeNode5.Text = "Results";
            treeNode6.Name = "RootNode";
            treeNode6.Text = "Resource Explorer";
            treeNode7.Name = "CustomActions";
            treeNode7.Text = "Custom Actions";
            treeNode8.Name = "Settings";
            treeNode8.Text = "Settings";
            this.ResourceExplorer.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode8});
            this.ResourceExplorer.Size = new System.Drawing.Size(323, 817);
            this.ResourceExplorer.TabIndex = 0;
            this.ResourceExplorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ResourceExplorer_AfterSelect);
            // 
            // UserInputComboBox
            // 
            this.UserInputComboBox.AllowDrop = true;
            this.UserInputComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.UserInputComboBox.FormattingEnabled = true;
            this.UserInputComboBox.Location = new System.Drawing.Point(143, 12);
            this.UserInputComboBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.UserInputComboBox.Name = "UserInputComboBox";
            this.UserInputComboBox.Size = new System.Drawing.Size(868, 28);
            this.UserInputComboBox.TabIndex = 0;
            // 
            // LabelResource
            // 
            this.LabelResource.AutoSize = true;
            this.LabelResource.Location = new System.Drawing.Point(16, 17);
            this.LabelResource.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LabelResource.Name = "LabelResource";
            this.LabelResource.Size = new System.Drawing.Size(116, 20);
            this.LabelResource.TabIndex = 1;
            this.LabelResource.Text = "Select Resource:";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.SubmitButton.Location = new System.Drawing.Point(1019, 9);
            this.SubmitButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(101, 36);
            this.SubmitButton.TabIndex = 2;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.ClearButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ClearButton.Location = new System.Drawing.Point(1128, 9);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(101, 36);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            // 
            // NewButton
            // 
            this.NewButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.NewButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.NewButton.Location = new System.Drawing.Point(1237, 9);
            this.NewButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(101, 36);
            this.NewButton.TabIndex = 4;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.UpTimeStatusLabel, this.MemoryUsageStatusLabel, this.CpuUsageStatusLabel, this.ConnectionsStatusLabel, this.DateTimeStatusLabel });
            this.StatusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.StatusStrip1.Location = new System.Drawing.Point(0, 883);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(1352, 26);
            this.StatusStrip1.TabIndex = 5;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // UpTimeStatusLabel
            // 
            this.UpTimeStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.UpTimeStatusLabel.Name = "UpTimeStatusLabel";
            this.UpTimeStatusLabel.Size = new System.Drawing.Size(137, 20);
            this.UpTimeStatusLabel.Text = "UpTimeStatusLabel";
            // 
            // MemoryUsageStatusLabel
            // 
            this.MemoryUsageStatusLabel.Name = "MemoryUsageStatusLabel";
            this.MemoryUsageStatusLabel.Size = new System.Drawing.Size(181, 20);
            this.MemoryUsageStatusLabel.Text = "MemoryUsageStatusLabel";
            // 
            // CpuUsageStatusLabel
            // 
            this.CpuUsageStatusLabel.Name = "CpuUsageStatusLabel";
            this.CpuUsageStatusLabel.Size = new System.Drawing.Size(152, 20);
            this.CpuUsageStatusLabel.Text = "CpuUsageStatusLabel";
            // 
            // ConnectionsStatusLabel
            // 
            this.ConnectionsStatusLabel.Name = "ConnectionsStatusLabel";
            this.ConnectionsStatusLabel.Size = new System.Drawing.Size(166, 20);
            this.ConnectionsStatusLabel.Text = "ConnectionsStatusLabel";
            // 
            // DateTimeStatusLabel
            // 
            this.DateTimeStatusLabel.Name = "DateTimeStatusLabel";
            this.DateTimeStatusLabel.Size = new System.Drawing.Size(166, 20);
            this.DateTimeStatusLabel.Text = "CurrentTimeStatusLabel";
            // 
            // MainForm
            // 
            this.AcceptButton = this.SubmitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ClearButton;
            this.ClientSize = new System.Drawing.Size(1352, 909);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.LabelResource);
            this.Controls.Add(this.UserInputComboBox);
            this.Controls.Add(this.MainSplitContainer);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SysTool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.SplitContainer MainSplitContainer;
        internal System.Windows.Forms.ComboBox UserInputComboBox;
        internal System.Windows.Forms.Label LabelResource;
        internal System.Windows.Forms.Button SubmitButton;
        public SysTool.Controls.ResourceExplorer ResourceExplorer;
        internal System.Windows.Forms.Button ClearButton;
        internal System.Windows.Forms.Button NewButton;
        internal StatusStrip StatusStrip1;
        internal ToolStripStatusLabel UpTimeStatusLabel;
        internal ToolStripStatusLabel CpuUsageStatusLabel;
        internal ToolStripStatusLabel MemoryUsageStatusLabel;
        internal ToolStripStatusLabel ConnectionsStatusLabel;
        internal ToolStripStatusLabel DateTimeStatusLabel;

        #endregion
    }
}

