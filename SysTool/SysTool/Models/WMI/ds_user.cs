using SysTool.Attributes;

namespace SysTool.Models.WMI
{
    public class ds_user : WMIBase
    {
        [WMIProperty] public string DS_cn { get; }
        [WMIProperty] public string[] DS_memberOf { get; }
        [WMIProperty] public string DS_displayName { get; set; }
        [WMIProperty] public string[] DS_uid { get; set; }
    }
}