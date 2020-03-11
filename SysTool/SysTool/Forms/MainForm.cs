using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Models.WMI;
using SysTool.Repositories;

namespace SysTool.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public async Task InitializeAsync()
        {
            var wmi = new WMIRepository<ds_user>(@"\\localhost\root\directory\ldap");
            var groups = wmi.Get(nameof(ds_user), "ds_samAccountName='jmj'");
        }
    }
}