using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Models;
using SysTool.UserControls;

namespace SysTool.Controls {
    public class ComputerNode : TreeNode {
        public ComputerPanel ComputerPanel { get; }

        public ComputerNode(string text, string name, ComputerPanel computerPanel)
            : base(text) {
            base.Name = name;
            this.ComputerPanel = computerPanel;
        }
    }
}
