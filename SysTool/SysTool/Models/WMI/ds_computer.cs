using SysTool.Attributes;

namespace SysTool.Models.WMI {
    public class ds_computer : WMIBase {
        [WMIProperty] [Writable] public string[] DS_description { get; set; }
        [WMIProperty] [Writable] public string DS_name { get; set; }
        [WMIProperty] [Writable] public string[] DS_uid { get; set; }
        [WMIProperty] [Writable] public string DS_displayName { get; set; }
        [WMIProperty] [Writable] public string DS_info { get; set; }
        [WMIProperty] [Writable] public string[] DS_networkAddress { get; set; }
    }
}