using System;
using System.ComponentModel;
using System.Threading;

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
        protected static void Sleep(TimeSpan timeout, CancellationToken token) {
            for (int i=0; i<timeout.TotalMilliseconds; i+=100) {
                token.ThrowIfCancellationRequested();
                Thread.Sleep(100);
            }
        }
        #endregion
    }
}
