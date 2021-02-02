using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Enums;
using SysTool.Models;
using SysTool.Models.WMI;
using SysTool.Properties;

namespace SysTool.UserControls {
    public class ComputerPanel : PanelBase {
        #region Public Properties
        public Computer Computer { get; }
        public ConnectionState ConnectionState { get; private set; }
        public UserStatus UserStatus { get; private set; }
        #endregion

        #region Constructors
        public ComputerPanel(Computer computer)
            : base(computer) {
            this.Computer = computer;
        }
        #endregion

        #region Private Methods
        private async Task SetConnectionStateAsync() {
            base.WriteStatusMessage(StatusMessages.ConnectionCheck);
            if (await this.Computer.TestOnlineAsync() == false) {
                base.WriteStatusMessage(StatusMessages.ComputerOffline, Color.Red);
                this.ConnectionState = ConnectionState.Offline;
                return;
            }
            base.WriteStatusMessage(StatusMessages.PingResponse, Color.Green);
            base.WriteStatusMessage(StatusMessages.ComputerOnline, Color.Green);
            await TestResponseTime();
        }
        private async Task TestResponseTime() {
            var status = await this.Computer.WMI.GetPingStatusAsync(this.Computer.Value);
            if (status.ResponseTime < 10) {
                base.WriteStatusMessage(StatusMessages.ConnectionGood, Color.Green);
                this.ConnectionState = ConnectionState.Online;
            } else {
                base.WriteStatusMessage(StatusMessages.ConnectionPoor, Color.Magenta);
                this.ConnectionState = ConnectionState.OnlineSlow;
            }
        }
        private async Task SetUserStatusAsync() {
            var explorer = await this.Computer.WMI.GetProcessAsync("explorer.exe");
            if (explorer?.Name == "explorer.exe") {
                var logonUI = await this.Computer.WMI.GetProcessAsync("logonui.exe");
                if (logonUI?.Name == "logonui.exe") {
                    this.UserStatus = UserStatus.Inactive;
                } else {
                    this.UserStatus = UserStatus.Active;
                }
            } else {
                this.UserStatus = UserStatus.None;
            }
        }
        #endregion

        #region Event Handlers
        protected async override void OnLoad(EventArgs e) {
            if (base.Loaded) return;
            base.OnLoad(e);
            await this.SetConnectionStateAsync();
            await this.SetUserStatusAsync();
        }
        #endregion
    }
}
