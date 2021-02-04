using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Controls;
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

        #region Event Handlers
        private async void MainForm_Load(object sender, EventArgs e) {
            this.InitializeUserInputComboBox();
        }
        private async void SubmitButton_Click(object sender, EventArgs e) {
            this.AcceptButton = null;
            var comboBox = this.UserInputComboBox;
            if (comboBox.SelectedItem is Computer) {
                var computer = comboBox.SelectedItem as Computer;
                var node = this.ResourceExplorer.AddComputerNode(computer);
                this.ResourceExplorer.SelectedNode = node;
                await node.InitializeAsync();
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
            await this.ComputerRepository.InitializeAsync();
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
            _ = searchTerm ?? throw new ArgumentNullException(nameof(searchTerm));
            throw new NotImplementedException();
        }
        private void AddComputerPanel(ComputerPanel panel) {
            this.UserInputComboBox.SelectedItem = panel.Computer;
            this.MainSplitContainer.Panel2.Controls.Clear();
            this.MainSplitContainer.Panel2.Controls.Add(panel);
        }
        #endregion
    }
}