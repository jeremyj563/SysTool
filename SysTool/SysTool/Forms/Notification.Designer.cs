namespace SysTool.Forms
{
    partial class Notification
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
            this.DetailsButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.DetailsTextBox = new System.Windows.Forms.TextBox();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DetailsButton
            // 
            this.DetailsButton.Enabled = false;
            this.DetailsButton.Location = new System.Drawing.Point(13, 143);
            this.DetailsButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DetailsButton.Name = "DetailsButton";
            this.DetailsButton.Size = new System.Drawing.Size(111, 27);
            this.DetailsButton.TabIndex = 1;
            this.DetailsButton.Text = "⏷      Details";
            this.DetailsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DetailsButton.UseVisualStyleBackColor = true;
            this.DetailsButton.Visible = false;
            this.DetailsButton.Click += new System.EventHandler(this.DetailsButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(394, 143);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(111, 27);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // DetailsTextBox
            // 
            this.DetailsTextBox.Location = new System.Drawing.Point(13, 177);
            this.DetailsTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DetailsTextBox.MaximumSize = new System.Drawing.Size(492, 169);
            this.DetailsTextBox.Multiline = true;
            this.DetailsTextBox.Name = "DetailsTextBox";
            this.DetailsTextBox.ReadOnly = true;
            this.DetailsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DetailsTextBox.Size = new System.Drawing.Size(492, 169);
            this.DetailsTextBox.TabIndex = 6;
            this.DetailsTextBox.Text = "DetailsTextBox";
            this.DetailsTextBox.Visible = false;
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageTextBox.Location = new System.Drawing.Point(83, 13);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.ReadOnly = true;
            this.MessageTextBox.Size = new System.Drawing.Size(426, 106);
            this.MessageTextBox.TabIndex = 7;
            this.MessageTextBox.Text = "MessageTextBox";
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(519, 361);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.DetailsButton);
            this.Controls.Add(this.DetailsTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Notification";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DetailsButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TextBox DetailsTextBox;
        private System.Windows.Forms.TextBox MessageTextBox;
    }
}