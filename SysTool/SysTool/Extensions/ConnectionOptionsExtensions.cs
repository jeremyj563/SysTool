using System;
using System.Management;

namespace SysTool.Extensions {
    public static class ConnectionOptionsExtensions {
        public static ConnectionOptions UseDefault(this ConnectionOptions options) {
            options.Timeout = new TimeSpan(0, 0, 2);
            return options;
        }
    }
}
