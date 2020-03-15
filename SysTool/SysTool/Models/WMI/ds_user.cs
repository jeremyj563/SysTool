namespace SysTool.Models.WMI
{
    public class ds_user : WMIBase<ds_user>
    {
        public string DS_cn { get; }
        public string[] DS_memberOf { get; }
        public string DS_displayName { get; set; }
        public string[] DS_uid { get; set; }
    }
}