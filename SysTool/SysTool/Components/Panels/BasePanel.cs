﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SysTool.Models;

namespace SysTool.Components.Panels {
    public partial class BasePanel : UserControl, INotifyPropertyChanged {

        #region Public Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Public Properties
        public IDataUnit DataUnit { get; }
        #endregion

        #region Constructors
        public BasePanel(IDataUnit dataUnit) {
            this.InitializeComponent();
            this.DataUnit = dataUnit;
        }
        #endregion

        #region Protected Methods
        protected void InvokePropertyChangedEvent(string propertyName) {
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
