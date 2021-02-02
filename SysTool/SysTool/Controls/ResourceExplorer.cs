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
        #region Private Enums
        private enum Node {
            RootNode,
            Computers
        }
        #endregion

        #region Public Properties
        public TreeNode RootNode => this.Nodes[nameof(Node.RootNode)];
        public TreeNodeCollection RootNodes => this.RootNode.Nodes;
        public TreeNode ComputersNode => this.RootNodes[nameof(Node.Computers)];
        public TreeNodeCollection ComputerNodes => this.ComputersNode.Nodes;
        #endregion

        #region Public Methods
        public void NewComputerNode(Computer computer) {
            if (computer == null) return;
            var panel = new ComputerPanel(computer);
            var node = new ComputerNode(computer.Display, computer.Value, panel);
            this.AddComputerNode(node);
        }
        public void AddComputerNode(ComputerNode node) {
            if (node == null) return;
            if (this.FindComputerNode(node) == null) {
                this.ComputerNodes.Add(node);
            }
            this.SelectedNode = node;
        }
        public TreeNode FindComputerNode(ComputerNode node) {
            if (node == null) return null;
            var key = node.ComputerPanel.Computer.Value;
            var nodes = this.ComputerNodes.Find(key, false);
            return nodes.SingleOrDefault();
        }
        #endregion
    }
}
