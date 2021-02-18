using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Extensions;
using SysTool.Models;
using SysTool.Models.WMI;

namespace SysTool.Repositories {
    public class ComputerRepository {

        #region Private Properties
        private WMIRepository LocalWMI_LDAP { get; }
        #endregion

        #region Constructors
        public ComputerRepository(WMIRepository localWMI_LDAP) {
            this.LocalWMI_LDAP = localWMI_LDAP;
        }
        #endregion

        #region Public Methods
        public Computer? Get(string hostname) {
            return this.Where(c => c.Value == hostname)
                ?.SingleOrDefault();
        }
        public List<Computer>? Get() {
            return this.GetComputers();
        }
        public Task<List<Computer>> GetAsync() {
            return this.GetComputersAsync();
        }
        public List<Computer>? Where(Func<Computer, bool> predicate) {
            return this.GetComputers()
                ?.Where(predicate)
                ?.ToList();
        }
        public async Task<List<Computer>?> WhereAsync(Func<Computer, Task<bool>> predicate) {
            var computers = await this.GetComputersAsync();
            return await computers
                .WhereAsync(predicate)
                .ConfigureAwait(false);
        }
        #endregion

        #region Private Methods
        private List<Computer> GetComputers() {
            return this.LocalWMI_LDAP.Get<ds_computer>()
                .Select(c => new Computer(c))
                .ToList();
        }
        private async Task<List<Computer>> GetComputersAsync() {
            var ds_computers = await this.LocalWMI_LDAP.GetAsync<ds_computer>();
            return ds_computers
                .Select(c => new Computer(c))
                .ToList();
        }
        #endregion
    }
}