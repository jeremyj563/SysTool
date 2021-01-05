using System.Runtime.CompilerServices;
using SysTool.Repositories;

namespace SysTool.Utilities {
    public static class DIContainer {
        public static WMIRepository LocalWMI_LDAP { get; } = new WMIRepository(@"\\.\root\directory\ldap");
        public static ComputerRepository ComputerRepository { get; } = new ComputerRepository(LocalWMI_LDAP);
    }
}