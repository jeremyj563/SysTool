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
        private async Task<ConnectionState> GetConnectionStateAsync() {
            base.WriteStatusMessage(StatusMessages.ConnectionCheck);
            if (await this.Computer.TestOnlineAsync()) {
                base.WriteStatusMessage(StatusMessages.ComputerOnline, Color.Green);
                return ConnectionState.Online;
            } else {
                base.WriteStatusMessage(StatusMessages.ComputerOffline, Color.Red);
                return ConnectionState.Offline;
            }
        }
        private async Task TestConnectionStateAsync() {
            if (this.ConnectionState == ConnectionState.Offline) return;

        }
        private async Task<UserStatus> GetUserStatusAsync() {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Overridden Methods
        protected async override void OnLoad(EventArgs e) {
            if (base.Loaded) return;
            base.OnLoad(e);
            this.ConnectionState = await this.GetConnectionStateAsync();
            if (this.ConnectionState != ConnectionState.Offline) {
                await this.TestConnectionStateAsync();
                //this.UserStatus = await this.GetUserStatus();
            }
        }
        #endregion
    }
}
