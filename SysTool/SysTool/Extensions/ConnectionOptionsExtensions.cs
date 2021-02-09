using System;
using System.Diagnostics.Contracts;
using System.Management;

namespace SysTool.Extensions {
    public static class ConnectionOptionsExtensions {
        public static ConnectionOptions UseDefault(this ConnectionOptions options) {
            _ = options ?? throw new ArgumentNullException(nameof(options));
            options.Timeout = new TimeSpan(0, 0, 2);
            return options;
        }
    }
}
