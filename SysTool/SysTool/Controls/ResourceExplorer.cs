using System;
using System.Linq;
using System.Windows.Forms;
using SysTool.Models;
using SysTool.Repositories;
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
            _ = computer ?? throw new ArgumentNullException(nameof(computer));
            var path = @$"\\{computer.Value}\root\cimv2";
            var wmi = new WMIRepository(path);
            var panel = new ComputerPanel(computer, wmi);
            var node = new ComputerNode(computer.Display, computer.Value, panel);
            this.AddComputerNode(node);
        }
        public void AddComputerNode(ComputerNode node) {
            _ = node ?? throw new ArgumentNullException(nameof(node));
            if (this.FindComputerNode(node) is null) {
                this.ComputerNodes.Add(node);
            }
            this.SelectedNode = node;
        }
        public TreeNode FindComputerNode(ComputerNode node) {
            _ = node ?? throw new ArgumentNullException(nameof(node));
            var key = node.ComputerPanel.Computer.Value;
            var nodes = this.ComputerNodes.Find(key, false);
            return nodes.SingleOrDefault();
        }
        #endregion
    }
}
