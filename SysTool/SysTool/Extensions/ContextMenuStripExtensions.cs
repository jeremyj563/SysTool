using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Controls;
using SysTool.Enums;
using SysTool.Forms;
using SysTool.Properties;

namespace SysTool.Extensions {
    public static class ContextMenuStripExtensions {
        public static void AddDefaultItems(this ContextMenuStrip menu, ComputerNode node) {
            menu?.Items.Add(ContextMenuLabels.RemoveNode, null, (s, e) => {
                var mainForm = node.ComputerPanel.ParentForm as MainForm;
                mainForm.MainSplitContainer.Panel2.Controls.Clear();
                node.Remove();
            });
        }
        public static void AddOnlineItems(this ContextMenuStrip menu, ComputerNode node) {
            _ = node ?? throw new ArgumentNullException(nameof(node));
            if (node.ComputerPanel.ConnectionState == ConnectionState.Online) {
                var panel = node.ComputerPanel;
                menu?.Items.Add(new ToolStripSeparator());
                menu?.Items.Add(ContextMenuLabels.RemoteAssistance, null, panel.ToolStripMenuItem_StartRemoteAssistance);
                menu?.Items.Add(ContextMenuLabels.RemoteDesktop, null, panel.ToolStripMenuItem_StartRemoteDesktop);
            }
        }
        public static void AddOnlineSlowItems(this ContextMenuStrip menu, ComputerNode node) {
            _ = node ?? throw new ArgumentNullException(nameof(node));
            if (node.ComputerPanel.ConnectionState == ConnectionState.OnlineSlow) {
                menu?.Items.Add(new ToolStripSeparator());

            }
        }
        public static void AddOnlineDegradedItems(this ContextMenuStrip menu, ComputerNode node) {
            _ = node ?? throw new ArgumentNullException(nameof(node));
            if (node.ComputerPanel.ConnectionState == ConnectionState.OnlineDegraded) {
            }
        }
        public static void AddOfflineItems(this ContextMenuStrip menu, ComputerNode node) {
            _ = node ?? throw new ArgumentNullException(nameof(node));
            if (node.ComputerPanel.ConnectionState == ConnectionState.Offline) {
                var panel = node.ComputerPanel;
                menu?.Items.Add(new ToolStripSeparator());
                menu?.Items.Add(ContextMenuLabels.SetDescription, null, panel.ToolStripMenuItem_SetDescription);
            }
        }
    }
}
