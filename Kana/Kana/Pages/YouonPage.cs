using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Kana.Models;
using Xamarin.Forms;

namespace Kana.Pages
{
    public class YouonPage : GojuuonChart
    {
        public YouonPage() : base(Kanas.Youon)
        {
            fontFactor = Device.OnPlatform(Android: 0.4, iOS: 0.45, WinPhone: 0.45);
        }
    }
}
