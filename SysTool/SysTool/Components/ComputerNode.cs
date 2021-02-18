using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Components.Panels;
using SysTool.Enums;
using SysTool.Extensions;

namespace SysTool.Components {
    public class ComputerNode : TreeNode {

        #region Public Properties
        public bool Initialized { get; private set; }
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
        private void ComputerPanel_PropertyChanged(object? sender, PropertyChangedEventArgs e) {
            switch (e?.PropertyName) {
                case nameof(ComputerPanel.ConnectionState):
                case nameof(ComputerPanel.UserStatus):
                    this.SetConnectionStateColor();
                    break;
            }
        }
        #endregion

        #region Public Methods
        public async Task InitializeAsync() {
            if (this.Initialized) return;
            this.Initialized = true;
            this.ContextMenuStrip = this.NewContextMenu();
            await this.ComputerPanel.InitializeAsync();
        }
        public ContextMenuStrip NewContextMenu() {
            var menu = new ContextMenuStrip();
            menu.AddDefaultItems(this);
            switch (this?.ComputerPanel.ConnectionState) {
                case ConnectionState.Online:
                case ConnectionState.OnlineSlow:
                    menu.AddOnlineItems(this);
                    menu.AddOnlineSlowItems(this);
                    break;
                case ConnectionState.OnlineDegraded:
                    menu.AddOnlineDegradedItems(this);
                    break;
                case ConnectionState.Offline:
                    menu.AddOfflineItems(this);
                    break;
            }
            return menu;
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
