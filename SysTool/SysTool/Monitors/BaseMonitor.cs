using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTool.Monitors {
    public class BaseMonitor : INotifyPropertyChanged {
        #region Public Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Protected Methods
        protected void InvokePropertyChangedEvent(string propertyName) {
            var eventArgs = new PropertyChangedEventArgs(propertyName);
            this.PropertyChanged?.Invoke(this, eventArgs);
        }
        #endregion
    }
}
