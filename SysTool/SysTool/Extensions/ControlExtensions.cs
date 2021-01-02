using System;
using System.Windows.Forms;

namespace SysTool.Extensions {
    public static class ControlExtensions {
        public static void UI(this Control control, Action action) {
            if (control == null || action == null) return;

            if (control.IsDisposed == false) {
                if (control.InvokeRequired) {
                    control.Invoke(action);
                }
                else {
                    action.Invoke();
                }
            }
        }
    }
}