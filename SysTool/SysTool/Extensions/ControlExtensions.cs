using System;
using System.Windows.Forms;

namespace SysTool.Extensions {
    public static class ControlExtensions {
        public static void UI(this Control control, Action action) {
            _ = control ?? throw new ArgumentNullException(nameof(control));
            _ = action ?? throw new ArgumentNullException(nameof(action));

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