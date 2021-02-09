using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using SysTool.Models.WMI;

namespace SysTool.Models {
    public class Computer : IDataUnit {

        #region Public Properties
        public string Display => $"{this.Description}  >  {this.Value}";
        public string Value => this.ds_computer.DS_name ?? string.Empty;
        public string Description {
            get => this.ds_computer.DS_description?[0] ?? "Unknown";
            set {
                this.ds_computer.DS_description = new[] { value ?? string.Empty };
                this.ds_computer.Save(new[] { nameof(ds_computer.DS_description) });
            }
        }
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
        public async Task<bool> TestOnlineAsync(int timeout = 250) {
            try {
                using var ping = new Ping();
                var response = await ping
                    .SendPingAsync(this.Value, timeout)
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