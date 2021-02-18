using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SysTool.Models;
using SysTool.Repositories;

namespace SysTool.Monitors {
    public class LDAPMonitor : BaseMonitor {

        #region Public Properties
        public DateTime LastChanged { get; private set; }
        public List<Computer> ChangedComputers {
            get => this._changedComputers;
            private set {
                this._changedComputers = value;
                this.LastChanged = DateTime.Now;
                base.InvokePropertyChangedEvent(nameof(ChangedComputers));
            }
        }
        #endregion

        #region Private Properties
        private ComputerRepository ComputerRepository { get; }
        #endregion

        #region Private Fields
        private List<Computer> _changedComputers = new List<Computer>();
        #endregion

        #region Constructors
        public LDAPMonitor(ComputerRepository computerRepository) {
            this.ComputerRepository = computerRepository;
            this.LastChanged = DateTime.Now;
        }
        #endregion

        #region Public Methods
        public async Task StartAsync(TimeSpan interval, CancellationToken token) {
            while (!token.IsCancellationRequested) {
                await this.StartMonitorAsync(interval, token);
            }
        }
        #endregion

        #region Private Methods
        private async Task StartMonitorAsync(TimeSpan interval, CancellationToken token) {
            try {
                await this.SetChangedComputers();
                BaseMonitor.Sleep(interval, token);
            } catch (OperationCanceledException) {
                return;
            }
        }
        private async Task SetChangedComputers() {
            this.ChangedComputers = await this.ComputerRepository
                .GetChangedComputersAsync(this.LastChanged);
        }
        #endregion
    }
}
