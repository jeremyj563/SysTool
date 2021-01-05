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
        #endregion

        #region Constructors
        public ComputerPanel(Computer computer)
            : base(computer) {
            this.Computer = computer;
        }
        #endregion

        #region Private Methods
        private async Task SetConnectionState() {
            base.WriteStatusMessage(StatusMessages.ConnectionCheck);
            if (await this.Computer.TestOnlineAsync()) {
                this.ConnectionState = ConnectionState.Online;
                base.WriteStatusMessage(StatusMessages.ComputerOnline, Color.Green);
            } else {
                this.ConnectionState = ConnectionState.Offline;
                base.WriteStatusMessage(StatusMessages.ComputerOffline, Color.Red);
            }
        }
        #endregion

        #region Overridden Methods
        protected async override void OnLoad(EventArgs e) {
            if (base.Loaded == false) {
                base.OnLoad(e);
                await this.SetConnectionState();
            }
        }
        #endregion
    }
}
