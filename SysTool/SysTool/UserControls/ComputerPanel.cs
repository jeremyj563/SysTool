using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysTool.Models;

namespace SysTool.UserControls {
    public class ComputerPanel : PanelBase {
        public Computer Computer { get; }
        public ComputerPanel(Computer computer)
            : base(computer) {
            this.Computer = computer;
        }
    }
}
