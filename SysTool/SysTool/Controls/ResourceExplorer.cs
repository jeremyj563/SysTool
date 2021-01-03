﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Models;

namespace SysTool.Controls {
    public class ResourceExplorer : TreeView {
        private enum Node {
            RootNode,
            Computers
        }

        private TreeNode RootNode => this.Nodes[nameof(Node.RootNode)];
        private TreeNodeCollection RootNodes => this.RootNode.Nodes;
        private TreeNode ComputersNode => this.RootNodes[nameof(Node.Computers)];
        private TreeNodeCollection ComputerNodes => this.ComputersNode.Nodes;

        public void LoadComputerNode(Computer computer) {
            if (computer == null) return;
            if (this.FindComputerNode(computer) == null) {
                var node = new TreeNode(text: computer.Display) { Name = computer.Value };
                this.ComputerNodes.Add(node);
                this.SelectedNode = node;
            }
        }

        public TreeNode FindComputerNode(Computer computer) {
            if (computer == null) return null;
            var nodes = this.ComputerNodes.Find(computer.Value, false);
            return nodes.SingleOrDefault();
        }
    }
}
