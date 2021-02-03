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

        #region Static Methods
        public static ComputerNode NewComputerNode(Computer computer) {
            _ = computer ?? throw new ArgumentNullException(nameof(computer));
            var path = @$"\\{computer.Value}\root\cimv2";
            computer.WMI = new WMIRepository(path);
            var panel = new ComputerPanel(computer);
            return new ComputerNode(computer.Display, computer.Value, panel);
        }
        #endregion

        #region Public Methods
        public ComputerNode AddComputerNode(Computer computer) {
            _ = computer ?? throw new ArgumentNullException(nameof(computer));
            var node = this.FindComputerNode(computer.Value);
            if (node is null) {
                node = NewComputerNode(computer);
                this.ComputerNodes.Add(node);
            }
            return node;
        }
        public ComputerNode FindComputerNode(string key) {
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var nodes = this.ComputerNodes.Find(key, false);
            return nodes.SingleOrDefault() as ComputerNode;
        }
        #endregion
    }
}
