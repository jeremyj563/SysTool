using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysTool.Attributes;

namespace SysTool.Models.WMI {
    public class Win32_PingStatus : WMIBase {
        [WMIProperty] public string Address { get; set; }
        [WMIProperty] public uint PrimaryAddressResolutionStatus { get; set; }
        [WMIProperty] public uint ResponseTime { get; set; }
        [WMIProperty] public uint StatusCode { get; set; }
        [WMIProperty] public uint Timeout { get; set; }
    }
}
