using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SysTool.Forms
{
    public partial class Notification : Form
    {
        #region Private Properties

        private MessageBoxIcon MessageBoxIcon { get; set; }
        private string UpArrowText { get; } = $"{char.ConvertFromUtf32(0x23F6)}      Details";
        private string DownArrowText { get; } = $"{char.ConvertFromUtf32(0x23F7)}      Details";

        #endregion

        #region Constructors

        public Notification(string message, string details, string title, MessageBoxIcon icon)
        {
            InitializeComponent();

            this.Height = 220;
            this.Text = title;
            this.MessageTextBox.Text = message;
            this.MessageBoxIcon = icon;

            if (!string.IsNullOrWhiteSpace(details))
            {
                this.DetailsButton.Visible = true;
                this.DetailsButton.Text = this.DownArrowText;
                this.DetailsButton.Enabled = true;
                this.DetailsTextBox.Text = details;
            }
        }

        #endregion

        #region Static Methods

        public static void Show(Type type, MethodBase method, string details)
        {
            var message = $"Type: {type?.ToString()}";
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += $"Method: {method?.ToString()}";
            Show(message, details);
        }

        public static void Show(string message, string details = "", string title = "Error", MessageBoxIcon icon = MessageBoxIcon.Error)
        {
            using var messageBox = new Notification(message, details, title, icon);
            messageBox.ShowDialog();
        }

        #endregion

        #region Event Handlers

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawMessageBoxIcon(e);
            base.OnPaint(e);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetailsButton_Click(object sender, EventArgs e)
        {
            bool visible = this.DetailsTextBox.Visible;
            this.DetailsTextBox.Visible = !visible;
            this.DetailsButton.Text = visible ? this.UpArrowText : this.DownArrowText;
            this.Height = visible ? this.Height - 180 : this.Height + 180;
        }

        #endregion

        #region Private Methods

        private void DrawMessageBoxIcon(PaintEventArgs e)
        {
            var iconName = Enum.GetName(typeof(MessageBoxIcon), this.MessageBoxIcon);
            var icon = typeof(SystemIcons).GetProperty(iconName).GetValue(null) as Icon;
            e.Graphics.DrawIcon(icon, 16, 16);
        }

        #endregion
    }
}