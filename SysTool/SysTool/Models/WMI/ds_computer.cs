using SysTool.Attributes;

namespace SysTool.Models.WMI {
    public class ds_computer : WMIBase {
        [WMIProperty] [WMIWritable] public string[] DS_description { get; set; }
        [WMIProperty] [WMIWritable] public string DS_name { get; set; }
        [WMIProperty] [WMIWritable] public string[] DS_uid { get; set; }
        [WMIProperty] [WMIWritable] public string DS_displayName { get; set; }
        [WMIProperty] [WMIWritable] public string DS_info { get; set; }
        [WMIProperty] [WMIWritable] public string[] DS_networkAddress { get; set; }
    }
}