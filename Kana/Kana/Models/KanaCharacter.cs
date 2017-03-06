using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kana.Models
{
    public class KanaChar
    {
        public KanaChar(string hiragana, string katakana,string romaji, string phoneticSymbol,bool oldCharObsoleted = false)
        {
            Hiragana = hiragana;
            Katakana = katakana;
            Romaji = romaji;
            PhoneticSymbol = phoneticSymbol;
            OldCharObsoleted = oldCharObsoleted;
        }
        public bool OldCharObsoleted { get; }
        public string Hiragana { get; }
        public string Katakana { get; }
        public string Romaji { get; }
        public string PhoneticSymbol { get; }
    }
}
