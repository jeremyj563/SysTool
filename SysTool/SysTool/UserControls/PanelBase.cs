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

namespace SysTool.UserControls {
    public partial class PanelBase : UserControl {
        public IDataUnit DataUnit { get; }
        public PanelBase(IDataUnit dataUnit) {
            InitializeComponent();
            this.DataUnit = dataUnit;
        }
    }
}
