using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kana
{
    public static class Global
    {
        public static bool ShowFrameShadow { get; } = Device.OnPlatform(false, true, true);
    }
}
