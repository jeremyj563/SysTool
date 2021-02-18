using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
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

        #region Repository Methods
        public Task<List<Computer>> GetChangedComputersAsync(DateTime dateTime) {
            var dmtfDateTime = ManagementDateTimeConverter.ToDmtfDateTime(dateTime);
            var whenChanged = dmtfDateTime.Split('.').First();
            var condition = $"!whenChanged<={whenChanged}.0Z";
            return this.GetComputersAsync(condition);
        }
        #endregion

        #region Public Methods
        public List<Computer>? Get(string? condition = default) {
            return this.GetComputers(condition);
        }
        public Task<List<Computer>> GetAsync(string? condition = default) {
            return this.GetComputersAsync(condition);
        }
        #endregion

        #region Private Methods
        private List<Computer> GetComputers(string? condition = default) {
            return this.LocalWMI_LDAP.Get<ds_computer>(condition: condition)
                .Select(c => new Computer(c))
                .ToList();
        }
        private async Task<List<Computer>> GetComputersAsync(string? condition = default) {
            var ds_computers = await this.LocalWMI_LDAP.GetAsync<ds_computer>(condition: condition);
            return ds_computers
                .Select(c => new Computer(c))
                .ToList();
        }
        #endregion
    }
}