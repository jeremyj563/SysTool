using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysTool.Models;

namespace SysTool.Monitors {
    public class LDAPMonitor : BaseMonitor {

        #region Public Properties
        public List<Computer> Computers { get; private set; }
        public List<Computer> UpdatedComputers {
            get => this._updatedComputers;
            private set {
                this._updatedComputers = value;
                base.InvokePropertyChangedEvent(nameof(UpdatedComputers));
            }
        }
        #endregion

        #region Private Fields
        private List<Computer> _updatedComputers = new List<Computer>();
        #endregion

        #region Constructors
        public LDAPMonitor(List<Computer> computers) {
            this.Computers = computers;
        }
        #endregion

        #region Public Methods
        public void Start() {
            this.UpdatedComputers = this.Computers;
        }
        #endregion
    }
}
