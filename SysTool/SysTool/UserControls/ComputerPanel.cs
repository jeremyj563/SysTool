using static Microsoft.VisualBasic.Interaction;
using System;
using System.Drawing;
using System.Threading.Tasks;
using SysTool.Enums;
using SysTool.Models;
using SysTool.Properties;
using SysTool.Repositories;

namespace SysTool.UserControls {
    public class ComputerPanel : PanelBase {

        #region Private Fields
        private ConnectionState _connectionState;
        private UserStatus _userStatus;
        #endregion

        #region Public Properties
        public Computer Computer { get; }
        public WMIRepository WMI { get; }
        public ConnectionState ConnectionState {
            get => this._connectionState;
            private set {
                this._connectionState = value;
                base.RaisePropertyChangedEvent(nameof(ConnectionState));
            }
        }
        public UserStatus UserStatus {
            get => this._userStatus;
            private set {
                this._userStatus = value;
                base.RaisePropertyChangedEvent(nameof(UserStatus));
            }
        }
        #endregion

        #region Constructors
        public ComputerPanel(Computer computer, WMIRepository wmi)
            : base(computer) {
            this.Computer = computer ?? throw new ArgumentNullException(nameof(computer));
            this.WMI = wmi ?? throw new ArgumentNullException(nameof(wmi));
        }
        #endregion

        #region Event Handlers
        public void ToolStripMenuItem_SetDescription(object sender, EventArgs e) {
            var oldDescription = this.Computer.Description;
            var newDescription = InputBox("Enter the new description:", "Set Description", oldDescription);
            this.Computer.Description = newDescription;
            base.WriteStatusMessage($"Description changed from {oldDescription} to {newDescription}");
        }
        public void ToolStripMenuItem_StartRemoteAssistance(object sender, EventArgs e) {
            throw new NotImplementedException();
        }
        public void ToolStripMenuItem_StartRemoteDesktop(object sender, EventArgs e) {
            throw new NotImplementedException();
        }
        #endregion

        #region Public Methods
        public async Task InitializeAsync() {
            try {
                await this.SetConnectionStateAsync();
                await this.SetUserStatusAsync();
            } catch (Exception ex) {
                this.HandleConnectionError(ex);
            }
        }
        #endregion

        #region Private Methods
        private async Task<bool> TestOnlineAsync() {
            base.WriteStatusMessage(StatusMessages.ConnectionCheck);
            if (await this.Computer.TestOnlineAsync() == false) {
                base.WriteStatusMessage(StatusMessages.ComputerOffline, Color.Red);
                this.ConnectionState = ConnectionState.Offline;
                return false;
            }
            return true;
        }
        private async Task SetConnectionStateAsync() {
            if (await this.TestOnlineAsync() == false) return;
            base.WriteStatusMessage(StatusMessages.PingResponse, Color.Green);
            base.WriteStatusMessage(StatusMessages.ComputerOnline, Color.Green);
            var status = await Task.Run(() => this.WMI.GetPingStatus(this.Computer.Value));
            if (status?.ResponseTime < 10) {
                base.WriteStatusMessage(StatusMessages.ConnectionGood, Color.Green);
                this.ConnectionState = ConnectionState.Online;
            } else {
                base.WriteStatusMessage(StatusMessages.ConnectionPoor, Color.Magenta);
                this.ConnectionState = ConnectionState.OnlineSlow;
            }
        }
        private async Task SetUserStatusAsync() {
            if (await this.Computer.TestOnlineAsync() == false) return;
            var explorer = await Task.Run(() => this.WMI.GetProcess("explorer.exe"));
            if (explorer?.Name == "explorer.exe") {
                var logonUI = await Task.Run(() => this.WMI.GetProcess("logonui.exe"));
                if (logonUI?.Name == "logonui.exe") {
                    this.UserStatus = UserStatus.Inactive;
                } else {
                    this.UserStatus = UserStatus.Active;
                }
            } else {
                this.UserStatus = UserStatus.None;
            }
        }
        private void HandleConnectionError(Exception ex) {
            base.WriteStatusMessage(StatusMessages.ConnectionError, Color.Brown);
            base.WriteStatusMessage(ex.Message, Color.Brown);
            this.ConnectionState = ConnectionState.OnlineDegraded;
        }
        #endregion
    }
}
