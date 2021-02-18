using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Components;
using SysTool.Components.Panels;
using SysTool.Extensions;
using SysTool.Models;
using SysTool.Monitors;
using SysTool.Repositories;

namespace SysTool.Forms {
    public partial class MainForm : Form {

        #region Private Properties
        private ComputerRepository ComputerRepository { get; }
        private BindingSource BindingSource { get; }
        private LDAPMonitor LDAPMonitor { get; }
        private CancellationTokenSource CancellationTokenSource { get; }
        #endregion

        #region Constructors
        public MainForm(ComputerRepository computerRepository) {
            this.InitializeComponent();
            this.ComputerRepository = computerRepository;
            this.BindingSource = new BindingSource();
            this.LDAPMonitor = new LDAPMonitor(computerRepository);
            this.LDAPMonitor.PropertyChanged += LDAPMonitor_PropertyChanged;
            this.CancellationTokenSource = new CancellationTokenSource();
        }
        #endregion

        #region Event Handlers
        private void MainForm_Load(object sender, EventArgs e) {
            this.InitializeUserInputComboBox();
        }
        private void MainForm_Shown(object sender, EventArgs e) {
            this.StartBackgroundMonitors();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            this.CancellationTokenSource.Cancel();
        }
        private async void SubmitButton_Click(object sender, EventArgs e) {
            this.AcceptButton = null;
            var comboBox = this.UserInputComboBox;
            if (comboBox.SelectedItem is not null && comboBox.SelectedItem is Computer) {
                var computer = comboBox.SelectedItem as Computer;
                var node = this.ResourceExplorer.AddComputerNode(computer!);
                this.ResourceExplorer.SelectedNode = node;
                await node.InitializeAsync();
            } else {
                this.SubmitSearch(comboBox.Text);
            }
        }
        private void ResourceExplorer_AfterSelect(object sender, TreeViewEventArgs e) {
            if (this.ResourceExplorer.SelectedNode.Parent == this.ResourceExplorer.ComputersNode) {
                var node = this.ResourceExplorer.SelectedNode as ComputerNode;
                this.AddComputerPanel(node!.ComputerPanel);
            }
        }
        private void LDAPMonitor_PropertyChanged(object? sender, PropertyChangedEventArgs e) {
            switch (e.PropertyName) {
                case nameof(LDAPMonitor.ChangedComputers):
                    var computers = this.LDAPMonitor.ChangedComputers;
                    this.UpdateChangedComputers(computers);
                    break;
            }
        }
        #endregion

        #region Public Methods
        public async Task InitializeAsync() {
            this.BindingSource.DataSource = await this.ComputerRepository.GetAsync();
        }
        #endregion

        #region Private Methods
        private void InitializeUserInputComboBox() {
            var comboBox = this.UserInputComboBox;
            comboBox.GotFocus += (s, e) => this.AcceptButton = this.SubmitButton;
            comboBox.DisplayMember = nameof(IDataUnit.Display);
            comboBox.ValueMember = nameof(IDataUnit.Value);
            comboBox.DataSource = this.BindingSource;
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox.SelectedItem = null;
            comboBox.Focus();
        }
        private void SubmitSearch(string searchTerm) {
            _ = searchTerm ?? throw new ArgumentNullException(nameof(searchTerm));
            throw new NotImplementedException();
        }
        private void AddComputerPanel(ComputerPanel panel) {
            this.UserInputComboBox.SelectedItem = panel.Computer;
            this.MainSplitContainer.Panel2.Controls.Clear();
            this.MainSplitContainer.Panel2.Controls.Add(panel);
        }
        private void StartBackgroundMonitors() {
            var token = this.CancellationTokenSource.Token;
            var twentySeconds = new TimeSpan().TwentySeconds();
            Task.Run(() => this.LDAPMonitor.StartAsync(interval: twentySeconds, token));
        }
        private void UpdateChangedComputers(List<Computer> computers) {
            foreach (var changedComputer in computers) {
                var boundComputer = this.BindingSource.OfType<Computer>()
                    .SingleOrDefault(c => c.Value == changedComputer.Value);
                this.BindingSource.UpdateItem(boundComputer, changedComputer);
            }
        }
        #endregion
    }
}