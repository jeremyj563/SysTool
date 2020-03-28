using SysTool.Attributes;

namespace SysTool.Models.WMI
{
    public class ds_user : WMIBase, IDataUnit
    {
        public string Display { get { return $"{this.DS_displayName}" ?? "Unknown"; } }
        public string Value { get { return $"{this.DS_sAMAccountName}"; } }

        [WMIProperty] public string DS_cn { get; set; }
        [WMIProperty] [Writable] public string DS_displayName { get; set; }
        [WMIProperty] public string[] DS_memberOf { get; set; }
        [WMIProperty] public string DS_sAMAccountName { get; set; }
        [WMIProperty] [Writable] public string[] DS_uid { get; set; }
    }
}