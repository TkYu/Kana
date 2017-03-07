using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kana.Pages
{
    public class SeionPage : GojuuonChart
    {
        public SeionPage() : base(Kanas.Seion)
        {
            fontFactor = Device.OnPlatform(Android: 0.5, iOS: 0.4, WinPhone: 0.45);
        }
    }
}
