using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Controls;
using SysTool.Extensions;
using SysTool.Models;
using SysTool.Repositories;
using SysTool.UserControls;

namespace SysTool.Forms {
    public partial class MainForm : Form {
        #region Private Properties
        private ComputerRepository ComputerRepository { get; }
        #endregion

        #region Constructors
        public MainForm(ComputerRepository computerRepository) {
            this.InitializeComponent();
            this.ComputerRepository = computerRepository;
        }
        #endregion

        #region Public Events
        private async void MainForm_Load(object sender, EventArgs e) {
            this.InitializeUserInputComboBox();
        }
        private void SubmitButton_Click(object sender, EventArgs e) {
            this.AcceptButton = null;
            var comboBox = this.UserInputComboBox;
            if (comboBox.SelectedItem is Computer) {
                var node = this.ComputerNodeFactory();
                this.ResourceExplorer.AddComputerNode(node);
            } else {
                this.SubmitSearch(comboBox.Text);
            }
        }
        private void ResourceExplorer_AfterSelect(object sender, TreeViewEventArgs e) {
            if (this.ResourceExplorer.SelectedNode.Parent == this.ResourceExplorer.ComputersNode) {
                var node = this.ResourceExplorer.SelectedNode as ComputerNode;
                this.AddComputerPanel(node.ComputerPanel);
            }
        }
        #endregion

        #region Public Methods
        public async Task InitializeAsync() {
            await Task.Run(() => this.ComputerRepository.Initialize());
        }
        #endregion

        #region Private Methods
        private void InitializeUserInputComboBox() {
            var comboBox = this.UserInputComboBox;
            comboBox.GotFocus += (s, e) => this.AcceptButton = this.SubmitButton;
            comboBox.DisplayMember = nameof(IDataUnit.Display);
            comboBox.ValueMember = nameof(IDataUnit.Value);
            comboBox.DataSource = this.ComputerRepository.BindingSource;
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox.SelectedItem = null;
            comboBox.Focus();
        }
        private void SubmitSearch(string searchTerm) {
            if (string.IsNullOrWhiteSpace(searchTerm)) return;
        }
        private ComputerNode ComputerNodeFactory() {
            var computer = this.UserInputComboBox.SelectedItem as Computer;
            var panel = new ComputerPanel(computer);
            var node = new ComputerNode(computer.Display, computer.Value, panel);
            return node;
        }
        private async void AddComputerPanel(ComputerPanel panel) {
            this.UserInputComboBox.SelectedItem = panel.Computer;
            this.MainSplitContainer.Panel2.Controls.Clear();
            this.MainSplitContainer.Panel2.Controls.Add(panel);
            if (!panel.Initialized) {
                await panel.InitializeAsync();
            }
        }
        #endregion
    }
}