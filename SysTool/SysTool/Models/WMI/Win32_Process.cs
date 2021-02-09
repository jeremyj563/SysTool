using SysTool.Attributes;

namespace SysTool.Models.WMI {
    public class Win32_Process : WMIBase {
        [WMIProperty] public string? Handle { get; set; }
        [WMIProperty] public string? CSName { get; set; }
        [WMIProperty] public string? Name { get; set; }
        [WMIProperty] public uint ProcessId { get; set; }
    }
}
