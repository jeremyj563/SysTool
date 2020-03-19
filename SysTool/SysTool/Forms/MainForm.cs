using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Models;
using SysTool.Models.WMI;
using SysTool.Repositories;

namespace SysTool.Forms
{
    public partial class MainForm : Form
    {
        #region Public Properties
        public BindingList<IDataUnit> WMIData { get; set; }
        #endregion

        #region Constructors
        public MainForm(BindingList<IDataUnit> wmiData)
        {
            InitializeComponent();
            this.WMIData = wmiData;
        }
        #endregion

        #region Public Methods
        public async Task InitializeAsync()
        {
            //var wmi = new WMIRepository<ds_user>(@"\\localhost\root\directory\ldap");
            //var jmj = wmi.Get(nameof(ds_user), "DS_samAccountName='jmj'").First();
            //jmj.DS_displayName = "Jeremy Johnson";
            //jmj.DS_uid[0] = "jmj";
            ////jmj.DS_memberOf[0] = "";
            //jmj.Save();
        }
        #endregion

    }
}