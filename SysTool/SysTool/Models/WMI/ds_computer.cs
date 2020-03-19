using SysTool.Attributes;

namespace SysTool.Models.WMI
{
    public class ds_computer : WMIBase, IDataUnit
    {
        public string Display { get { return $"{this.DS_description}  >  {this.DS_name}"; } }
        public string HostName { get { return $"{this.DS_name}"; } }

        [WMIProperty] public string[] DS_description { get; set; }
        [WMIProperty] public string DS_name { get; set; }
        [WMIProperty] public string[] DS_uid { get; set; }
        [WMIProperty] public string DS_displayName { get; set; }
        [WMIProperty] public string DS_info { get; set; }
        [WMIProperty] public string[] DS_networkAddress { get; set; }
    }
}