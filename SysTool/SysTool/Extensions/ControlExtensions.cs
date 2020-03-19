using System;
using System.Windows.Forms;

namespace SysTool.Extensions
{
    public static class ControlExtensions
    {
        public static void UI(this Control control, Action action)
        {
            if (control != null && !control.IsDisposed)
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(action);
                }
                else
                {
                    action?.Invoke();
                }
            }
        }
    }
}