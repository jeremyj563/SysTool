using System;
using System.Management;

namespace SysTool.Extensions {
    public static class EnumerationOptionsExtensions {
        public static EnumerationOptions UseDefault(this EnumerationOptions options) {
            _ = options ?? throw new ArgumentNullException(nameof(options));
            options.ReturnImmediately = true;
            return options;
        }
    }
}
