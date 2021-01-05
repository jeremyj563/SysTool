using SysTool.Models.WMI;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using SysTool.Enums;
using SysTool.Repositories;
using System.Collections.Generic;

namespace SysTool.Models {
    public class Computer : IDataUnit {
        #region Public Properties
        public string Display { get { return $"{this.ds_computer.DS_description?[0] ?? "Unknown"}  >  {this.ds_computer.DS_name}"; } }
        public string Value { get { return $"{this.ds_computer.DS_name}"; } }
        public ds_computer ds_computer { get; }
        public List<Win32_Process> Win32_Processes { get; private set; }
        public WMIRepository WMI { get; }
        #endregion

        #region Constructors
        public Computer(ds_computer ds_computer, WMIRepository wmi) {
            this.ds_computer = ds_computer;
            this.WMI = wmi;
        }
        #endregion

        #region Public Methods
        public void Initialize() {
            if (this.TestOnline()) {
                this.Win32_Processes = this.WMI.Get<Win32_Process>();
            }
        }
        public bool TestOnline(int timeout = 250) {
            try {
                using var ping = new Ping();
                var response = ping
                    .Send(this.ds_computer.DS_name, timeout);
                return response.Status == IPStatus.Success;
            }
            catch (PingException) {
                return false;
            }
        }
        public async Task<bool> TestOnlineAsync(int timeout = 250) {
            try {
                using var ping = new Ping();
                var response = await ping
                    .SendPingAsync(this.ds_computer.DS_name, timeout)
                    .ConfigureAwait(false);
                return response.Status == IPStatus.Success;
            }
            catch (PingException) {
                return false;
            }
        }
        public async Task<UserStatus> GetUserStatus() {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Private Methods
        #endregion
    }
}