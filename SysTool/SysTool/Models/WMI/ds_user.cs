using SysTool.Attributes;

namespace SysTool.Models.WMI {
    public class ds_user : WMIBase {
        [WMIProperty] public string DS_cn { get; set; }
        [WMIProperty] [Writable] public string DS_displayName { get; set; }
        [WMIProperty] public string[] DS_memberOf { get; set; }
        [WMIProperty] public string DS_sAMAccountName { get; set; }
        [WMIProperty] [Writable] public string[] DS_uid { get; set; }
    }
}