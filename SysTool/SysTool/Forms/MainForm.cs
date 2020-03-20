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
using SysTool.Extensions;
using SysTool.Models;
using SysTool.Models.WMI;
using SysTool.Repositories;

namespace SysTool.Forms
{
    public partial class MainForm : Form
    {
        #region Private Properties
        private BindingSource WMIData { get; set; } = new BindingSource();
        private WMIRepository WMI { get; }
        #endregion

        #region Constructors
        public MainForm(WMIRepository wmi)
        {
            InitializeComponent();
            this.WMI = wmi;
        }
        #endregion

        #region Public Events
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeUserInputComboBox();
        }
        #endregion

        #region Public Methods
        public async Task InitializeAsync()
        {
            await GetWMIData();
        }
        #endregion

        #region Private Methods
        private async Task GetWMIData()
        {
            var computers = await Task
                .Run(() => this.WMI.Get<ds_computer>(nameof(ds_computer)));
            this.WMIData.DataSource = computers;
        }

        private void InitializeUserInputComboBox()
        {
            var comboBox = this.UserInputComboBox;
            comboBox.TextChanged += (s, e) => this.AcceptButton = this.SubmitButton;
            comboBox.Click += (s, e) => this.AcceptButton = this.SubmitButton;
            comboBox.DisplayMember = nameof(IDataUnit.Display);
            comboBox.ValueMember = nameof(IDataUnit.HostName);
            comboBox.DataSource = this.WMIData;
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox.SelectedItem = null;
            comboBox.Focus();
        }
        #endregion
    }
}