using SysTool.Models.WMI;
using SysTool.Extensions;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace SysTool.Models {
    public class Computer : IDataUnit {
        public string Display { get { return $"{this.ds_computer.DS_description?[0] ?? "Unknown"}  >  {this.ds_computer.DS_name}"; } }
        public string Value { get { return $"{this.ds_computer.DS_name}"; } }
        public bool Online { get { return TestOnline(); } }
        public ds_computer ds_computer { get; }

        public Computer(ds_computer ds_computer) {
            this.ds_computer = ds_computer;
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
    }
}