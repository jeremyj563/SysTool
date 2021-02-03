using SysTool.Repositories;

namespace SysTool.Utilities {
    public static class DIContainer {
        public static WMIRepository LocalWMI_LDAP => new WMIRepository(@"\\.\root\directory\ldap");
        public static ComputerRepository ComputerRepository => new ComputerRepository(LocalWMI_LDAP);
    }
}