using System;

namespace SysTool.Extensions {
    public static class TimeSpanExtensions {
        public static TimeSpan TwentySeconds(this TimeSpan timeSpan) {
            return new TimeSpan(0, 0, 20);
        }
    }
}
