using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SysTool.Extensions;
using SysTool.Models;
using SysTool.Models.WMI;

namespace SysTool.Repositories
{
    public class ComputerRepository
    {
        public BindingSource BindingSource { get; } = new BindingSource();
        private WMIRepository WMI { get; }
        private List<Computer> Computers { get { return this.BindingSource.AsList<Computer>(); } }

        public ComputerRepository(WMIRepository wmi)
        {
            this.WMI = wmi;
        }

        public void Initialize()
        {
            var computers = this.WMI
                .Get<ds_computer>()
                .Select(d => new Computer(d))
                .ToList();
            this.BindingSource.DataSource = computers;
        }

        public Computer Get(string hostname)
        {
            var computer = this.Computers
                .SingleOrDefault(c => c.ds_computer.DS_name == hostname);
            return computer;
        }

        public List<Computer> Get()
        {
            return this.Computers;
        }

        public List<Computer> Where(Func<Computer, bool> predicate)
        {
            var computers = this.Computers
                .Where(predicate)
                .ToList();
            return computers;
        }
    }
}