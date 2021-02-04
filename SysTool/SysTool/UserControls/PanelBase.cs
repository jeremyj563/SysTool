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
    public partial class PanelBase : UserControl, INotifyPropertyChanged {

        #region Public Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Public Properties
        public IDataUnit DataUnit { get; }
        #endregion

        #region Constructors
        public PanelBase(IDataUnit dataUnit) {
            this.InitializeComponent();
            this.DataUnit = dataUnit;
        }
        #endregion

        #region Protected Methods
        protected void RaisePropertyChangedEvent(string propertyName) {
            var eventArgs = new PropertyChangedEventArgs(propertyName);
            this.PropertyChanged?.Invoke(this, eventArgs);
        }
        protected void WriteStatusMessage(string text, Color color = default) {
            if (string.IsNullOrWhiteSpace(text)) return;
            if (color == default) color = Color.Black;
            var message = $"({DateTime.Now}): {text}{Environment.NewLine}";
            this.StatusTextBox.SelectionStart = this.StatusTextBox.Text.Length;
            this.StatusTextBox.SelectionColor = color;
            this.StatusTextBox.AppendText(message);
            this.StatusTextBox.ScrollToCaret();
        }
        #endregion
    }
}
