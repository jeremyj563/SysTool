using SysTool.Models.WMI;
using SysTool.Extensions;

namespace SysTool.Models
{
    public class Computer : IDataUnit
    {
        public string Display { get { return $"{this.ds_computer.DS_description?[0] ?? "Unknown"}  >  {this.ds_computer.DS_name}"; } }
        public string Value { get { return $"{this.ds_computer.DS_name}"; } }
        public ds_computer ds_computer { get; }

        public Computer(ds_computer ds_computer)
        {
            this.ds_computer = ds_computer;
        }
    }
}