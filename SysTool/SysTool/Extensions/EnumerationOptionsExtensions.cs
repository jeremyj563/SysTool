using System.Management;

namespace SysTool.Extensions {
    public static class EnumerationOptionsExtensions {
        public static EnumerationOptions UseDefault(this EnumerationOptions options) {
            options.ReturnImmediately = true;
            return options;
        }
    }
}
