using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kana.Pages
{
    public class DakuonPage : ChartBase
    {
        public DakuonPage() : base(KanaChars.Dakuon)
        {
            FontFactor = Global.OnPlatform(0.45, 0.5, 0.4);
        }
    }
}
