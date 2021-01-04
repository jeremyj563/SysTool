using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Models;
using SysTool.UserControls;

namespace SysTool.Controls {
    public class ResourceExplorer : TreeView {
        private enum Node {
            RootNode,
            Computers
        }

        public TreeNode RootNode => this.Nodes[nameof(Node.RootNode)];
        public TreeNodeCollection RootNodes => this.RootNode.Nodes;
        public TreeNode ComputersNode => this.RootNodes[nameof(Node.Computers)];
        public TreeNodeCollection ComputerNodes => this.ComputersNode.Nodes;

        public void AddComputerNode(ComputerNode node) {
            if (node == null) return;
            if (this.FindComputerNode(node) == null) {
                this.ComputerNodes.Add(node);
                this.SelectedNode = node;
            }
        }

        public TreeNode FindComputerNode(ComputerNode node) {
            if (node == null) return null;
            var key = node.ComputerPanel.Computer.Value;
            var nodes = this.ComputerNodes.Find(key, false);
            return nodes.SingleOrDefault();
        }
    }
}
