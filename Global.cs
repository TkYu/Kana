using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kana
{
    public static class Global
    {
        public const string YSFontFamily = "YujiSyuku";

        public static bool ShowFrameShadow { get; } = OnPlatform(false, true, true);


        private static T OnImpl<T>(T @default = default(T), T iOS = default(T), T Android = default(T), Func<T> computeCustom = null)
        {
            if (DeviceInfo.Platform == DevicePlatform.iOS)
                return iOS;
            if (DeviceInfo.Platform == DevicePlatform.Android)
                return Android;
            if (computeCustom == null) return @default;
            return computeCustom.Invoke();
        }

        public static T OnPlatform<T>(T @default = default(T), T iOS = default(T), T Android = default(T)) => OnImpl(@default, iOS, Android, null);
    }
}
