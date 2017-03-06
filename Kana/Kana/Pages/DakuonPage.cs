using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Kana.Models;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace Kana.Pages
{
    public class DakuonPage : GojuuonChart
    {
        public DakuonPage() : base(Kanas.Dakuon)
        {
            fontFactor = Device.OnPlatform(Android: 0.3, iOS: 0.3, WinPhone: 0.3);
        }
    }
}
