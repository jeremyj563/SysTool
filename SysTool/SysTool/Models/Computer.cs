using SysTool.Models.WMI;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using SysTool.Repositories;

namespace SysTool.Models {
    public class Computer : IDataUnit {

        #region Public Properties
        public string Display => $"{this.ds_computer.DS_description?[0] ?? "Unknown"}  >  {this.ds_computer.DS_name}";
        public string Value => this.ds_computer.DS_name;
        public WMIRepository WMI { get; set; }
        #endregion

        #region Private Properties
        private ds_computer ds_computer { get; }
        #endregion

        #region Constructors
        public Computer(ds_computer ds_computer) {
            this.ds_computer = ds_computer;
        }
        #endregion

        #region Public Methods
        public async Task InitializeAsync() {
            if (await this.TestOnlineAsync()) {
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
        #endregion
    }
}