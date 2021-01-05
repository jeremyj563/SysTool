using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Models;

namespace SysTool.UserControls {
    public partial class PanelBase : UserControl {
        #region Public Properties
        public bool Loaded { get; private set; }
        public IDataUnit DataUnit { get; }
        #endregion

        #region Constructors
        public PanelBase(IDataUnit dataUnit) {
            this.InitializeComponent();
            this.DataUnit = dataUnit;
        }
        #endregion

        #region Protected Methods
        protected void WriteStatusMessage(string text, Color color = default) {
            if (text == null) return;
            if (color == default) color = Color.Black;
            var message = $"({DateTime.Now}): {text}{Environment.NewLine}";
            this.StatusTextBox.SelectionStart = this.StatusTextBox.Text.Length;
            this.StatusTextBox.SelectionColor = color;
            this.StatusTextBox.AppendText(message);
            this.StatusTextBox.ScrollToCaret();
        }
        #endregion

        #region Overridden Methods
        protected override void OnLoad(EventArgs e) {
            if (this.Loaded == false) {
                base.OnLoad(e);
                this.Loaded = true;
            }
        }
        #endregion
    }
}
