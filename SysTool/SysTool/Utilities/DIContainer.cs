using System;
using System.Collections.Generic;
using System.Text;
using SysTool.Models;
using SysTool.Models.WMI;
using SysTool.Repositories;

namespace SysTool.Utilities
{
    public static class DIContainer
    {
        public static WMIRepository LocalWMI { get; } = new WMIRepository(@"\\.\root\directory\ldap");
    }
}
