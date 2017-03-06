using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Kana.Models;
using Xamarin.Forms;

namespace Kana.Pages
{
    public class DakuonPage : GojuuonChart
    {
        public DakuonPage() : base(Kanas.Dakuon)
        {
            fontFactor = 0.3;
        }
    }
}
