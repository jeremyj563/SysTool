﻿using System;
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

namespace SysTool.Forms {
    public partial class MainForm : Form {
        #region Private Properties
        private ComputerRepository ComputerRepository { get; }
        #endregion

        #region Constructors
        public MainForm(ComputerRepository computerRepository) {
            InitializeComponent();
            this.ComputerRepository = computerRepository;
        }
        #endregion

        #region Public Events
        private async void MainForm_Load(object sender, EventArgs e) {
            InitializeUserInputComboBox();

            //var computers = this.ComputerRepository.Get();
            //var computer_matches = this.ComputerRepository.Where(c => c.PropertiesContain("jer"));
            var online_computers = await this.ComputerRepository.WhereAsync(c => c.TestOnlineAsync());
        }
        private void SubmitButton_Click(object sender, EventArgs e) {
            this.AcceptButton = null;
            var comboBox = this.UserInputComboBox;
            if (comboBox.SelectedItem is Computer) {
                this.ResourceExplorer.AddComputerNode(comboBox.SelectedItem as Computer);
            } else {
                this.SubmitSearch(comboBox.Text);
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
        #endregion
    }
}