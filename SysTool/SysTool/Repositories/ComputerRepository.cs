﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Extensions;
using SysTool.Models;
using SysTool.Models.WMI;

namespace SysTool.Repositories {
    public class ComputerRepository {

        #region Public Properties
        public BindingSource BindingSource { get; } = new BindingSource();
        #endregion

        #region Private Properties
        private WMIRepository LocalWMI_LDAP { get; }
        private List<Computer> Computers => this.BindingSource.AsList<Computer>();
        #endregion

        #region Constructors
        public ComputerRepository(WMIRepository localWMI_LDAP) {
            this.LocalWMI_LDAP = localWMI_LDAP;
        }
        #endregion

        #region Public Methods
        public async Task InitializeAsync() {
            var ds_computers = await this.LocalWMI_LDAP.GetAsync<ds_computer>();
            var computers = ds_computers
                .Select(c => new Computer(c));
            this.BindingSource.DataSource = computers;
        }
        public Computer Get(string hostname) {
            var computer = this.Computers
                .SingleOrDefault(c => c.Value == hostname);
            return computer;
        }
        public List<Computer> Get() {
            return this.Computers;
        }
        public List<Computer> Where(Func<Computer, bool> predicate) {
            var computers = this.Computers
                .Where(predicate)
                .ToList();
            return computers;
        }
        public async Task<List<Computer>> WhereAsync(Func<Computer, Task<bool>> predicate) {
            var computers = await this.Computers
                .WhereAsync(predicate)
                .ConfigureAwait(false);
            return computers;
        }
        #endregion
    }
}