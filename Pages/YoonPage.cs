using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kana.Pages
{
    public class YoonPage : ChartBase
    {
        public YoonPage() : base(KanaChars.Youon)
        {
            FontFactor = Global.OnPlatform(0.45, 0.5, 0.35);
        }
    }
}
