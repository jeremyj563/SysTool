using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Enums;
using SysTool.Models;
using SysTool.UserControls;

namespace SysTool.Controls {
    public class ComputerNode : TreeNode {

        #region Public Properties
        public ComputerPanel ComputerPanel { get; }
        #endregion

        #region Constructors
        public ComputerNode(string text, string name, ComputerPanel computerPanel)
            : base(text) {
            base.Name = name;
            this.ComputerPanel = computerPanel ?? throw new ArgumentNullException(nameof(computerPanel));
            this.ComputerPanel.PropertyChanged += ComputerPanel_PropertyChanged;
        }
        #endregion

        #region Event Handlers
        private void ComputerPanel_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            switch (e?.PropertyName) {
                case nameof(this.ComputerPanel.ConnectionState):
                case nameof(this.ComputerPanel.UserStatus):
                    this.SetConnectionStateColor();
                    break;
            }
        }
        #endregion

        #region Private Methods
        private void SetConnectionStateColor() {
            switch (this.ComputerPanel.ConnectionState) {
                case ConnectionState.Online:
                    switch (this.ComputerPanel.UserStatus) {
                        case UserStatus.Active:
                            base.ForeColor = Color.Green;
                            break;
                        case UserStatus.Inactive:
                            base.ForeColor = Color.FromArgb(100, 180, 100);
                            break;
                        case UserStatus.None:
                            base.ForeColor = Color.DarkGray;
                            break;
                    }
                    break;
                case ConnectionState.OnlineSlow:
                    base.ForeColor = Color.Red;
                    break;
                case ConnectionState.OnlineDegraded:
                    base.ForeColor = Color.DarkSlateBlue;
                    break;
                case ConnectionState.Offline:
                    base.ForeColor = Color.Magenta;
                    break;
            }
        }
        #endregion
    }
}
