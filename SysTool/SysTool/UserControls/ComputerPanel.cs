﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Enums;
using SysTool.Models;
using SysTool.Models.WMI;
using SysTool.Properties;
using SysTool.Repositories;

namespace SysTool.UserControls {
    public class ComputerPanel : PanelBase, INotifyPropertyChanged {
        #region Public Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Private Fields
        private ConnectionState _connectionState;
        private UserStatus _userStatus;
        #endregion

        #region Public Properties
        public Computer Computer { get; }
        public ConnectionState ConnectionState {
            get => this._connectionState;
            private set {
                this._connectionState = value;
                this.RaisePropertyChangedEvent(nameof(ConnectionState));
            }
        }
        public UserStatus UserStatus {
            get => this._userStatus;
            private set {
                this._userStatus = value;
                this.RaisePropertyChangedEvent(nameof(UserStatus));
            }
        }
        #endregion

        #region Constructors
        public ComputerPanel(Computer computer, WMIRepository wmi)
            : base(computer) {
            this.Computer = computer ?? throw new ArgumentNullException(nameof(computer));
            this.Computer.WMI = wmi ?? throw new ArgumentNullException(nameof(wmi));
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
        private void RaisePropertyChangedEvent(string propertyName) {
            var eventArgs = new PropertyChangedEventArgs(propertyName);
            this.PropertyChanged?.Invoke(this, eventArgs);
        }
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
            var status = await this.Computer.WMI.GetPingStatusAsync(this.Computer.Value);
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
        private void HandleConnectionError(Exception ex) {
            base.WriteStatusMessage(StatusMessages.ConnectionError, Color.Brown);
            base.WriteStatusMessage(ex.Message, Color.Brown);
            this.ConnectionState = ConnectionState.OnlineDegraded;
        }
        #endregion

        #region Event Handlers
        protected async override void OnLoad(EventArgs e) {
            if (base.Loaded) return;
            base.OnLoad(e);
            await this.InitializeAsync();
        }
        #endregion
    }
}
