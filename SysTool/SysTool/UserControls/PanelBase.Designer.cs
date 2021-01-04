
using System.Windows.Forms;

namespace SysTool.UserControls {
    partial class PanelBase {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.StatusTextBox = new System.Windows.Forms.RichTextBox();
            this.SplitContainer.BeginInit();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.SuspendLayout();
            //
            // SplitContainer
            //
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer.Name = "SplitContainer";
            this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            // SplitContainer.Panel2
            //
            this.SplitContainer.Panel2.Controls.Add(this.StatusTextBox);
            this.SplitContainer.Size = new System.Drawing.Size(648, 483);
            this.SplitContainer.SplitterDistance = 418;
            this.SplitContainer.TabIndex = 0;
            //
            // StatusTextBox
            //
            this.StatusTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusTextBox.Location = new System.Drawing.Point(0, 0);
            this.StatusTextBox.Name = "StatusTextBox";
            this.StatusTextBox.ReadOnly = true;
            this.StatusTextBox.Size = new System.Drawing.Size(648, 61);
            this.StatusTextBox.TabIndex = 0;
            this.StatusTextBox.Text = "";
            //
            // TabPanelControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.SplitContainer);
            this.Name = "TabPanelControl";
            this.Size = new System.Drawing.Size(648, 483);
            this.SplitContainer.Panel2.ResumeLayout(false);
            this.SplitContainer.EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        protected System.Windows.Forms.SplitContainer SplitContainer;
        protected System.Windows.Forms.RichTextBox StatusTextBox;

        #endregion
    }
}
