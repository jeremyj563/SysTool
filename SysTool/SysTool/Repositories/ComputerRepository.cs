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
        public BindingSource BindingSource { get; } = new BindingSource();
        private WMIRepository LocalWMI_LDAP { get; }
        private List<Computer> Computers => this.BindingSource.AsList<Computer>();

        public ComputerRepository(WMIRepository localWMI_LDAP) {
            this.LocalWMI_LDAP = localWMI_LDAP;
        }

        public void Initialize() {
            var computers = this.LocalWMI_LDAP.Get<ds_computer>()
                .Select(d => new Computer(d, new WMIRepository(@$"\\{d.DS_name}\root\cimv2")));
            this.BindingSource.DataSource = computers;
        }

        public Computer Get(string hostname) {
            var computer = this.Computers
                .SingleOrDefault(c => c.ds_computer.DS_name == hostname);
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
    }
}